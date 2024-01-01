using breaking_bad.domain.Entities;
using System.Text.Json.Serialization;

namespace breaking_bad.domain.Responses
{
    public class EpisodeResponse 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AirDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<Character> Characters { get; set; }

        public int SeasonId { get; set; }

        public Season Season { get; set; }
    }
}
