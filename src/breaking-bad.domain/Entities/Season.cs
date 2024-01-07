namespace breaking_bad.domain.Entities
{
    public class Season : Entity
    {
        public Season() { }

        /// <summary>
        /// Name of the season
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// AirDate of the season
        /// </summary>
        public DateTime AirDate { get; private set; }

        /// <summary>
        /// Description of the season
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The episodes of the season
        /// </summary>
        private readonly List<Episode> _episodes = new();

        public IEnumerable<Episode> Episodes => _episodes.AsReadOnly();

        public Season(string name, DateTime airDate, string description, IEnumerable<Episode> episodes)
        {
            Name = name;    
            AirDate = airDate;
            Description = description;
            AddEpisodes(episodes);
        }

        public void Update(string name, DateTime airDate, string description, IEnumerable<Episode> episodes)
        {
            Name = name;
            AirDate = airDate;
            Description = description;
            ChangeEpisodes(episodes);
        }

        public void ChangeEpisodes(IEnumerable<Episode> characters)
        {
            _episodes.Clear();
            _episodes.AddRange(characters);
        }

        public void AddEpisodes(IEnumerable<Episode> episodes) => _episodes.AddRange(episodes);
    }
}
