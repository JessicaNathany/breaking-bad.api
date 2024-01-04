namespace breaking_bad.domain.Entities
{
    public class Character : Entity
    {
        public Character() { }

        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Name of the Actor who plays the Character
        /// </summary>
        public string NameActor { get; private set; }

        /// <summary>
        /// The status of this character, whether they be living, dead, or unknown
        /// </summary>
        public bool Status { get; private set; }

        /// <summary>
        /// The gender of this character, whether they be Female, Male, Genderless, or Unknown
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// A direct image of this character | 300x300
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// this is the character's profession
        /// </summary>
        public string Job { get; private set; }

        /// <summary>
        /// The episodes in characters
        /// </summary>
        private readonly List<Episode> _episodes = new();

        public IEnumerable<Episode> Episodes => _episodes.AsReadOnly();

        public Character(string name, string nameActor, bool status, string gender, string imageUrl, string job, IEnumerable<Episode> episodes)
        {
            Name = name;
            NameActor = nameActor;
            Status = status;
            Gender = gender;
            ImageUrl = imageUrl;
            Job = job;
            AddEpisodes(episodes);
        }

        public void Update(string name, string nameActor, bool status, string gender, string imageUrl, string job, IEnumerable<Episode> episodes)
        {
            Name = name;
            NameActor = nameActor;
            Status = status;
            Gender = gender;
            ImageUrl = imageUrl;
            Job = job;
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
