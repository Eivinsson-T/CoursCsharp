public class Aeroport : List<Vehicule>
{
    public new Aeroport AddRange(IEnumerable<Vehicule> vehicules)
    {
        base.AddRange(vehicules);
        return this;
    }
}
