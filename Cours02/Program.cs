﻿using Cours02;


// List<Voiture> garage = new List<Voiture>
//         {
//             new Voiture("Peugeot", new DateTime(1998, 01, 01), 147325.79m, 2.5, 5, 180.0, 12000),
//             new Voiture("Renault", new DateTime(2005, 06, 18), 20000.00m, 1.9, 4, 130.0, 23000),
//             new Voiture("Porsche", new DateTime(2012, 03, 29), 25000.00m, 2.2, 5, 150.0, 17500),
//         };

// List<Avion> hangar = new List<Avion>
//         {
//             new Avion("Boeing", new DateTime(2008, 11, 10), 150000, AvionType.Reaction, 1200.5m),
//             new Avion("Sesna", new DateTime(1972, 1, 1), 1230673.90m, AvionType.Helice, 250),

//         };

// Console.WriteLine("Voitures:");
// foreach (var voiture in garage)
// {
//     voiture.CalculerPrix();
//     Console.WriteLine(voiture);
// }

// Console.WriteLine("\nAvions:");
// foreach (var avion in hangar)
// {
//     avion.CalculerPrix(false);
//     Console.WriteLine(avion);
// } 

// var genf = new Aeroport();
// genf.AddRange(hangar);
// genf.AddRange(garage);
// Console.WriteLine($"Il y a {genf.Count} véhicules dans l'aeroport.");

// foreach (var vehiculce in genf )
// {
//     vehiculce.CalculerPrix();
//     Console.WriteLine(vehiculce);
// }





var voit = new Voiture("Peugeot", new DateTime(1998, 01, 01), 147325.79m, 2.5, 5, 180.0, 12000);

foreach (var property in voit.GetType().GetProperties())
{

    Console.WriteLine($"property {property.Name} \n type:{property.PropertyType} \n {property.GetValue(voit)}");
}
