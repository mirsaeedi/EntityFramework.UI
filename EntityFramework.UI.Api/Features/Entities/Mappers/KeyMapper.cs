using EntityFramework.UI.Metadata;
using System.Linq;

namespace EntityFramework.UI.Api.Features.Entities.Mappers
{
	public class KeyMapper
	{
		public Key Map(IKey key)
		{
			return new Key
			{
				DeclaringEntityTypeName = key.DeclaringEntityType.Name,
				Properties = new PropertyMapper()
					.Map(key.Properties)
					.ToList()
					.AsReadOnly(),
			};
		}
	}
}
