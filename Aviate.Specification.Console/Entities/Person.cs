using System.Collections.Generic;

namespace Aviate.Specification.Console.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsBanned { get; set; }
        public bool HasPassport { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<PersonWork> PersonWorks { get; set; }
    }
}