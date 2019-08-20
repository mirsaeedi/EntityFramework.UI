using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication5.Controllers
{
    [Area("EntityFrameworkUI")]
    [Route("efui")]
    public class EntityFrameworkUIController : Controller
    {
        private IModelMetadataProvider _modelMetadataProvider;
        private IServiceProvider _serviceProvider;

        public EntityFrameworkUIController(IServiceProvider serviceProvider, IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _serviceProvider = serviceProvider;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var dbContextType = DbContextUIRegistrar.DbContexts.ElementAt(0);
            var dbContext = (DbContext) _serviceProvider.GetService(dbContextType);

            var tablesNames = dbContext.Model.GetEntityTypes().Select(e => e.Relational().TableName).ToArray();
            this.ViewBag.TablesNames = tablesNames;

            return View(dbContext.Model.GetEntityTypes().ToArray()[0]);
        }

        [Route("entities/{tableName}/Id",Name = "GetEntity")]
        public async Task<IActionResult> GetEntity(string tableName,[FromQuery]Dictionary<string,string> primaryKey)
        {
            var dbContextType = DbContextUIRegistrar.DbContexts.ElementAt(0);
            var dbContext = (DbContext)_serviceProvider.GetService(dbContextType);
            var entity = dbContext.Model.GetEntityTypes().SingleOrDefault(e => e.Relational().TableName.ToLower() == tableName.ToLower());
            var entityProperties = entity.GetProperties();

            var tablesNames = dbContext.Model.GetEntityTypes().Select(e => e.Relational().TableName).ToArray();
            ViewBag.TablesNames = tablesNames;

            var pk = dbContext.Model.FindEntityType(entity.ClrType).FindPrimaryKey().Properties;

            var keyValues = new object[primaryKey.Count];

            for (var i=0;i<primaryKey.Count;i++)
            {
                var column = pk.Single(q => q.Name == primaryKey.ElementAt(i).Key);
                var converter = TypeDescriptor.GetConverter(column.ClrType);
                if (converter != null)
                {
                    try
                    {
                        keyValues[i] = converter.ConvertFromString(primaryKey.ElementAt(i).Value);
                    }
                    catch
                    {
                        // add you exception handling
                    }
                }
            }

            var record = dbContext.Find(entity.ClrType,keyValues);

            return View();
        }

        [Route("entities/{tableName}")]
        public async Task<IActionResult> EntityList(string tableName)
        {
            var dbContextType = DbContextUIRegistrar.DbContexts.ElementAt(0);
            var dbContext = (DbContext)_serviceProvider.GetService(dbContextType);
            var entity = dbContext.Model.GetEntityTypes().SingleOrDefault(e => e.Relational().TableName.ToLower() == tableName.ToLower());
            var entityProperties = entity.GetProperties();

            var tablesNames = dbContext.Model.GetEntityTypes().Select(e => e.Relational().TableName).ToArray();
            ViewBag.TablesNames = tablesNames;
            ViewBag.TableName = tableName;

            dynamic result = typeof(DbContext).GetMethod("Set").MakeGenericMethod(entity.ClrType).Invoke(dbContext, null);
            var primaryKey = dbContext.Model.FindEntityType(entity.ClrType).FindPrimaryKey().Properties;
            var containerMetadata = _modelMetadataProvider.GetMetadataForType(entity.ClrType);

            var records = Enumerable.ToArray(result);
            var instances = new List<EntityInstance>();

            foreach (var record in records)
            {
                var fields = new List<EntityField>();

                foreach (var entityProperty in entityProperties)
                {
                    var propertyMetadata = containerMetadata.Properties[entityProperty.Name];

                    var schema = new EntityFieldSchema()
                    {
                        IsKey = primaryKey.Any(q=>q==entityProperty),
                        PropertyName = entityProperty.Name,
                        ColumnType = entityProperty.Relational().ColumnType,
                        DisplayName = propertyMetadata.DisplayName,
                        ClrType = entity.ClrType.GetProperty(entityProperty.Name).PropertyType,
                        Description = propertyMetadata.Description
                    };

                    var value = entity.ClrType.GetProperty(entityProperty.Name).GetValue(record, null)?.ToString() as string;

                    fields.Add(new EntityField(schema, value));
                }

                var key = new List<EntityField>();
                foreach (var k in primaryKey)
                {
                    key.Add(fields.Single(q=>q.Schema.PropertyName==k.Name));
                }

                var instance = new EntityInstance(entity, fields.ToArray() , key.ToArray());
                instances.Add(instance);
            }

            return View(instances.ToArray());
        }

        [ValidateAntiForgeryToken]
        [HttpPost,Route("entities/{tableName}")]
        public async Task<IActionResult> NewEntity(string tableName)
        {
            var dbContextType = DbContextUIRegistrar.DbContexts.ElementAt(0);
            var dbContext = (DbContext)_serviceProvider.GetService(dbContextType);
            var entity = dbContext.Model.GetEntityTypes().SingleOrDefault(e => e.Relational().TableName.ToLower() == tableName.ToLower());
            
            var model = Activator.CreateInstance(entity.ClrType);
            await this.TryUpdateModelAsync(model, entity.ClrType,"");

            dbContext.Add(model);
            await dbContext.SaveChangesAsync();

            return View();
        }

    }
}
