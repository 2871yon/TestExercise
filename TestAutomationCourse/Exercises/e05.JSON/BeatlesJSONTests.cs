using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Exercises.e05.JSON
{
    [TestFixture]
    internal class BeatlesJSONTests
    {
        private JToken jsonBeatles;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(".//Exercises//e05.JSON//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader);
            }
        }

        [Test]
        public void There_are_four_artists()
        {
            var betales = jsonBeatles["Beatles"];
            JArray artists = (JArray)betales["Artists"];
            Assert.That(artists.Count, Is.EqualTo(4));
        }

        [Test]
        public void two_are_dead_and_two_are_alive()
        {
            var betales = jsonBeatles["Beatles"];
            JArray artists = (JArray)betales["Artists"];
            int y = 0, n = 0;
            for (int i = 0; i < artists.Count; i++)
            { 
                var corent_artist = artists[i];
                if ((string)corent_artist["IsAlive"] == "Yes")
                    y++;
                else if ((string)corent_artist["IsAlive"] == "No")
                    n++;
            }
            Assert.That(n, Is.EqualTo(2));

            Assert.That(y, Is.EqualTo(2));
        }

        [Test]
        public void ringo_plays_drums()
        {
            
            var betales = jsonBeatles["Beatles"];
            JArray artists = (JArray)betales["Artists"];
            bool b=false;
            for (int i = 0; i < artists.Count; i++)
            {
                var corent_artist = artists[i];
                if ((string)corent_artist["Name"] == "Ringo Starr" && (string)corent_artist["Plays"] == "Drums")
                  b = true;    
            }
            Assert.That(b, Is.EqualTo(true)); 
           
        }

    }
}
