using DAF.Assesment.Flights.Core.Entities;
using DAF.Assesment.Flights.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAF.Assesment.Flights.BackgroundWorker.DataOperation
{
    public class Datalayer
    {
        private string _connectionString;

        public Datalayer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int BulkInsertFlights(List<Flight> flights)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.BackgroundWorker.FlightInsertStoredProcedure; // Name of the stored procedure

            // Create and populate DataTable
            DataTable flightTable = new();
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.AirportId, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.FlightName, typeof(string));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.FirstSeenUnixTimeStamp, typeof(long));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstDepartureAirport, typeof(string));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.LastSeenUnixTimeStamp, typeof(long));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstArrivalAirport, typeof(string));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.Callsign, typeof(string));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstDepartureAirportHorizDistance, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstDepartureAirportVertDistance, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstArrivalAirportHorizDistance, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.EstArrivalAirportVertDistance, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.DepartureAirportCandidatesCount, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.ArrivalAirportCandidatesCount, typeof(int));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.FirstSeen, typeof(DateTime));
            flightTable.Columns.Add(Constants.BackgroundWorker.FlightDataTable.LastSeen, typeof(DateTime));

            foreach (Flight flight in flights)
            {
                flightTable.Rows.Add(
                    flight.AirportId,
                    flight.FlightName,
                    flight.FirstSeenUnixTimeStamp,
                    flight.EstDepartureAirport,
                    flight.LastSeenUnixTimeStamp,
                    flight.EstArrivalAirport,
                    flight.Callsign,
                    flight.EstDepartureAirportHorizDistance,
                    flight.EstDepartureAirportVertDistance,
                    flight.EstArrivalAirportHorizDistance,
                    flight.EstArrivalAirportVertDistance,
                    flight.DepartureAirportCandidatesCount,
                    flight.ArrivalAirportCandidatesCount,
                    flight.FirstSeen,
                    flight.LastSeen
                );
            }

            // Add table-valued parameter
            SqlParameter parameter = command.Parameters.AddWithValue(Constants.BackgroundWorker.FlightInsertStoredProcedureParameter, flightTable);
            parameter.SqlDbType = SqlDbType.Structured;

            var exRes = command.ExecuteNonQuery();
            return exRes;
        }
    }
}
