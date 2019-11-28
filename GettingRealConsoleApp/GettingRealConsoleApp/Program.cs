using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Appl;

namespace GettingRealConsoleApp
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            PartnerRepository partnerRepo = new PartnerRepository();
            ReceiptRepository receiptRepo = new ReceiptRepository();
            UserRepository userRepo = new UserRepository();

            partnerRepo.AddHardCode();
            receiptRepo.AddHardCode();
            userRepo.AddHardCode();

            //Testkommentar!!!

            Console.WriteLine("Rebounce");
            Console.WriteLine("Vælg:\n 1) Kvitteringer\n 2) Brugere\n 3) Partnere\n 4) Puljer\n\nAfslut med enter.");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                //Receipts
                case 1:
                    Console.WriteLine("Vælg:\n 1) Indskriv kvittering\n 2) Ret eksisterende kvittering\n\nAfslut med enter.");
                    //Show All Receipts()
                    int taskReceipt = int.Parse(Console.ReadLine());
                    switch (taskReceipt)
                    {
                        case 1:
                            //Create New Receipt

                            break;
                        case 2:
                            //Edit Receipt
                            break;
                    }
                    Console.ReadLine();
                    break;
                //Users
                case 2:
                    Console.WriteLine("Vælg:\n 1) Find brugere baseret på ID\n 2) Rediger i en bruger\n\nAfslut med enter.");
                    int taskUser = int.Parse(Console.ReadLine());
                    switch (taskUser)
                    {
                        case 1:
                            //Get User
                            break;
                        case 2:
                            //Edit User
                            break;
                    }
                    break;
                //Partners
                case 3:
                    Console.WriteLine("Vælg:\n 1) Kvitteringer\n 2) Brugere\n\nAfslut med enter.");
                    int taskPartner = int.Parse(Console.ReadLine());
                    switch (taskPartner)
                    {
                        case 1:
                            //Create new partner
                            break;
                        case 2:
                            //Register new shop
                            break;
                    }
                    Console.ReadLine();
                    break;
                //Pool
                case 4:
                    Console.WriteLine("Ikke klar endnu...");
                    Console.ReadLine();
                    break;
            }
            Console.ReadLine();
        }

    }
}
