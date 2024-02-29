using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethod
    {
        IList<DateTime> GetFlightDates(string des);
        void ShowFlightDetails(Plane plane);
        int ProgrammedVols(DateTime StartDate);
        double DurationAverage(string destination);

        IEnumerable<Flight> OrderedDurationFlights();

        IList<Traveller> SeniorTravellers(Flight flight);

        void DestinationGroupedFlights();


    }
}
