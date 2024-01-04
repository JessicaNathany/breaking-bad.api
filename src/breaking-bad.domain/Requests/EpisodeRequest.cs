using breaking_bad.domain.Entities;

namespace breaking_bad.domain.Requests
{
    public class EpisodeRequest
    {
        public int Id { get; set; }

        public Guid Code { get; set; }

        public string Name { get; set; }

        public DateTime AirDate { get; set; }

        public string Description { get; set; }

        public List<Character> _characters { get; set; }

        public int SeasonId { get; set; }

        public Season Season { get; set; }
    }
}
