using Bogus;
using System;

namespace ApiRequestPostProcess.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }

    public enum UserType
    {
        Admin = 1,
        HelpDesk,
        Employee
    }

    public class FakeUser : Faker<User>
    {
        public FakeUser()
        {
            RuleFor(m => m.Id, r => r.Random.Int());
            RuleFor(m => m.FirstName, r => r.Name.FirstName());
            RuleFor(m => m.LastName, r => r.Name.LastName());
            RuleFor(m => m.UserName, r => r.Person.UserName);
            RuleFor(m => m.UserType, r => UserType.Employee);
            RuleFor(m => m.CreatedBy, r => r.Person.UserName);
            RuleFor(m => m.DateUpdated, r => r.Date.Recent());
            RuleFor(m => m.DateCreated, r => r.Date.Recent());
            RuleFor(m => m.UpdatedBy, r => "");
        }
    }
}
