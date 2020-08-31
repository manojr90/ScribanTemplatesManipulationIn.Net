using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TemplatingEngine
{
    class Program
    {
        class ReportEvent
        {
            public string Heading { get; set; }

            public string Subheading { get; set; }

            public List<ProductItem> Products { get; set; }

            public LocalisedData LocalisedData { get; set; }

        }

        class ProductItem
        {
            public string Product { get; set; }

            public string Region { get; set; }

            public IEnumerable<Report> Reports { get; set; }
        }

        class Report
        {
            public string name { get; set; }
        }

        class LocalisedData
        {
            public string key { get; set; }

            public string value { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("**Parsing Email Template with C#-and scriban with liqud syntax ***");
            Console.WriteLine();
            Console.WriteLine("It will parse this template:-");
            Console.WriteLine();
            var template = @" <table>
  <tr>
     <th>{{data.Heading}}</th>
     <th>{{date.now | date.to_string `%d %b %Y at %R` `en-US`}}</th>
 </tr>
 {{ for productItem in data.Products }}
 <tr>
   <td>
        <table>
          <tr>
            <th>{{ productItem.Product }}</th>
          </tr>
         <tr>
            {{ for report in productItem.Reports }}
             <td>
             {{ report.name }}
             </ td >
             {{ end }}
           </ tr >
        </table>
         
   </td>
 </tr>
 {{ end }}
  </table>
                                       ";

            Console.WriteLine(template);
            Console.WriteLine();
            Console.WriteLine("With This Data");
            Console.WriteLine();

            var data = getData();

            Dump(data);

            Console.WriteLine();
            Console.WriteLine("**To**");
            Console.WriteLine("Press Any Key to Find:");
            var val = Console.ReadLine();

            IEmailParser parser = new EmailParser();

            parser.AddDataToTemplate("data", data);
            var result = parser.ParseEmailTemplate(template);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static ReportEvent getData()
        {
            var products = new List<ProductItem>()
            {
               
                new ProductItem() { Product = "Product1", Region="Asia" ,Reports= new List<Report>(){ new Report() { name="Report1"} } },
                new ProductItem() { Product = "Product2", Region="Asia" ,Reports= new List<Report>(){ new Report() { name="Report2"} } },
            };

            var localizedData = new LocalisedData() { key = "test", value = "value" };

            var reportEvent = new ReportEvent
            {
                Heading = "ReportEventHeading",
                Subheading = "ReportEventSubHeading",
                Products = products,
                LocalisedData = localizedData
            };

            var data = reportEvent;

            return data;
        }

        private static void Dump(object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
