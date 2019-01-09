using System;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.EF
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //ApartmentOwners
            modelBuilder.Entity<ApartmentOwner>().HasData(
                new ApartmentOwner
                {
                    Id = 1,
                    FirstName = "Nikolai",
                    LastName = "Dzymidzei",
                    PhoneNumber = "88005553535",
                    Email = "ne.mogna@gmail.com"
                },
                new ApartmentOwner
                {
                    Id = 2,
                    FirstName = "Viktoriya",
                    LastName = "Rozumskaya",
                    PhoneNumber = "+380976543210",
                    Email = "golova68@gmail.com"
                },
                new ApartmentOwner
                {
                    Id = 3,
                    FirstName = "Pavel",
                    LastName = "Katin",
                    PhoneNumber = "+380668882244",
                    Email = "assembl9r@gmail.com"
                },
                new ApartmentOwner
                {
                    Id = 4,
                    FirstName = "Egor",
                    LastName = "Nikolaev",
                    PhoneNumber = "+380959116923",
                    Email = "goranikonov@gmail.com"
                },
                new ApartmentOwner
                {
                    Id = 5,
                    FirstName = "Ivan",
                    LastName = "Kiryanov",
                    PhoneNumber = "+380971234567",
                    Email = "stepan88@gmail.com"
                }
            );

            //Apartments
            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    Id = 1,
                    ApartmentOwnerId = 1,
                    Address = "Kiev, Kudryashova st. 20",
                    NumberOfRooms = 2,
                    Area = 62.0,
                    Floor = 7,
                    Description =
                        "Proper repair, with furniture and appliances, air conditioning in every room," +
                        "guarded entrance, near Solomensky Park."
                },
                new Apartment
                {
                    Id = 2,
                    ApartmentOwnerId = 2,
                    Address = "Kiev, Turgenevskaya st. 48",
                    NumberOfRooms = 3,
                    Area = 74.5,
                    Floor = 3,
                    Description = "Gas column, balcony, needs repair."
                },
                new Apartment
                {
                    Id = 3,
                    ApartmentOwnerId = 3,
                    Address = "Kiev, Zakrevskogo st. 95",
                    NumberOfRooms = 3,
                    Area = 80.0,
                    Floor = 6,
                    Description = "Floor heating, fireplace (electric), direct transport to the metro."
                },
                new Apartment
                {
                    Id = 4,
                    ApartmentOwnerId = 4,
                    Address = "Kiev, Vasilkovskaya st. 23/16",
                    NumberOfRooms = 2,
                    Area = 57.0,
                    Floor = 2,
                    Description =
                        "Built-in kitchen, stove Bosch, hood Cata. The bathroom has an Electrolux boiler." +
                        "The balcony is glazed. Armored door. Easy parking in the yard. Good infrastructure: metro Vasilkovskaya 300 meters." +
                        "Goloseevsky park 600 meters. Kindergarten near the house. Many supermarkets and shops"
                },
                new Apartment
                {
                    Id = 5,
                    ApartmentOwnerId = 5,
                    Address = "Kiev, Timoshenko st. 13a",
                    NumberOfRooms = 3,
                    Area = 85.0,
                    Floor = 18,
                    Description = ""
                }
            );

            //SaleAnnouncements
            modelBuilder.Entity<SaleAnnouncement>().HasData(
                new SaleAnnouncement
                {
                    Id = 1,
                    ApartmentOwnerId = 1,
                    ApartmentId = 1,
                    Price = 2920000,
                    Status = "On review",
                    CreationDate = new DateTime(2018, 1, 15)
                },
                new SaleAnnouncement
                {
                    Id = 2,
                    ApartmentOwnerId = 2,
                    ApartmentId = 2,
                    Price = 2050000,
                    Status = "On review",
                    CreationDate = new DateTime(2018, 2, 16)
                },
                new SaleAnnouncement
                {
                    Id = 3,
                    ApartmentOwnerId = 3,
                    ApartmentId = 3,
                    Price = 1800000,
                    Status = "On review",
                    CreationDate = new DateTime(2018, 3, 17)
                }
            );

            //RentAnnouncement
            modelBuilder.Entity<RentAnnouncement>().HasData(
                new RentAnnouncement
                {
                    Id = 4,
                    ApartmentOwnerId = 4,
                    ApartmentId = 4,
                    Rent = 9000,
                    TermInDays = 180,
                    Status = "On review",
                    CreationDate = new DateTime(2018, 4, 18)
                },
                new RentAnnouncement
                {
                    Id = 5,
                    ApartmentOwnerId = 5,
                    ApartmentId = 5,
                    Rent = 14000,
                    TermInDays = 365,
                    Status = "On review",
                    CreationDate = new DateTime(2018, 5, 19)
                }
            );
        }
    }
}
