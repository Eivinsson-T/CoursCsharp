using System.Text;

public class Voiture : Vehicule
{
    private readonly Dictionary<string, int> pourcentageMarque;

    private double _cylindree;
    private int _nombreDePortes;
    private double _puissance;
    private int _kilometrage;

    public Voiture(string marque, DateTime dateAchat, decimal prixDAchat, double cylindree, int nombreDePortes, double puissance, int kilometrage)
        : base(marque, dateAchat, prixDAchat)
    {
        _cylindree = cylindree;
        _nombreDePortes = nombreDePortes;
        _puissance = puissance;
        _kilometrage = kilometrage;

        pourcentageMarque = InitialiserDictionnaire();
    }

    public override void CalculerPrix()
    {
        PrixCourant = PrixDAchat
            - (Age * PrixDAchat * 0.02m)
            - (Math.Round(_kilometrage / 10000m) * PrixDAchat * 0.05m)
            + (pourcentageMarque.ContainsKey(Marque) ? pourcentageMarque[Marque] * PrixDAchat * 0.01m : 0);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Voiture {_nombreDePortes} portes ayant roulé {_kilometrage:0,0.0} kilomètres.");
        sb.AppendLine($"Motorisation : volume de {_cylindree} cm3 pour une puissance de {_puissance} cvs.");
        return sb.ToString();
    }

    private Dictionary<string, int> InitialiserDictionnaire()
    {
        return new Dictionary<string, int>()
        {
            { "Renault", -10},
            { "Fiat", -10},
            { "Ferrari", 20},
            { "Porsche", 20}
        };
    }
}
