namespace GarageManagement
{
    public interface IVehicle
    {
        int CylinderVolume { get; set; }
        int MaxSpeed { get; set; }
        string Model { get; set; }
        int Year { get; set; }
    }
}