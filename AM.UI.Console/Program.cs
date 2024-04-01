// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
//création d'un objet à travers le constructeur par défaut
Plane p = new Plane();
p.Capacity = 100;
Console.WriteLine(p.Capacity);
p.ManufactureDate = DateTime.Now;
p.PlaneType = PlaneType.Boeing;

//Flight f = new Flight("Paris","Tunis",new DateTime(2024,10,3,12,1,1)
//    , new DateTime(2024, 10, 3, 13, 1, 1),120);
//création d'un objet à travers l'initialiseur d'objets
Flight f = new Flight()
{
    Departure = "Tunis",
    Destination = "Paris",
    EstimatedDuration = 120,
    FlightDate = new DateTime(2024, 10, 3, 12, 1, 1),
    EffectiveArrival = new DateTime(2024, 10, 3, 13, 1, 1)
};
//ToString
Console.WriteLine(f);
Console.WriteLine("*****CheckProfile*******");
Passenger p1 = new Passenger()
{
    FullName = new FullName { FirstName = "amina", LastName = "aoun" },
    EmailAdress = "amina.aoun@esprit.tn"
};
Console.WriteLine(p1.CheckProfile("Amina", "Aoun"));
Console.WriteLine(p1.CheckProfile("Amina", "Aoun", "a.gmail"));
Console.WriteLine("**********Passenger Type********");
Staff s1 = new Staff();
Traveller t1 = new Traveller();
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();
FlightMethods fm = new FlightMethods();
Console.WriteLine("**********GetFlightDates********");
fm.Flights = TestData.listFlights;
foreach (DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);
Console.WriteLine("**********GetFlights********");
fm.GetFlights("EstimatedDuration", "105");
Console.WriteLine("#########PlannedFlights##############");
Console.WriteLine(fm.PlannedFlightPerWeek(new DateTime(2021, 12, 31)));
Console.WriteLine("##############Duration Average#######");
Console.WriteLine(fm.DurationAverage("Madrid"));

Console.WriteLine("#####Senior Traveller#####");
foreach (Traveller t in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(t.BirthDate);
}

Console.WriteLine("########DESTINATIONS GROUPED##########");
fm.DestinationGroupedFlights();
{

}
{

}
Console.WriteLine("&&&&&& CHANGE NAME &&&&&&&&&&&");
p1.UpperFullName();
Console.WriteLine(p1.FullName.FirstName + " " + p1.FullName.LastName);
