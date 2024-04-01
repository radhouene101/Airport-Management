using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services;

public static class PassengerExtension
{
    public static void UpperFullName(this Passenger p)
    {
        p.FullName.FirstName = p.FullName.FirstName.Substring(0, 1).ToUpper().ToString() + p.FullName.FirstName.Substring(1);
        p.FullName.LastName = p.FullName.LastName.Substring(0, 1).ToUpper().ToString() + p.FullName.LastName.Substring(1);
    }
}