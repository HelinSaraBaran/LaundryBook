using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// class responsible for person and contact info also apartment link
namespace LaundryLibrary.Model
{
    public class Resident
    {
        // our properties 
        public int Id { get; set; } // PK i database
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Apartment Apartment{ get; set; }


        // constructor - parameterløs 
        public Resident()
        {
            this.Id = 0;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Mobile = string.Empty;
            this.Email = string.Empty;
            this.Apartment = new Apartment();
        }

        // 2) Fulde constructor
        public Resident(int id, string firstName, string lastName, string mobile, string email, Apartment apartment)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Mobile = mobile;
            this.Email = email;
            this.Apartment = apartment;
        }
    }
} // Måske skal er tilføjes tostring ?  for fuld navn fornavn + efternavn
