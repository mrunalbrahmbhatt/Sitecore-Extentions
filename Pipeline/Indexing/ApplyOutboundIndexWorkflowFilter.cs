
using Sitecore.ContentSearch.Pipelines.IndexingFilters;
using Sitecore.Data;
namespace SitecoreExtentions.Pipeline.Indexing
{
	public class ApplyOutboundIndexWorkflowFilter : OutboundIndexFilterProcessor
	{
		public override void Process(OutboundIndexFilterArgs args)
		{
			if (args.IndexableUniqueId == null)
			{
				return;
			}

			if (args.IndexableDataSource == "sitecore")
			{
				var itemUri = new ItemUri(args.IndexableUniqueId);
				var database = Sitecore.Context.Database;
				//database.GetItem(itemUri.ItemID)
				var workflow = database.WorkflowProvider.GetWorkflow(database.GetItem(itemUri.ItemID));

				if (!workflow.IsApproved(database.GetItem(itemUri.ItemID)))
				{
					args.IsExcluded = true;
				}
			}
		}
	}
}
