

namespace SitecoreExtentions.Pipeline.Indexing
{
	using Sitecore.ContentSearch;
	using Sitecore.ContentSearch.Pipelines.IndexingFilters;
	public class ApplyInboundIndexVersionFilter : InboundIndexFilterProcessor 
	{
		public override void Process(InboundIndexFilterArgs args)
		{
			var item = args.IndexableToIndex as SitecoreIndexableItem;

			if (!item.Item.Versions.IsLatestVersion())
			{
				args.IsExcluded = true;
			}
		}
	}
}
