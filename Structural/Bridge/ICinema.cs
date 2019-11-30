namespace Structural.Bridge
{
    interface ICinema
    {
        string Show();
        string Stop();
        string Off();
    }

    enum CinemaType { flat, cottadge};
    enum EquipmentType { Noolite, ZWave};
}
