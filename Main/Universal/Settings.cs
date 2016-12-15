using System.Threading.Tasks;

namespace Universal
{

    public enum Place
    {
        Kitchen, Pub
    }

    public struct Settings
    {
        public Place Place { get; set; }
        public static async Task<Settings> Load(string file="")
        {
            return new Settings { Place = Place.Kitchen };
        }
    }
}
