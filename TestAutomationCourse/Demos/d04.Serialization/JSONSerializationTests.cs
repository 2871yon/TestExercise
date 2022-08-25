using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class JSONSerializationTests
    {
        [Test]
        public void There_are_four_artists()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            Album album = JsonConvert.DeserializeObject<Album>
                (json);
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            Album album = JsonConvert.DeserializeObject<Album>
                (json);
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            Album album = JsonConvert.DeserializeObject<Album>
                (json);

            bool isDrumes = false;
            for (int i = 0; i < album.beatles.artists.Length; i++)
            {
                if (album.beatles.artists[i].name == "Ringo Starr" && album.beatles.artists[i].plays == "Drums")
                    isDrumes = true;
            }

            Assert.That(isDrumes, Is.EqualTo(true));
        }

    }
}
