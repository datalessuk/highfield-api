using System;
using System.Collections.Generic;

namespace highfield_backend.Tests.TestData
{
    public static class PeopleTestData
    {
        public static List<Person> GetSamplePeople(){
            return new List<Person>
            {
                new Person
                 {
                    Id = "00b63c59-d6df-4531-b5aa-eb41e081a54d",
                    FirstName = "Lucy",
                    LastName = "Arnaudon",
                    Email = "larnaudonov@arstechnica.com",
                    Dob = new DateTime(1925, 5, 22),
                    FavouriteColour = "Mauv"
                },
                new Person
                {
                    Id = "00c16c9c-6a7f-452d-be8b-90186a632d83",
                    FirstName = "Jerrie",
                    LastName = "Rothwell",
                    Email = "jrothwell6o@icq.com",
                    Dob = new DateTime(1902, 7, 2),
                    FavouriteColour = "Indigo"
                },
                new Person
                {
                    Id = "01126758-1990-43a1-b847-9e9017b58266",
                    FirstName = "Carter",
                    LastName = "Chatto",
                    Email = "cchattokv@businesswire.com",
                    Dob = new DateTime(1980, 11, 9),
                    FavouriteColour = "Goldenrod"
                },
                new Person
                {
                    Id = "01268fc5-738a-459b-9d47-d73107be7da6",
                    FirstName = "Broderic",
                    LastName = "Shilston",
                    Email = "bshilston8o@chron.com",
                    Dob = new DateTime(1950, 6, 5),
                    FavouriteColour = "Aquamarine"
                },
                new Person
                {
                    Id = "0137c1f8-b0f6-4ab3-afa0-c5d9110cdef6",
                    FirstName = "Gregor",
                    LastName = "Sadat",
                    Email = "gsadatdx@ameblo.jp",
                    Dob = new DateTime(1945, 12, 10),
                    FavouriteColour = "Teal"
                },
                new Person
                {
                    Id = "01625c3c-d6e6-404e-88f3-8ec5f8aa6970",
                    FirstName = "Berkie",
                    LastName = "Papes",
                    Email = "bpapeslm@nytimes.com",
                    Dob = new DateTime(1942, 12, 22),
                    FavouriteColour = "Crimson"
                },
                new Person
                {
                    Id = "0198713f-e93c-4bcf-8c3e-339eb130fb52",
                    FirstName = "Kenyon",
                    LastName = "Doorly",
                    Email = "kdoorlygs@shareasale.com",
                    Dob = new DateTime(1921, 3, 6),
                    FavouriteColour = "Violet"
                },
                new Person
                {
                    Id = "01e64d68-5525-43f3-b42f-12bef124010f",
                    FirstName = "Katy",
                    LastName = "Snugg",
                    Email = "ksnugg8u@guardian.co.uk",
                    Dob = new DateTime(1975, 3, 13),
                    FavouriteColour = "Mauv"
                },
                new Person
                {
                    Id = "01fdabed-ada3-4fa0-a743-e8c76eef3cd7",
                    FirstName = "Oralia",
                    LastName = "Wenderott",
                    Email = "owenderott6g@dedecms.com",
                    Dob = new DateTime(1979, 1, 23),
                    FavouriteColour = "Purple"
                },
                new Person
                {
                    Id = "020e79fa-d27e-4c48-8038-043144d0732e",
                    FirstName = "Derek",
                    LastName = "Gomar",
                    Email = "dgomarhj@wiley.com",
                    Dob = new DateTime(1923, 1, 22),
                    FavouriteColour = "Indigo"
                }
            
            };
        }

    }

  
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string FavouriteColour { get; set; }
    }
}
