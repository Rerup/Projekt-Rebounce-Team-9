using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Appl;
using GettingRealConsoleApp.Domain;
using System.Linq;

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

            bool isRunning = true;

            while (isRunning == true)
            {
                Console.Clear();
                receiptRepo.GetCurrentPool();
                Console.WriteLine("Rebounce");
                Console.WriteLine("Vælg:\n 1) Kvitteringer\n 2) Brugere\n 3) Partnere\n 4) Puljer\n 0) Quit\n\nAfslut med enter.");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    //Receipts
                    case 1:
                        Console.Clear();
                        receiptRepo.ShowAll();
                        Console.WriteLine("Vælg:\n 1) Indskriv kvittering\n 2) Ret eksisterende kvittering\n\nAfslut med enter.");

                        int taskReceipt = int.Parse(Console.ReadLine());
                        switch (taskReceipt)
                        {
                            case 1:
                                //Create New Receipt
                                Console.WriteLine("Hvad er indsætningsdato?");
                                Console.WriteLine("År:");
                                int year = int.Parse(Console.ReadLine());
                                Console.WriteLine("Måned:");
                                int month = int.Parse(Console.ReadLine());
                                Console.WriteLine("Dag:");
                                int day = int.Parse(Console.ReadLine());
                                DateTime insert = new DateTime(year, month, day);


                                Console.WriteLine("Hvad er bruger id'et?");
                                int userid = int.Parse(Console.ReadLine());

                                Console.WriteLine("Tryk Enter for at fortsætte");
                                Console.ReadLine();

                                Receipt newReceipt = receiptRepo.CreateNewReceipt(insert, userid);

                                receiptRepo.receipts.Add(newReceipt);
                                break;
                            case 2:
                                //Edit Receipt
                                break;
                            default: Console.WriteLine("Invalid number"); 
                                break;
                        }
                        break;

                    //Users
                    case 2:
                        Console.Clear();
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
                            default: Console.WriteLine("Invalid number"); 
                                break;
                        }
                        break;

                    //Partners
                    case 3:
                        Console.Clear();
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
                            default: Console.WriteLine("Invalid number"); 
                                break;
                        }
                        break;

                    //Pool
                    case 4:
                        //Her vises den aktuelle pulje og en liste af vindere, så snart man kommer ind i menuen
                        Console.Clear();
                        receiptRepo.PrintWinners(receiptRepo.GetReceipts(2,4),userRepo);
                        Console.WriteLine("Vælg et id for at redigere status på en kvittering, eller vælg 0 for at vende tilbage.");
                        int taskPool = int.Parse(Console.ReadLine());
                        switch (taskPool)
                        {
                            case 0:
                                break;
                            default:
                                //Edit reciept where taskPool == ID
                                break;
                        }
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default: Console.WriteLine("Invalid number"); 
                        break;
                }
            }
        }

    }
}
