using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


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

      
        // Full constructor 
        public Apartment(string city, int floor, string streetAndNumber, string postalCode, string appartmentLetter, string addressLine)
        {  
            City = city;
            Floor = floor;
            StreetAndNumber = streetAndNumber;
            PostalCode = postalCode;
            ApartmentLetter = appartmentLetter;
            AddressLine = addressLine;
        }



        // Hjælpe metode - Metoden returnerer lejlighedskoden i etage + bogstav ved en kombination af floor og apartmentletter
        public string GetApartmentCode()
        {
            return Floor.ToString() + "." + ApartmentLetter.ToUpperInvariant();
        }

        // Override metode 
        public override string ToString()
        {
            return StreetAndNumber + "," + PostalCode + "" + City +"(" + GetApartmentCode() + ")";
        }
    }
}
