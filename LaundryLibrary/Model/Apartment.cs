using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class responsible for representing address and apartment identity for a resident

namespace LaundryLibrary.Model
{
    public class Apartment
    {
        // Our Properties 
       public string City { get; set; } // By 
        public int Floor { get; set; } // Etage
        public string StreetAndNumber { get; set; } // Gade nr
        public string PostalCode { get; set; } // Post nr
        public string ApartmentLetter { get; set; } // Lejligheds nr (A til Å) 
        public string AddressLine {  get; set; } // fulde adresse 

        // Constructor  - Uden parameter - Regler i service laget
        public Apartment()
        { 
            this.City = string.Empty;
            this.Floor = 0;
            this.StreetAndNumber = string.Empty;
            this.PostalCode = string.Empty;
            this.ApartmentLetter = "A";
            this.AddressLine = string.Empty;
        }

        // Full constructor 
        public Apartment(string city, int floor, string streetAndNumber, string postalCode, string appartmentLetter, string addressLine)
        {  // Her er 'this' vores aktuelle instans
            this.City = city;
            this.Floor = floor;
            this.StreetAndNumber = streetAndNumber;
            this.PostalCode = postalCode;
            this.ApartmentLetter = appartmentLetter;
            this.AddressLine = addressLine;
        }



        // Hjælpe metode - Metoden returnerer lejlighedskoden i etage + bogstav ved en kombination af floor og apartmentletter
        public string GetApartmentCode()
        {
            return this.Floor.ToString() + "." + this.ApartmentLetter.ToUpperInvariant();
        }

        // Override metode 
        public override string ToString()
        {
            return this.StreetAndNumber + "," + this.PostalCode + "" + this.City +"(" + this.GetApartmentCode() + ")";
        }
    }
}
