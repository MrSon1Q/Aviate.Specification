using System.Linq;
using Aviate.Specification.Console.Entities;
using Aviate.Specification.Console.Enums;
using Aviate.Specification.EntityFrameworkCore.Specifications;

namespace Aviate.Specification.Console.Extensions
{
    public static class PersonExtensions
    {
        public static ISpecification<Person> IsRich(this ISpecification<Person> specification) =>
            specification.And(person => person.Salary > 50000);

        public static ISpecification<Person> IsTeenager(this ISpecification<Person> specification) =>
            specification.And(person => person.Age >= 10 && person.Age <= 19);

        public static ISpecification<Person> FromUkraine(this ISpecification<Person> specification) =>
            specification.And(person => person.CountryId == (int) CountryEnum.Ukraine);
        
        public static ISpecification<Person> FromRussian(this ISpecification<Person> specification) =>
            specification.And(person => person.CountryId == (int) CountryEnum.Russian);

        public static ISpecification<Person> WorkInCompany(this ISpecification<Person> specification) =>
            specification.And(person => person.PersonWorks.Any(pw => pw.WorkId == (int) WorkEnum.SomeCompanyName));
    }
}