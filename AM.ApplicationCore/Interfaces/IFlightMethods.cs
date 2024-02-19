using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
       List<DateTime> GetFlightDates(string destination);
       void GetFlights(string filterType, string filterValue);
       public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();

    }
    
}
