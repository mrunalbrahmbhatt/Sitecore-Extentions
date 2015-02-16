using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Pipelines.IndexingFilters;
namespace SitecoreExtentions.Pipeline.Indexing
{
	public class ApplyInboundIndexStandardValuesFilter : InboundIndexFilterProcessor 
	{
		public override void Process(InboundIndexFilterArgs args)
		{
			var item = args.IndexableToIndex as SitecoreIndexableItem;

			if (item.Item.Name == "__Standard Values")
			{
				args.IsExcluded = true;
			}
		}
	}
}
