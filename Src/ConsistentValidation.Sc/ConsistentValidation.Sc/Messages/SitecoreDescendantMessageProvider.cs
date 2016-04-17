using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using Sitecore.Configuration;
using Sitecore.Data;

namespace ConsistentValidation.Sc.Messages
{
    public class SitecoreDescendantMessageProvider : IMessageProvider
    {
        private readonly Database _db;
        private readonly string _messagesRootPath;
        private readonly string _messageFieldName;

        public SitecoreDescendantMessageProvider(string messagesRootPath, string database, string messageFieldName)
        {
            _messagesRootPath = messagesRootPath;
            _messageFieldName = messageFieldName;

            _db = Factory.GetDatabase(database);
        }

        public string GetMessageFor(IValidationRuleData ruleData)
        {
            var query = _messagesRootPath.TrimEnd('/') + "//*[@@Name = '" + ruleData.MessageId+ "']";

            var item = _db.SelectSingleItem(query);

            return item[_messageFieldName];
        }
    }
}