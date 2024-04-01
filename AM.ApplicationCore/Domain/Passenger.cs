using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        [Key]
        public string PassportNumber { get; set; }


        [StringLength(100)]
        public string Photo {  get; set; }


        public FullName FullName { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [DataType(DataType.EmailAddress,ErrorMessage ="email invalide")]
        public string EmailAdress { get; set; }
        //[StringLength (8)]
        public ICollection<Flight> Flights { get; set; }

        [RegularExpression("^[0-9]{8}$")]
        public string PhoneNumber { get; set; }
        //public bool CheckProfile(string prenom,string nom)
        // {
        //     return FirstName.Equals(prenom) && LastName.Equals(nom);
        // }
        public bool CheckProfile(string prenom, string nom, string email = null)
        {
            if (email != null)
                return FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom) && EmailAdress.Equals(email);
            else
                return FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom);

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
