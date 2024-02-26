namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        //public bool CheckProfile(string prenom,string nom)
        // {
        //     return FirstName.Equals(prenom) && LastName.Equals(nom);
        // }
        public bool CheckProfile(string prenom, string nom, string email = null)
        {
            if (email != null)
                return FirstName.Equals(prenom) && LastName.Equals(nom) && EmailAdress.Equals(email);
            else
                return FirstName.Equals(prenom) && LastName.Equals(nom);

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
