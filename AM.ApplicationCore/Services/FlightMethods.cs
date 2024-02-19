using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods:IFlightMethods
    {
      public List<Flight> Flights=new List<Flight>();
      public List<Flight> FlightDetailsDel;
      public Func<string, double> DurtationDetails;
      public FlightMethods()
      {
          //FlightDetailsDel =
          DurtationDetails = dest =>
          {
              var req = from f in Flights
                  where f.Destination == dest
                  select f.EstimatedDuration;
              return req.Average();
          } ;
      }
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach(Flight f in Flights)
            {
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);
            }
            return dates;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                        foreach(Flight f in Flights)
                        if(f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure.Equals(filterValue))
                            Console.WriteLine(f);
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate.Equals(DateTime.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration.Equals(int.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                default: Console.WriteLine("Filtre introuvable");
                    break;

            }
        }

        public List<DateTime> GetFlightDestination(string destination)
        {
            List<DateTime> leList = (from f in Flights
                where f.Destination == destination
                select f.FlightDate).ToList();
            return leList;
        }

        public int PlannedFlightPerWeek(DateTime startDate)
        {
            var req = (from f in Flights
                where
                    (f.FlightDate - startDate  ).TotalDays< 7 && (f.FlightDate - startDate  ).TotalDays>0
                select f);
            return req.Count();
        }
        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                where f.Destination == destination
                select f.EstimatedDuration;
            return req.Average();
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {
            var req = from t in f.Passengers.OfType<Traveller>()
                orderby t.BirthDate
                select t;
            return req.Take(3);
        }
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                group f by f.Destination;
            foreach (var v in req){
                Console.WriteLine(v.Key);
                foreach (var f in v)
                {
                    Console.WriteLine(f);
                }
                {
                    
                }
            }
            return req;
        }

    }
}
