namespace Aviate.Specification.Console.Entities
{
    public class PersonWork
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public int WorkId { get; set; }
        
        public virtual Person Person { get; set; }
        public virtual Work Work { get; set; }
    }
}