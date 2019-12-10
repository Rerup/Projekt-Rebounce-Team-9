using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Domain;
using GettingRealConsoleApp.Appl;
using System.Linq;

namespace GettingRealConsoleApp
{
    public class ReceiptRepository
    {
        public List<Receipt> receipts = new List<Receipt>();
        //PartnerRepository partnerRepo = new PartnerRepository();

        

        //Skal indsætte de fundne receipts oppe i listen
        public List<Receipt> GetReceipts(int status)
        {
            List<Receipt> result = new List<Receipt>();
            //result = null;

            foreach (Receipt receipt in receipts)
            {
                if  (receipt.Status == status)
                {
                    result.Add(receipt);
                }
            }

            return result;
        }

        public List<Receipt> GetReceipts(int status1, int status2)
        {
            List<Receipt> result = new List<Receipt>();
            //result = null;

            foreach (Receipt receipt in receipts)
            {
                if (receipt.Status == status1 || receipt.Status == status2)
                {
                    result.Add(receipt);
                }
            }

            return result;
        }


        //samme som ovenstående
        public Receipt GetReceipt(int id)
        {
            foreach (Receipt receipt in receipts)
            {
                if (receipt.Id == id)
                {
                    return receipt;
                } 
            }
            
            return null;
        }

        public Receipt CreateNewReceipt(DateTime insertDate, int userId)
        {
            Receipt receipt = new Receipt();
            receipt.Id = receipts.Count +1;
            receipt.InsertDate = insertDate;
            receipt.UserId = userId;
            receipt.Status = 0;

            return receipt;
        }

        public void ShowAll()
        {
            //Kald IKKE GODKENDTE kvitteringer
            List<Receipt> r0List = GetReceipts(0);

            //Kald GODKENDTE kvitteringer
            List<Receipt> r1List = GetReceipts(1);
            List<Receipt> r2List = GetReceipts(2);
            List<Receipt> r4List = GetReceipts(4);

            //Tilføj listerne sammen
            r1List.AddRange(r2List);
            r1List.AddRange(r4List);

            //Print IKKE GODKENDTE
            PrintReceipts(0, r0List);

            //Print GODKENDTE
            PrintReceipts(124, r1List);
        }
    
        public Receipt EditReceipt(int id, DateTime purchaseDate, int amount, int shopId, PartnerRepository partnerRepo)
        {
            Receipt r = GetReceipt(id);

            if(r == null) 
            {
                Console.WriteLine("Kvittering findes ikke, tryk enter for at fortsætte...");
                Console.ReadLine();
                return null; 
            }

            r.PurchaseDate = purchaseDate;
            r.AmountInDkk = amount;
            r.ShopId = shopId;

            if (ValidateReceipt(r, partnerRepo)) { r.Status = 1; }

            return r;
        }

        public bool ValidateReceipt(Receipt receipt , PartnerRepository partnerRepository)
        {
            if((receipt.InsertDate - receipt.PurchaseDate).TotalDays <= 7)
            {
                if(receipt.ShopId != 0 )
                {
                    foreach(Partner partner in partnerRepository.partners)
                    {
                        foreach(Shop shop in partner.shops)
                        {
                            if(shop.Id == receipt.ShopId) { return true; }
                        }
                    }

                    
                }
            }
            return false;
        }

        public void PrintReceipts(int status, List<Receipt> receipts)
        {
            if (status == 0)
            {
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("Liste over IKKE GODKENDTE kvitteringer");
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("ID\t| Brugernavn\t| Indsendt dato\t\t| Action\t|");
                Console.WriteLine("_________________________________________________________________");
                foreach (Receipt r in receipts)
                {
                    Console.WriteLine(r.Id + "\t| " + r.UserId + "\t\t| " + r.InsertDate + "\t| Rediger\t|");
                }
            }
            if (status == 124)
            {
                Console.WriteLine("");
                Console.WriteLine("Liste over GODKENDTE kvitteringer");
                Console.WriteLine("_________________________________________________________________________________________________________________________________");
                Console.WriteLine("ID\t| Brugernavn(id)| Butik(id)\t| Beløb\t| Indsendt dato\t\t| Købsdato\t\t| Point(id)\t| Action\t\t|");
                Console.WriteLine("_________________________________________________________________________________________________________________________________");
                foreach (Receipt r in receipts)
                {
                    Console.WriteLine(r.Id + "\t| " + r.UserId + "\t\t| " + r.ShopId + "\t\t| " + r.AmountInDkk + "\t| " + r.InsertDate + "\t| " + r.PurchaseDate + "\t| " + r.UserLevel + "\t\t| Rediger\t|");
                }
            }
        }

        public void PrintWinners(List<Receipt> receipts, UserRepository userRepository)
        {
            Console.WriteLine("");
            Console.WriteLine("Liste over vindere");
            Console.WriteLine("____________________________________________________________________________________________________");
            Console.WriteLine("Status\t | Brugernavn\t | Telefonnummer\t | Beløb\t | Antal gange vundet\t");
            Console.WriteLine("____________________________________________________________________________________________________");
            foreach (Receipt r in receipts)
            {
                User u = userRepository.GetUser(r.UserId);
                string paymentStatus;
                if (r.Status == 4) { paymentStatus = "Betalt"; }
                else { paymentStatus = "Ikke betalt"; }
                Console.WriteLine(paymentStatus + "| " + u.FullName + "| " + u.Phone + "\t\t| " + r.AmountInDkk + "\t\t| " + GetNumberOfWinsForUser(u.Id) + "\t\t| ");
            }
        }

        public int GetNumberOfWinsForUser(int id)
        {
            int result = 0;
            foreach (Receipt receipt in receipts)
            {
                if(receipt.Status == 2 || receipt.Status == 4)
                {
                    if (receipt.UserId == id)
                    {
                        result++;
                    }
                }
                
            }
            return result;
        }

        public List<Receipt> GetCurrentPool()
        {
            List<Receipt> result = new List<Receipt>();

            result = GetReceipts(1);
            result = result.OrderBy(receipt => receipt.InsertDate.Ticks).ToList();


                                 
            return result;
        }

        public Receipt GetWinner()
        {

            //Setup of tickets:
            //For each ticket add its 'id' as many times as it has points.
            //
            int totalPoints = 0;
            List<Receipt> pool = GetReceipts(1); //GetPool()??
            List<int> tickets = new List<int>();

            foreach(Receipt receipt in pool)
            {
                int points = 8 - (receipt.UserLevel - 1);
                totalPoints += points;

                for(int i = 1; i <= points; i++)
                {
                    tickets.Add(receipt.Id);
                }

            }

            //Select winner
            Random rnd = new Random();

            int rndId = rnd.Next(0, totalPoints - 1);
            int winnerId = tickets[rndId];
            Receipt winnerReceipt = GetReceipt(winnerId);

            return winnerReceipt;

        }


        public void AddHardCode()
        {
            Receipt r1 = new Receipt();
            r1.Id = 1;
            r1.InsertDate = new DateTime(2019, 12, 3);
            r1.UserLevel = 5;
            r1.UserId = 1;
            r1.Status = 0;


            receipts.Add(r1);

            Receipt r2 = new Receipt();
            r2.Id = 2;
            r2.InsertDate = new DateTime(2019, 11, 22);
            r2.UserLevel = 3;
            r2.UserId = 2;
            r2.Status = 0;

            receipts.Add(r2);

            Receipt r3 = new Receipt();
            r3.Id = 3;
            r3.InsertDate = new DateTime(2019, 5, 21);
            r3.UserLevel = 5;
            r3.UserId = 3;
            r3.Status = 0;

            receipts.Add(r3);

            Receipt r4 = new Receipt();
            r4.Id = 4;
            r4.InsertDate = new DateTime(2019, 6, 16);
            r4.UserLevel = 2;
            r4.UserId = 4;
            r4.Status = 0;

            receipts.Add(r4);

            Receipt r5 = new Receipt();
            r5.Id = 5;
            r5.InsertDate = new DateTime(2019, 7, 12);
            r5.UserLevel = 4;
            r5.UserId = 5;
            r5.Status = 0;

            receipts.Add(r5);

            Receipt r6 = new Receipt();
            r6.Id = 6;
            r6.InsertDate = new DateTime(2019, 7, 16);
            r6.PurchaseDate = new DateTime(2019, 7, 15);
            r6.AmountInDkk = 270;
            r6.UserLevel = 2;
            r6.UserId = 6;
            r6.ShopId = 1;
            r6.Status = 1;

            receipts.Add(r6);

            Receipt r7 = new Receipt();
            r7.Id = 7;
            r7.InsertDate = new DateTime(2019, 11, 6);
            r7.PurchaseDate = new DateTime(2019, 11, 3);
            r7.AmountInDkk = 677;
            r7.UserLevel = 1;
            r7.UserId = 7;
            r7.ShopId = 2;
            r7.Status = 1;

            receipts.Add(r7);

            Receipt r8 = new Receipt();
            r8.Id = 8;
            r8.InsertDate = new DateTime(2019, 11, 9);
            r8.PurchaseDate = new DateTime(2019, 11, 9);
            r8.AmountInDkk = 114;
            r8.UserLevel = 4;
            r8.UserId = 8;
            r8.ShopId = 3;
            r8.Status = 1;

            receipts.Add(r8);

            Receipt r9 = new Receipt();
            r9.Id = 9;
            r9.InsertDate = new DateTime(2019, 10, 11);
            r9.PurchaseDate = new DateTime(2019, 10, 10);
            r9.AmountInDkk = 229;
            r9.UserLevel = 5;
            r9.UserId = 9;
            r9.ShopId = 4;
            r9.Status = 1;

            receipts.Add(r9);

            Receipt r10 = new Receipt();
            r10.Id = 10;
            r10.InsertDate = new DateTime(2019, 11, 12);
            r10.PurchaseDate = new DateTime(2019, 11, 12);
            r10.AmountInDkk = 654;
            r10.UserLevel = 3;
            r10.UserId = 2;
            r10.ShopId = 5;
            r10.Status = 1;

            receipts.Add(r10);

            Receipt r11 = new Receipt();
            r11.Id = 11;
            r11.InsertDate = new DateTime(2019, 11, 12);
            r11.PurchaseDate = new DateTime(2019, 11, 7);
            r11.AmountInDkk = 178;
            r11.UserLevel = 3;
            r11.UserId = 10;
            r11.ShopId = 6;
            r11.Status = 1;

            receipts.Add(r11);

            Receipt r12 = new Receipt();
            r12.Id = 12;
            r12.InsertDate = new DateTime(2019, 11, 16);
            r12.PurchaseDate = new DateTime(2019, 11, 12);
            r12.AmountInDkk = 67;
            r12.UserLevel = 4;
            r12.UserId = 1;
            r12.ShopId = 7;
            r12.Status = 1;

            receipts.Add(r12);

            Receipt r13 = new Receipt();
            r13.Id = 13;
            r13.InsertDate = new DateTime(2019, 11, 14);
            r13.PurchaseDate = new DateTime(2019, 11, 13);
            r13.AmountInDkk = 302;
            r13.UserLevel = 1;
            r13.UserId = 2;
            r13.ShopId = 1;
            r13.Status = 1;

            receipts.Add(r13);

            Receipt r14 = new Receipt();
            r14.Id = 14;
            r14.InsertDate = new DateTime(2019, 11, 17);
            r14.PurchaseDate = new DateTime(2019, 11, 13);
            r14.AmountInDkk = 259;
            r14.UserLevel = 5;
            r14.UserId = 3;
            r14.ShopId = 2;
            r14.Status = 1;

            receipts.Add(r14);

            Receipt r15 = new Receipt();
            r15.Id = 15;
            r15.InsertDate = new DateTime(2019, 10, 2);
            r15.PurchaseDate = new DateTime(2019, 9, 29);
            r15.AmountInDkk = 517;
            r15.UserLevel = 5;
            r15.UserId = 4;
            r15.ShopId = 3;
            r15.Status = 2;

            receipts.Add(r15);

            Receipt r16 = new Receipt();
            r16.Id = 16;
            r16.InsertDate = new DateTime(2019, 10, 5);
            r16.PurchaseDate = new DateTime(2019, 10, 2);
            r16.AmountInDkk = 688;
            r16.UserLevel = 5;
            r16.UserId = 5;
            r16.ShopId = 4;
            r16.Status = 1;

            receipts.Add(r16);

            Receipt r17 = new Receipt();
            r17.Id = 17;
            r17.InsertDate = new DateTime(2019, 10, 9);
            r17.PurchaseDate = new DateTime(2019, 10, 3);
            r17.AmountInDkk = 422;
            r17.UserLevel = 4;
            r17.UserId = 6;
            r17.ShopId = 5;
            r17.Status = 1;

            receipts.Add(r17);

            Receipt r18 = new Receipt();
            r18.Id = 18;
            r18.InsertDate = new DateTime(2019, 11, 18);
            r18.PurchaseDate = new DateTime(2019, 11, 12);
            r18.AmountInDkk = 518;
            r18.UserLevel = 1;
            r18.UserId = 7;
            r18.ShopId = 6;
            r18.Status = 1;

            receipts.Add(r18);

            Receipt r19 = new Receipt();
            r19.Id = 19;
            r19.InsertDate = new DateTime(2019, 10, 11);
            r19.PurchaseDate = new DateTime(2019, 10, 9);
            r19.AmountInDkk = 513;
            r19.UserLevel = 1;
            r19.UserId = 8;
            r19.ShopId = 7;
            r19.Status = 1;

            receipts.Add(r19);

            Receipt r20 = new Receipt();
            r20.Id = 20;
            r20.InsertDate = new DateTime(2019, 5, 13);
            r20.PurchaseDate = new DateTime(2019, 5, 8);
            r20.AmountInDkk = 518;
            r20.UserLevel = 1;
            r20.UserId = 9;
            r20.ShopId = 1;
            r20.Status = 1;

            receipts.Add(r20);

            Receipt r21 = new Receipt();
            r21.Id = 21;
            r21.InsertDate = new DateTime(2019, 5, 28);
            r21.PurchaseDate = new DateTime(2019, 5, 23);
            r21.AmountInDkk = 322;
            r21.UserLevel = 1;
            r21.UserId = 10;
            r21.ShopId = 2;
            r21.Status = 1;

            receipts.Add(r21);

            Receipt r22 = new Receipt();
            r22.Id = 22;
            r22.InsertDate = new DateTime(2019, 6, 12);
            r22.PurchaseDate = new DateTime(2019, 6, 8);
            r22.AmountInDkk = 450;
            r22.UserLevel = 1;
            r22.UserId = 1;
            r22.ShopId = 3;
            r22.Status = 1;

            receipts.Add(r22);

            Receipt r23 = new Receipt();
            r23.Id = 23;
            r23.InsertDate = new DateTime(2019, 7, 19);
            r23.PurchaseDate = new DateTime(2019, 7, 13);
            r23.AmountInDkk = 222;
            r23.UserLevel = 1;
            r23.UserId = 2;
            r23.ShopId = 4;
            r23.Status = 1;

            receipts.Add(r23);

            Receipt r24 = new Receipt();
            r24.Id = 24;
            r24.InsertDate = new DateTime(2019, 7, 12);
            r24.PurchaseDate = new DateTime(2019, 7, 11);
            r24.AmountInDkk = 518;
            r24.UserLevel = 1;
            r24.UserId = 3;
            r24.ShopId = 5;
            r24.Status = 0;

            receipts.Add(r24);

            Receipt r25 = new Receipt();
            r25.Id = 25;
            r25.InsertDate = new DateTime(2019, 11, 22);
            r25.PurchaseDate = new DateTime(2019, 11, 13);
            r25.AmountInDkk = 333;
            r25.UserLevel = 1;
            r25.UserId = 4;
            r25.ShopId = 6;
            r25.Status = 3;

            receipts.Add(r25);

            Receipt r26 = new Receipt();
            r26.Id = 26;
            r26.InsertDate = new DateTime(2019, 11, 4);
            r26.PurchaseDate = new DateTime(2019, 10, 5);
            r26.AmountInDkk = 518;
            r26.UserLevel = 1;
            r26.UserId = 5;
            r26.ShopId = 7;
            r26.Status = 3;

            receipts.Add(r26);


            Receipt r27 = new Receipt();
            r27.Id = 27;
            r27.InsertDate = new DateTime(2019, 11, 9);
            r27.PurchaseDate = new DateTime(2019, 10, 8);
            r27.AmountInDkk = 280;
            r27.UserLevel = 1;
            r27.UserId = 2;
            r27.ShopId = 3;
            r27.Status = 1;

            receipts.Add(r27);


            Receipt r28 = new Receipt();
            r28.Id = 28;
            r28.InsertDate = new DateTime(2019, 11, 7);
            r28.PurchaseDate = new DateTime(2019, 10, 3);
            r28.AmountInDkk = 130;
            r28.UserLevel = 2;
            r28.UserId = 5;
            r28.ShopId = 2;
            r28.Status = 1;

            receipts.Add(r28);

            Receipt r29 = new Receipt();
            r29.Id = 29;
            r29.InsertDate = new DateTime(2019, 11, 7);
            r29.PurchaseDate = new DateTime(2019, 10, 3);
            r29.AmountInDkk = 130;
            r29.UserLevel = 2;
            r29.UserId = 5;
            r29.ShopId = 2;
            r29.Status = 1;

            receipts.Add(r29);

            Receipt r30 = new Receipt();
            r30.Id = 30;
            r30.InsertDate = new DateTime(2019, 11, 10);
            r30.PurchaseDate = new DateTime(2019, 11, 12);
            r30.AmountInDkk = 178;
            r30.UserLevel = 1;
            r30.UserId = 10;
            r30.ShopId = 2;
            r30.Status = 1;

            receipts.Add(r30);

            Receipt r31 = new Receipt();
            r31.Id = 31;
            r31.InsertDate = new DateTime(2019, 11, 11);
            r31.PurchaseDate = new DateTime(2019, 11, 12);
            r31.AmountInDkk = 346;
            r31.UserLevel = 5;
            r31.UserId = 4;
            r31.ShopId = 5;
            r31.Status = 1;

            receipts.Add(r31);

            Receipt r32 = new Receipt();
            r32.Id = 32;
            r32.InsertDate = new DateTime(2019, 11, 15);
            r32.PurchaseDate = new DateTime(2019, 11, 16);
            r32.AmountInDkk = 450;
            r32.UserLevel = 5;
            r32.UserId = 7;
            r32.ShopId = 5;
            r32.Status = 1;

            receipts.Add(r32);

            Receipt r33 = new Receipt();
            r33.Id = 33;
            r33.InsertDate = new DateTime(2019, 11, 17);
            r33.PurchaseDate = new DateTime(2019, 11, 17);
            r33.AmountInDkk = 511;
            r33.UserLevel = 5;
            r33.UserId = 3;
            r33.ShopId = 4;
            r33.Status = 1;

            receipts.Add(r33);

            Receipt r34 = new Receipt();
            r34.Id = 34;
            r34.InsertDate = new DateTime(2019, 11, 19);
            r34.PurchaseDate = new DateTime(2019, 11, 20);
            r34.AmountInDkk = 78;
            r34.UserLevel = 5;
            r34.UserId = 10;
            r34.ShopId = 3;
            r34.Status = 1;

            receipts.Add(r34);


            //Levels nulstillet hver måned???




        }

    }
}
