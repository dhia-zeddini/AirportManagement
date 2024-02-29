using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //  public int Id { get; set; } 

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [MinLength(3),MaxLength(25,ErrorMessage ="invalid first name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime BirthDate { get; set; }
        [Phone]
       // [RegularExpression(@"^\d{8}$")]
        public int? TelNumber { get; set; }
        // [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate:" + BirthDate
                + "PassportNumber:" + PassportNumber
                + "EmailAdress:" + EmailAddress
                + "FirstName:" + FirstName
                + "LastName:" + LastName
                + "TelNumber:" + TelNumber;
        }

    }
}
