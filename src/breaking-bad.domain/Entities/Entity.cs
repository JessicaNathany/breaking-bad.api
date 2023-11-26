namespace breaking_bad.domain.Entities
{
    public class Entity
    {
        protected Entity()
        {
            Code = Guid.NewGuid();
        }
        public int Id { get; set; }

        public Guid Code { get; set; }
    }
}
