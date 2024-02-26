﻿namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }
        public DateTime EmploymentDate { get; set; }
        public double Salary { get; set; }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff");
        }
    }
}
