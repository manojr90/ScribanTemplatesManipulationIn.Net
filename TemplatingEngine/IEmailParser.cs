namespace TemplatingEngine
{
    public interface IEmailParser
    {
        string ParseEmailTemplate(string template);
        void AddDataToTemplate(string key, object value);
    }
}
