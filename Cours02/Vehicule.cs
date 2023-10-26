using System.Globalization;
using System.Text;

public class Vehicule
{
    protected string _marque;
    protected DateTime _dateAchat;
    protected decimal _prixDAchat;
    protected decimal _prixCourant;
    protected int _age;

    public Vehicule(string marque, DateTime dateAchat, decimal prixDAchat)
    {
        _marque = marque;
        _dateAchat = dateAchat;
        _prixDAchat = prixDAchat;

        DateTime aujourd_hui = DateTime.Today;
        _age = aujourd_hui.Year - _dateAchat.Year - (aujourd_hui.Date > _dateAchat.AddYears(aujourd_hui.Year - _dateAchat.Year) ? 0 : 1);
    }

    public virtual void CalculerPrix()
    {
        _prixCourant = _prixDAchat - (_age * _prixDAchat / 100m);
        FormaterPrixCourant();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Véhicule de marque {0}, acheté le {1:dd/MM/yyyy} au prix de {2}.", _marque, _dateAchat, FormaterPrix(_prixDAchat));
        sb.AppendLine();
        sb.AppendFormat("Aujourd'hui, ce véhicule est âgé de {0} ans et vaut désormais {1}.", _age, FormaterPrix(_prixCourant));
        return sb.ToString();
    }

    protected void FormaterPrixCourant()
    {
        if (_prixCourant < 0)
        {
            _prixCourant = 0;
        }
    }

    private string FormaterPrix(decimal prix)
    {
        return string.Format(new CultureInfo("fr-CH"), "{0:C}", prix);
    }
}
