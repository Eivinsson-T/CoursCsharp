using System.Globalization;
using System.Text;

public abstract class Vehicule
{
    private decimal _prixCourant;

    public string Marque { get; protected set; }
    public DateTime DateAchat { get; protected set; }
    public decimal PrixDAchat { get; protected set; }

    public decimal PrixCourant
    {
        get
        {
            CalculerPrix();
            return _prixCourant;
        }
        protected set
        {
            _prixCourant = value < 0 ? 0 : value;
        }
    }
    public int Age
    {
        get
        {
            DateTime aujourd_hui = DateTime.Today;
            return aujourd_hui.Year - DateAchat.Year - (aujourd_hui.Date > DateAchat.AddYears(aujourd_hui.Year - DateAchat.Year) ? 0 : 1);
        }
    }

    public Vehicule(string marque, DateTime dateAchat, decimal prixDAchat)
    {
        Marque = marque;
        DateAchat = dateAchat;
        PrixDAchat = prixDAchat;
    }

    public abstract void CalculerPrix();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Véhicule de marque {0}, acheté le {1:dd/MM/yyyy} au prix de {2}.", Marque, DateAchat, FormaterPrix(PrixDAchat));
        sb.AppendLine();
        sb.AppendFormat("Aujourd'hui, ce véhicule est âgé de {0} ans et vaut désormais {1}.", Age, FormaterPrix(_prixCourant));
        return sb.ToString();
    }

    private string FormaterPrix(decimal prix)
    {
        return string.Format(new CultureInfo("fr-CH"), "{0:C}", prix);
    }
}
