using System.Collections.Generic;

namespace Aviate.Specification.Console.Entities
{
    public class Work
    {
        public int Id { get; set; }
        public string Company { get; set; }
        
        public virtual ICollection<PersonWork> PersonWorks { get; set; }
    }
}