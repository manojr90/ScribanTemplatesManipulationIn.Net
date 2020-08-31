namespace TemplatingEngine
{
    using Scriban;
    using Scriban.Runtime;
    public class EmailParser : IEmailParser
    {
        private ScriptObject scriptObject;
        private TemplateContext context;

        public EmailParser()
        {
            scriptObject = new ScriptObject();
            context = new TemplateContext { MemberRenamer = member => member.Name };
        }
        public void AddDataToTemplate(string key, object value)
        {
            scriptObject.Add(key, value);
            context.PushGlobal(scriptObject);
        }

        public string ParseEmailTemplate(string template)
        {
            var parsedTemplate = Template.Parse(template);
            var result = parsedTemplate.Render(context);

            return result;
        }
    }
}
