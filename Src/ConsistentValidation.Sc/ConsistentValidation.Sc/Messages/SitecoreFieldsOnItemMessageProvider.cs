using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using Sitecore.Configuration;
using Sitecore.Data;

namespace ConsistentValidation.Sc.Messages
{
    public class SitecoreFieldsOnItemMessageProvider : IMessageProvider
    {
        private readonly Database _db;
        private readonly string _messagesPath;

        public SitecoreFieldsOnItemMessageProvider(string messagesPath, string database)
        {
            _messagesPath = messagesPath;

            _db = Factory.GetDatabase(database);
        }

        public string GetMessageFor(IValidationRuleData ruleData)
        {
            var query = _messagesPath;

            var item = _db.SelectSingleItem(query);

            return item[ruleData.MessageId];
        }
    }
}