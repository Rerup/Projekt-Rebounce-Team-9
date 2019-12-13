using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Appl;


namespace GettingRealConsoleApp.UI
{
    public class Menu
    {

        //Instantiating our repositories
        PartnerRepository partnerRepo = new PartnerRepository();
        ReceiptRepository receiptRepo = new ReceiptRepository();
        UserRepository userRepo = new UserRepository();

        //Instantiating objects and adding to lists in repositories
        public void AddHardCode()
        {
            partnerRepo.AddHardCode();
            receiptRepo.AddHardCode();
            userRepo.AddHardCode();
        }
        
        public void DisplayMenu()
        {
            //This property keeps the menu running indefinitely, through while-loop
            bool isRunning = true;
            while (isRunning == true)
            {
                //Removes content from console
                Console.Clear();

                //List of options
                Console.WriteLine("Rebounce");
                Console.WriteLine("Vælg:\n 1) Kvitteringer\n 2) Brugere\n 3) Partnere\n 4) Puljer\n 0) Quit\n\nAfslut med enter.");

                //This property holds user input, for the switch to process
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    //Receipts page is shown
                    case 1:
                        //Removes content from console
                        Console.Clear();

                        //Prints the lists of receipts, both invalid and valid
                        receiptRepo.ShowAll(userRepo, partnerRepo);

                        //New list of options for Receipts
                        Console.WriteLine("Vælg:\n 1) Indskriv kvittering\n 2) Ret eksisterende kvittering\n\nAfslut med enter.");

                        //This property holds user input, for the new switch to process
                        int taskReceipt = int.Parse(Console.ReadLine());
                        switch (taskReceipt)
                        {
                            case 1:
                                //Create New Receipt
                                //Takes user inputs for each parameter needed
                                Console.WriteLine("Hvad er indsætningsdato?");
                                Console.WriteLine("År:");
                                int year = int.Parse(Console.ReadLine());
                                Console.WriteLine("Måned:");
                                int month = int.Parse(Console.ReadLine());
                                Console.WriteLine("Dag:");
                                int day = int.Parse(Console.ReadLine());
                                
                                //Formatting user inputs to datetime
                                DateTime insert = new DateTime(year, month, day);


                                Console.WriteLine("Hvad er bruger id'et?");
                                int userid = int.Parse(Console.ReadLine());

                                Console.WriteLine("Tryk Enter for at fortsætte");
                                Console.ReadLine();

                                //Adding new receipt object to Repository list
                                receiptRepo.receipts.Add(receiptRepo.CreateNewReceipt(insert, userid));
                                break;

                            case 2:
                                //Edit Receipt
                                //Get specific Receipt Id
                                Console.WriteLine("Hvad er id'et?");
                                int receiptId = int.Parse(Console.ReadLine());

                                //If receiptId is not entered
                                if (receiptId == 0)
                                {
                                    Console.WriteLine("Du har ikke valgt en kvittering, prøv igen...");
                                    Console.ReadLine();
                                    break;
                                }

                                //Takes user inputs for each parameter needed
                                Console.WriteLine("Hvad er købsdato?");
                                Console.WriteLine("År:");
                                year = int.Parse(Console.ReadLine());
                                Console.WriteLine("Måned:");
                                month = int.Parse(Console.ReadLine());
                                Console.WriteLine("Dag:");
                                day = int.Parse(Console.ReadLine());

                                //´Validates input
                                if (year == 0 || month == 0 || day == 0)
                                {
                                    Console.WriteLine("Du har ikke indtastet en gyldig kvittering, prøv igen...");
                                    Console.ReadLine();
                                    break;
                                }

                                //Formatting user inputs to datetime
                                DateTime purchase = new DateTime(year, month, day);

                                //Get user input for amount on receipt
                                Console.WriteLine("Hvad er beløbet?");
                                int amount = int.Parse(Console.ReadLine());

                                if (amount == 0)
                                {
                                    Console.WriteLine("Du har ikke indtastet et gyldigt beløb, prøv igen...");
                                    Console.ReadLine();
                                    break;
                                }

                                //Get user input for which shop this receipt comes from
                                Console.WriteLine("Hvilken butiks id hører til?");
                                int shopId = int.Parse(Console.ReadLine());

                                if (shopId == 0)
                                {
                                    Console.WriteLine("Du har ikke indtastet et butiks id, prøv igen...");
                                    Console.ReadLine();
                                    break;
                                }

                                //Calls method with inputs from the user and edits object
                                receiptRepo.EditReceipt(receiptId, purchase, amount, shopId, partnerRepo);

                                break;

                            default:
                                Console.WriteLine("Invalid number");
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
                            default:
                                Console.WriteLine("Invalid number");
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
                            default:
                                Console.WriteLine("Invalid number");
                                break;
                        }
                        break;

                    //Pool
                    case 4:
                        //Here is shown, the current pool and a list of winners from ealier pools, as soon as you enter this part of the menu.
                        //This is not fully implemented
                        Console.Clear();
                        receiptRepo.PrintWinners(receiptRepo.GetReceipts(2, 4), userRepo);
                        Console.WriteLine("\nVælg:\n1) Rediger i kvittering\n2) Find en vinder\n0) Quit\n\nAfslut med enter.");
                        int taskPool = int.Parse(Console.ReadLine());
                        switch (taskPool)
                        {
                            case 0:
                                break;
                            case 1:
                                //Edit reciept where taskPool == ID
                                break;
                            case 2:
                                //Finds new winner - not fully implemented
                                Console.WriteLine(receiptRepo.GetWinner());
                                Console.ReadLine();
                                break;
                            default:
                                break;
                        }
                        break;

                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
        }
    }
}
