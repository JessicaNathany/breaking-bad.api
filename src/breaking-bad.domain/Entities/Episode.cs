namespace breaking_bad.domain.Entities
{
    public class Episode : Entity
    {
        public Episode(string episodeName, string description, DateTime airDate, Season season, IEnumerable<Character> characters)
        {
            Name = episodeName;
            Description = description;
            AirDate = airDate;
            Season = season;
            AddCharacters(characters);
        }

        /// <summary>
        /// The name of the episode
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// When this Episode aired 
        /// </summary>
        public DateTime AirDate { get; private set; }

        /// <summary>
        /// The description of the episode
        /// </summary>
        public string Description { get; private set; }

        private readonly List<Character> _characters = new();

        /// <summary>
        /// The characters seen in this episode.
        /// </summary>
        public IEnumerable<Character> Characters => _characters.AsReadOnly();

        /// <summary>
        /// Id the Season episode.
        /// </summary>
        public int SeasonId { get; private set; }

        /// <summary>
        /// The season seen in this episode.
        /// </summary>
        public Season Season { get; private set; }

        public void ChangeInfo(string name, string description, DateTime airDate, Season season)
        {
            Name = name;
            Description = description;
            AirDate = airDate;
            Season = season;
        }

        public void ChangeCharacters(IEnumerable<Character> characters)
        {
            _characters.Clear();
            _characters.AddRange(characters);
        }

        public void AddCharacters(IEnumerable<Character> characters) => _characters.AddRange(characters);
    }
}
