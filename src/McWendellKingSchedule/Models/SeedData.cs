using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;


namespace McWendellKingSchedule.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Employee.Any() || context.Position.Any() || context.Shift.Any())
            {
                return;   // DB has been seeded
            }

            context.Employee.AddRange(
                 new Employee
                 {
                     UserName = "kbossy",
                     FirstName = "Karen",
                     LastName = "Bossy",
                     DateAdded = DateTime.Parse("2014-03-23"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "cjones",
                     FirstName = "Cassie",
                     LastName = "Jones",
                     DateAdded = DateTime.Parse("2014-07-15"),
                     isActive = true
                 },

                new Employee
                {
                    UserName = "dsmith",
                    FirstName = "David",
                    LastName = "Smith",
                    DateAdded = DateTime.Parse("2015-07-03"),
                    isActive = true
                },

                 new Employee
                 {
                     UserName = "mclair",
                     FirstName = "Marie",
                     LastName = "Clair",
                     DateAdded = DateTime.Parse("2013-11-18"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "jcarter",
                     FirstName = "John",
                     LastName = "Carter",
                     DateAdded = DateTime.Parse("2015-12-01"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "gjungle",
                     FirstName = "George",
                     LastName = "Jungle",
                     DateAdded = DateTime.Parse("2015-06-12"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "jjohns",
                     FirstName = "Jimmy",
                     LastName = "Johns",
                     DateAdded = DateTime.Parse("2016-02-12"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "cbean",
                     FirstName = "Crystal",
                     LastName = "Bean",
                     DateAdded = DateTime.Parse("2013-08-21"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "kdodger",
                     FirstName = "Karen",
                     LastName = "Dodger",
                     DateAdded = DateTime.Parse("2014-05-29"),
                     isActive = true
                 },

                 new Employee
                 {
                     UserName = "jmorone",
                     FirstName = "Jenna",
                     LastName = "Morone",
                     DateAdded = DateTime.Parse("2015-10-29"),
                     isActive = true
                 },

                  new Employee
                  {
                      UserName = "mmcfly",
                      FirstName = "Marty",
                      LastName = "McFly",
                      DateAdded = DateTime.Parse("2012-05-22"),
                      isActive = true
                  },

                 new Employee
                 {
                     UserName = "jpopper",
                     FirstName = "John",
                     LastName = "Popper",
                     DateAdded = DateTime.Parse("2015-04-14"),
                     isActive = true
                 },

                  new Employee
                  {
                      UserName = "mjobber",
                      FirstName = "Mary",
                      LastName = "Jobber",
                      DateAdded = DateTime.Parse("2013-01-31"),
                      isActive = true
                  },

                 new Employee
                 {
                     UserName = "rray",
                     FirstName = "Rachel",
                     LastName = "Ray",
                     DateAdded = DateTime.Parse("2012-11-02"),
                     isActive = true
                 }
            );

            context.Shift.AddRange(
              new Shift
              {
                  ShiftName = "Morning",
                  ShiftDescription = "Breakfast to lunch; full time",
                  ShiftStart = new DateTime(1, 1, 1, 6, 0, 0),
                  ShiftEnd = new DateTime(1, 1, 1, 13, 0, 0),
                  isActive = true
              },

              new Shift
              {
                  ShiftName = "Morning Half",
                  ShiftDescription = "Breakfast; part time",
                  ShiftStart = new DateTime(1, 1, 1, 6, 0, 0),
                  ShiftEnd = new DateTime(1, 1, 1, 10, 0, 0),
                  isActive = true
              },

              new Shift
              {
                  ShiftName = "Lunch",
                  ShiftDescription = "Lunch help; part time",
                  ShiftStart = new DateTime(1, 1, 1, 10, 0, 0),
                  ShiftEnd = new DateTime(1, 1, 1, 14, 0, 0),
                  isActive = true
              },

              new Shift
              {
                  ShiftName = "Evening",
                  ShiftDescription = "Dinner and close; full time",
                  ShiftStart = new DateTime(1, 1, 1, 13, 0, 0),
                  ShiftEnd = new DateTime(1, 1, 1, 21, 0, 0),
                  isActive = true
              }
          );

            context.Position.AddRange(
                new Position
                {
                    PositionName = "Manager",
                    PositionDescription = "Filler; Counts registers; Makes Managerial decisions",
                    isActive = true
                },

                new Position
                {
                    PositionName = "Cashier 1",
                    PositionDescription = "Front counter on cashier 1",
                    isActive = true
                },

                new Position
                {
                    PositionName = "Cashier 2",
                    PositionDescription = "Front counter on cashier 2",
                    isActive = true
                },

                new Position
                {
                    PositionName = "Float",
                    PositionDescription = "Provides help where needed; checks dining room",
                    isActive = true
                },

                new Position
                {
                    PositionName = "Drive Thru",
                    PositionDescription = "Drive Thru",
                    isActive = true
                },

                new Position
                {
                    PositionName = "Grill",
                    PositionDescription = "Fills sandwich orders",
                    isActive = true
                }
              );
           
          
            
            context.SaveChanges();
        }
    }
}


