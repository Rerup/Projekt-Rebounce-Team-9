using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Domain;
namespace GettingRealConsoleApp.Appl
{
    public class PartnerRepository
    {
        public List<Partner> partners = new List<Partner>();

        public Partner GetPartner(int id)
        {
            return new Partner();
        }

        public void AddHardCode()
        {
            Partner Chido = new Partner();
            Chido.Id = 1;
            Chido.Name = "Chido Mexican Grill";
            

            Shop Chido1 = new Shop();
            Chido1.Id = 1;
            Chido1.Name = "Chido Mexican Grill";
            Chido1.Adress = "Mejlgade 48a";
            Chido1.Zipcode = "8000 Aarhus";

            Shop Chido2 = new Shop();
            Chido2.Id = 2;
            Chido2.Name = "Chido Mexican Grill";
            Chido2.Adress = "Frederiks Allé 135";
            Chido2.Zipcode = "8000 Aarhus";

            Shop Chido3 = new Shop();
            Chido3.Id = 3;
            Chido3.Name = "Chido Mexican Grill";
            Chido3.Adress = "Boulevarden 7";
            Chido3.Zipcode = "9000 Aalborg";

            Chido.shops.Add(Chido1);
            Chido.shops.Add(Chido2);
            Chido.shops.Add(Chido3);


            Partner Pita = new Partner();
            Pita.Id = 2;
            Pita.Name = "Pita Planet";
            
            Shop Pita1 = new Shop();
            Pita1.Id = 4;
            Pita1.Name = "Pita Planet";
            Pita1.Adress = "Sankt Clemens Stræde 7";
            Pita1.Zipcode = "8000 Aarhus";
            
            Pita.shops.Add(Pita1);


            Partner Senza = new Partner();
            Senza.Id = 3;
            Senza.Name = "Senzasian";
            
            Shop Senza1 = new Shop();
            Senza1.Id = 5;
            Senza1.Name = "Senzasian";
            Senza1.Adress = "Irma Pedersens Gade 2A";
            Senza1.Zipcode = "8000 Aarhus";
            
            Senza.shops.Add(Senza1);


            Partner Roots = new Partner();
            Roots.Id = 4;
            Roots.Name = "Roots Juice & 'Wich";            

            Shop Roots1 = new Shop();
            Roots1.Id = 6;
            Roots1.Name = "Roots Juicde & 'Wich";
            Roots1.Adress = "Storcenter Nord: Finlandsgade 17";
            Roots1.Zipcode = "8200 Aarhus";
            
            Roots.shops.Add(Roots1);


            Partner CafeG = new Partner();
            CafeG.Id = 5;
            CafeG.Name = "Cafe Gemmestedet";
            

            Shop CafeG1 = new Shop();
            CafeG1.Id = 7;
            CafeG1.Name = "Cafe Gemmestedet";
            CafeG1.Adress = "Gammel Munkegade 1";
            CafeG1.Zipcode = "8000 Aarhus";

            CafeG.shops.Add(CafeG1);





        }

    }
}
