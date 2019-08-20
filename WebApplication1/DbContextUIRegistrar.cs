using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1
{
    public static class DbContextUIRegistrar
    {
        private static readonly List<Type> _dbContexts = new List<Type>();

        public static IReadOnlyCollection<Type> DbContexts => _dbContexts.AsReadOnly();

        public static void Register(Type dbContextType)
        {
            _dbContexts.Add(dbContextType);
        }
    }
}
