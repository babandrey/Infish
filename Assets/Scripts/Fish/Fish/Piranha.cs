public class Piranha : Fish, IEdible
{
    public float Health { get; set; } = 0;

    public int NutritionalValue { get; } = 0;

    public IStatus[] Statuses { get; } = new IStatus[0];
}
