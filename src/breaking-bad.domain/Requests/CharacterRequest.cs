using breaking_bad.domain.Entities;

namespace breaking_bad.domain.Requests
{
    public class CharacterRequest
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string NameActor { get; set; }

        public bool Status { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        public string Job { get; set; }

        public List<Episode> Episodes { get; set; }   
    }
}
