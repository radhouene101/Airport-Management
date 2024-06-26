﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }

        public string Destination { get; set; }

        public string Departure { get; set; }

        public DateTime FlightDate { get; set; }

        public DateTime EffectiveArrival { get; set; }

        public int EstimatedDuration { get; set; }

        public string AirlineLogo { get; set; }

        //objets de navigation
        public virtual Plane Plane { get; set; }

        [ForeignKey("Plane")]
        public int PlaneFk { get; set; }

        //public ICollection<Passenger> Passengers { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }


        public override string ToString()
        {
            return " Departure: " + Departure + " Destination: " + Destination
                + " Flight Date: " + FlightDate;
        }

    }
}
