using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
            Apartment = new Apartment();
        }

        // 2) Fulde constructor
        public Resident(int id, string firstName, string lastName, string mobile, string email, Apartment apartment)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            Email = email;
            Apartment = apartment;
        }

        public override string ToString()
        {
            return "Booking #" + Id.ToString() + " [" + Apartment.PostalCode.ToString() + "]";
        }
    }

} 
