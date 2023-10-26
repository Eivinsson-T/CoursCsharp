using System.Text;
using System.Text.RegularExpressions;

public class Avion : Vehicule
{
    private readonly Dictionary<AvionType, int> pourcentageType;

    private AvionType _type;
    private decimal _heuresDeVol;

    public Avion(string marque, DateTime dateAchat, decimal prixDAchat, AvionType type, decimal heuresDeVol)
        : base(marque, dateAchat, prixDAchat)
    {
        _type = type;
        _heuresDeVol = heuresDeVol;

        pourcentageType = InitialiserDictionnaire();
    }

    public override void CalculerPrix()
    {
        int tranche = pourcentageType.ContainsKey(_type) ? pourcentageType[_type] : pourcentageType[default];
        // x 10% <=> / 10m
        _prixCourant = _prixDAchat - (_heuresDeVol / tranche * _prixDAchat / 10m);

        FormaterPrixCourant();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Il s'agit d'un avion à {FormaterAvionType(_type)}, ayant volé un total de {_heuresDeVol:0,0.0} heures.");
        return sb.ToString();
    }

    public enum AvionType
    {
        Helice,
        Reaction
    }

    private Dictionary<AvionType, int> InitialiserDictionnaire()
    {
        return new Dictionary<AvionType, int>() {
            { AvionType.Helice, 100},
            { AvionType.Reaction, 1000}
        };
    }

    private string FormaterAvionType(AvionType avionType)
    {
        string avionTypeStr = avionType.ToString();
        return $"{Char.ToLower(avionTypeStr[0])}{new Regex("e").Replace(avionTypeStr.Substring(1), "é", 1)}";
    }
}
