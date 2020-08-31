namespace Infrastructure
{
    using Scriban;
    using Scriban.Runtime;
    using TemplatingEngine;
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

        //template for using function also
        //var template =@"<ul id='some'>
        //                             {{ for kk in data }}
        //                               <li>
        //                                 <h2>{{ kk.description }}</h2>
        //                                      Price: {{ kk.price }}  {{ kk.Region.RegionName }}
        //                                      {{ kk.description | string.truncate 15 }}
        //                                {{ for jj in kk.Regions }}
        //                                      {{ jj.RegionName }}
        //                                        {{ end }}
        //                               </li>
        //                             {{ end }}
        //                           </ul>
        //                           ";

        // Parse a scriban simple template
        //parser.AddDataToTemplate("name","world");
        //    var result = parser.ParseEmailTemplate("Hello {{name}}!"); // => "Hello World!" 
    }
}
