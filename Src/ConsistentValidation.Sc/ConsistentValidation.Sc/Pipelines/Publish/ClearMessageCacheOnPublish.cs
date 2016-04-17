using Sitecore.Publishing.Pipelines.Publish;

namespace ConsistentValidation.Sc.Pipelines.Publish
{
    /// <summary>
    /// This clears the message cache when a Sitecore item is published.
    /// </summary>
    /// <remarks>Add <processor type="ConsistentValidation.Sc.Pipelines.Publish.ClearMessageCacheOnPublish,ConsistentValidation.Sc" /> to the 'publish' pipeline.</remarks>
    public class ClearMessageCacheOnPublish : PublishProcessor
    {
        public override void Process(PublishContext context)
        {
            Configuration.MessageCache.ClearCache();
        }
    }
}