using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{

    public class FlightMethod : IFlightMethod
    {
        IList<Flight> Flights = new List<Flight>();

  

        public IList<DateTime> GetFlightDates(string des)
        {

            //Foreach
            // IList<DateTime > result = new List<DateTime>();
            //foreach (var x in Flights) { 
            //     if (x.Destination.Equals(des))
            //     {
            //         result.Add(x.FlightDate);
            //     }

            // }
            // return result;
            var query = from a in Flights // ( instance = a in source = Flights , a = Flight)
                        where a.Destination == des // ( condition)
                        select a.FlightDate; // ( retour)
            return query.ToList();

            //Linq : langage de req couplé entre C# et SQL 
            /*
             * Var query = from instance ( x) in Collection = Flights ( x= flight)
             *             where condition x.Destination == des 
             *             select   x.FlightDate; 
             *return  query ;
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */

        }


        public int ProgrammedVols(DateTime StartDate) {
            var query = from a in Flights
                        where (a.FlightDate - StartDate).TotalDays <= 7
                        select a;
            return query.Count();
        
        }

        /* 
         public int ProgrammedVols(DateTime StartDate) {
                 return Flights
                            .Count(a => (a.FlightDate - startDate).TotalDays <= 7);        
        
      }
         */

        public void ShowFlightDetails(Plane plane)
        {
            var query = Flights
                        .Where(f => f.Plane.Equals(plane))
                        .Select(f => new { f.Destination, f.FlightDate });

            foreach (var item in query)
            {
                Console.WriteLine($"Destination: {item.Destination}, Flight Date: {item.FlightDate}");

               
            }
        }

        public double DurationAverage(string dest)
        {
            return Flights
                        .Where(f => f.Destination == dest)
                        .Select(f => f.EstimatedDuration)
                        .Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            return Flights
                        .OrderByDescending(f => f.EstimatedDuration)
                        .ToList();
        }

        /*
         public IEnumerable<Flight> OrderedDurationFlights()
                {
                    var query = from f in Flights
                                orderby f.EstimatedDuration descending
                                select f;

                    return query.ToList();
                }

         */

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers
                        .OfType<Traveller>()
                        .OrderBy(t=>t.BirthDate)
                        .Take(3)
                        .ToList();    
        }

        public void DestinationGroupedFlights()
        {
            var groupflights = Flights
                .GroupBy(f => f.Destination)
                .OrderBy(comparer => comparer.Key);

            foreach (var destination in groupflights)
            {
                Console.WriteLine($"Destination {destination.Key}");

                foreach (var flight in destination.OrderBy(f => f.EffectiveArrival))
                {
                    Console.WriteLine($"Décollage : {flight.EffectiveArrival}");
                }
            }
        }
    }
}
