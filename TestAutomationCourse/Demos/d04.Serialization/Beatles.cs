using System.Collections.Generic;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    public class Album
    {
        public Beatles beatles;
    }

    public class Beatles
    {
        public Artist[] artists;

        public bool isDrumes()
        {
            bool isDrumes = false;
            for (int i = 0; i < artists.Length; i++)
            {
                if (artists[i].name == "Ringo Starr" && artists[i].plays == "Drums")
                isDrumes = true;    
            }
            return isDrumes;
        }
    }

    public class Artist
    {
        public string name { get; set; }
        public string plays { get; set; }
        public string isAlive { get; set; }
    }
}