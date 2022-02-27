using System.Text;

namespace BuilderPatternExample
{
	internal static class Program
	{

		static void Main()
		{
			QueryBuilder builder = new QueryBuilder();  //Different Representations
			//DictBuilder builder = new DictBuilder();  // Different Representations
			ConstructionProcess(builder);
			builder.Build();
		}
		public static void ConstructionProcess(IKeyValueCollectionBuilder builder)
		{
			builder.Add("make", "Suzuki")
				.Add("colour", "Red");
		}

		public interface IKeyValueCollectionBuilder
		{
			IKeyValueCollectionBuilder Add(string key, string value);
		}

		public class QueryBuilder : IKeyValueCollectionBuilder
		{
			private StringBuilder _queryStringBuilder = new StringBuilder();

			public IKeyValueCollectionBuilder Add(string key, string value)
			{
				_queryStringBuilder.Append(_queryStringBuilder.ToString());
				return this;
			}

			public string Build()
			{
				return _queryStringBuilder.ToString();
			}
		}

		

		public class DictBuilder : IKeyValueCollectionBuilder
		{
			private Dictionary<string, string> Dictionary = new Dictionary<string, string>();

			public IKeyValueCollectionBuilder Add(string key, string value)
			{
				Dictionary[key] = value;
				return this;
			}

			public Dictionary<string, string> Build()
			{
				return Dictionary;
			}
		}
	}
}