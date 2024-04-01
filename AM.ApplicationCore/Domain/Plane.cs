using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boeing,
        Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public DateTime ManufactureDate { get; set; }
        [Range(1,int.MaxValue)]
        public int Capacity { get; set; }
        public PlaneType PlaneType { get; set; }
        //objets de navigation
        public virtual ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Manufacture Date: " + ManufactureDate + " Plane Type: " + PlaneType;
        }
    }
}
