using System.Linq;
using Aviate.Specification.Console.Entities;
using Aviate.Specification.Console.Extensions;
using Aviate.Specification.EntityFrameworkCore.Factories;
using Aviate.Specification.EntityFrameworkCore.Extensions;
using static System.Console;

namespace Aviate.Specification.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var factory = new SpecificationFactory();
                
                var query = context.Persons.AsQueryable();

                var specification = factory.Create<Person>()
                    .FromUkraine()
                    .WorkInCompany();

                var persons = context.Persons.Where(specification);

                foreach (var person in persons)
                {
                    WriteLine($"Id: {person.Id}, firstName: {person.FirstName}, lastName: {person.LastName}, salary: {person.Salary}");
                }

                ReadLine();
            }
        }
    }
}