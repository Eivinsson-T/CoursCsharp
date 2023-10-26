using System.Globalization;
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
        _prixCourant = _prixDAchat
            // x 2% <=> / 50m
            - (_age * _prixDAchat / 50m)
            // x 5% <=> / 20m
            - (Math.Round(_kilometrage / 10000m) * _prixDAchat / 20m)
            // x 1% <=> / 100m
            + (pourcentageMarque.ContainsKey(_marque) ? pourcentageMarque[_marque] * _prixDAchat / 100m : 0);
        
        FormaterPrixCourant();
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
        return new Dictionary<string, int>() {
            { "Renault", -10},
            { "Fiat", -10},
            { "Ferrari", 20},
            { "Porsche", 20}
        };
    }
}
