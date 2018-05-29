using System;
using System.Xml;

namespace FitbitStrava
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlSchemaSet schemas = new XmlSchemaSet();
            //schemas.Add("http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2", @"C:\Users\gmiller\Downloads\TrainingCenterDatabasev2.xsd");

            //XDocument doc = XDocument.Load(@"C:\Users\gmiller\Downloads\14473354610.tcx");

            //string msg = "";

            //doc.Validate(schemas, (o, e) => {
            //    msg += e.Message + Environment.NewLine;
            //});

            //Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);


            var doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(@"C:\Users\Graham\Downloads\14473354610.tcx");

            var nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("g", "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2");

            var nodes = doc.SelectNodes("//g:Trackpoint", nsmgr);
            Console.WriteLine(nodes.Count);

            for (var i = nodes.Count - 1; i >= 0; i = i - 2)
            {
                var node = nodes[i];
                node.ParentNode.RemoveChild(node);
            }

            doc.Save(@"C:\Users\Graham\Downloads\14473354610Abbreviated.tcx");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
