using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TestAutomationCourse.Exercises.e04.XML
{
    internal class CD_CatalogTests
    {
        //method1
        private XmlDocument xDoc;

        //method2
        //private XDocument xDoc;

        [SetUp]
        public void Setup()
        {
            //method1
            xDoc = new XmlDocument();
            xDoc.Load(".//Exercises//e04.Xml//CD_Catalog.xml");

            //method2
            //xDoc = new XDocument();
            //xDoc = XDocument.Load(".\\Exercises\\e04.XML\\CD_Catalog.xml");

        }

        [Test]  
        public void total_price_of_all_CDs()
        {
            //method1

            XmlNodeList cd = xDoc.GetElementsByTagName("CD");
            double total = 0;
            foreach (XmlNode cdNode in cd)
            {
                string cost = cdNode.ChildNodes.Item(4).InnerText;
                double price;
                Double.TryParse(cost, out price);
                total += price;
            }


            //method2

            //var cd = xDoc.Root.Elements("CD").Elements("PRICE");
            //double total = 0;
            //foreach (XElement item in cd)
            //{
            //    double price;
            //    Double.TryParse(item.Value, out price);
            //    total += price;
            //}
            Assert.AreNotEqual(0,total); 
        }

        [Test]
        public void all_CDs_older_than_1987()
        {
            //method1
            XmlNodeList cd = xDoc.GetElementsByTagName("CD");
            double worth = 0;

            foreach (XmlNode cdNode in cd)
            {
                if (int.Parse(cdNode.ChildNodes.Item(5).InnerText) < 1987)
                {
                    string cost = cdNode.ChildNodes.Item(4).InnerText;
                    
                    worth += Double.Parse(cost);
                }
            }

            //method2
            //double worth = xDoc.Root.Elements("CD").Where(w => int.Parse( w.Element("YEAR").Value) < 1987).Sum(a => Double.Parse( a.Element("PRICE").Value) );

            Assert.AreNotEqual(0, worth);
        }
    }
}
