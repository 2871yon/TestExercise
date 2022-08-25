using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.Xml
{
    internal class BeatlesXMLTests
    {
        private XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            //XmlDocument doc = new XmlDocument();
             doc=new XmlDocument(); 
            doc.Load(".//Exercises//e04.Xml//Beatles.xml");

        }

        [Test]
        public void There_are_four_artists()
        {
            int num_artists = doc.GetElementsByTagName("Artist").Count;
            Assert.That(num_artists, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            int y = 0, n = 0;
            //XmlDocument doc = new XmlDocument();
            //doc.Load(".//Exercises//e04.Xml//Beatles.xml");
            XmlNodeList xmlNodeList = doc.GetElementsByTagName("Artist");
            for (int i = 0; i < xmlNodeList.Count; i++)
                if (xmlNodeList.Item(i).ChildNodes.Item(1).InnerText == "Yes")
                    y++;
                else if (xmlNodeList.Item(i).ChildNodes.Item(1).InnerText == "No")

                    n++;

            Assert.That(n, Is.EqualTo(2));
            Assert.That(y, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(".//Exercises//e04.Xml//Beatles.xml");
            XmlNodeList xmlNodeList = doc.GetElementsByTagName("Artist");
            bool is_plays_drums=false;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                var corent_artists_element=xmlNodeList.Item(i); 
                string name_artists= corent_artists_element.Attributes.Item(0).InnerText;
                
                if (name_artists== "Ringo Starr" && corent_artists_element.ChildNodes.Item(0).InnerText== "Drums")
                    is_plays_drums=true;    
            }
            Assert.That(is_plays_drums,Is.EqualTo(true));
        }

    }
}
