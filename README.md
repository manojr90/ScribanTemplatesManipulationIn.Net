# ScribanTemplatesManipulationIn.Net
Creating Dynamic Email templates with Scriban in .Net Core

#Seding dynamic email Content
Scriban templates gives flexibilty to manipulate html in same way we do in Angular/razor, by providing interpolation syntaxes {{}} like this.
Here we could place out C# code which could be replaced by data we want to place on the HTML Templates.


This is the basic console project which is placing dynamic content in  HTML templates with data provided through .Net core. 

Simple Example:-

// Parse a scriban template
var template = Template.Parse("Hello {{name}}!");
var result = template.Render(new { Name = "World" }); // => "Hello World!" 

More on Scriban 

# https://github.com/lunet-io/scriban
