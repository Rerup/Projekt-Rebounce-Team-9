using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Domain;
using GettingRealConsoleApp.Appl;

namespace GettingRealConsoleApp
{
    public class ReceiptRepository
    {
        public List<Receipt> receipts = new List<Receipt>();
        PartnerRepository partnerRepo = new PartnerRepository();

        

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
            receipt.InsertDate = insertDate;
            receipt.UserId = userId;
            receipt.Status = 0;
            

     
            receipts.Add(receipt);
            return receipt;
        }
    
        public Receipt EditReceipt(int id, DateTime purchaseDate, int amount, int shopId)
        {
            foreach (Receipt receipt in receipts)
            {
                if (receipt.Id == id)
                {
                    receipt.PurchaseDate = purchaseDate;
                    receipt.AmountInDkk = amount;
                    receipt.ShopId = shopId;

                    if (validateReceipt(receipt, partnerRepo)) { receipt.Status = 1; }

                    return receipt;
                }
            }  
            //if no receipt is found return null
            return null;
        }

        public bool validateReceipt(Receipt receipt , PartnerRepository partnerRepository)
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

        public void AddHardCode()
        {
            Receipt r1 = new Receipt();
            r1.Id = 1;
            r1.InsertDate = new DateTime(3/11/2019);
            r1.PurchaseDate = new DateTime(3/11/2019);
            r1.AmountInDkk = 267;
            r1.UserLevel = 5;
            r1.UserId = 1;
            r1.Status = 0;
            

            receipts.Add(r1);
            
            Receipt r2 = new Receipt();
            r2.Id = 2;
            r2.InsertDate = new DateTime(3/11/2019);
            r2.PurchaseDate = new DateTime(2/11/2019);
            r2.AmountInDkk = 875;
            r2.UserLevel = 3;
            r2.UserId = 2;
            r2.Status = 0;

            receipts.Add(r2);

            Receipt r3 = new Receipt();
            r3.Id = 3;
            r3.InsertDate = new DateTime(5/11/2019);
            r3.PurchaseDate = new DateTime(5/11/2019);
            r3.AmountInDkk = 87;
            r3.UserLevel = 5;
            r3.UserId = 3;
            r3.Status = 0;

            receipts.Add(r3);

            Receipt r4 = new Receipt();
            r4.Id = 4;
            r4.InsertDate = new DateTime(5/11/2019);
            r4.PurchaseDate = new DateTime(5/11/2019);
            r4.AmountInDkk = 56;
            r4.UserLevel = 2;
            r4.UserId = 4;
            r4.Status = 0;

            receipts.Add(r4);

            Receipt r5 = new Receipt();
            r5.Id = 5;
            r5.InsertDate = new DateTime(6/11/2019);
            r5.PurchaseDate = new DateTime(6/11/2019);
            r5.AmountInDkk = 220;
            r5.UserLevel = 4;
            r5.UserId = 5;
            r5.Status = 0;

            receipts.Add(r5);

            Receipt r6 = new Receipt();
            r6.Id = 6;
            r6.InsertDate = new DateTime(6/11/2019);
            r6.PurchaseDate = new DateTime(5/11/2019);
            r6.AmountInDkk = 270;
            r6.UserLevel = 2;
            r6.UserId = 6;
            r6.Status = 0;

            receipts.Add(r6);

            Receipt r7 = new Receipt();
            r7.Id = 7;
            r7.InsertDate = new DateTime(6/11/2019);
            r7.PurchaseDate = new DateTime(3/11/2019);
            r7.AmountInDkk = 677;
            r7.UserLevel = 1;
            r7.UserId = 7;
            r7.Status = 0;

            receipts.Add(r7);

            Receipt r8 = new Receipt();
            r8.Id = 8;
            r8.InsertDate = new DateTime(9/11/2019);
            r8.PurchaseDate = new DateTime(9/11/2019);
            r8.AmountInDkk = 114;
            r8.UserLevel = 4;
            r8.UserId = 8;
            r8.Status = 0;

            receipts.Add(r8);

            Receipt r9 = new Receipt();
            r9.Id = 9;
            r9.InsertDate = new DateTime(10/11/2019);
            r9.PurchaseDate = new DateTime(10/11/2019);
            r9.AmountInDkk = 229;
            r9.UserLevel = 5;
            r9.UserId = 9;
            r9.Status = 0;

            receipts.Add(r9);

            Receipt r10 = new Receipt();
            r10.Id = 10;
            r10.InsertDate = new DateTime(12/11/2019);
            r10.PurchaseDate = new DateTime(12/11/2019);
            r10.AmountInDkk = 654;
            r10.UserLevel = 3;
            r10.UserId = 2;
            r10.Status = 0;

            receipts.Add(r10);

            Receipt r11 = new Receipt();
            r11.Id = 11;
            r11.InsertDate = new DateTime(12/11/2019);
            r11.PurchaseDate = new DateTime(7/11/2019);
            r11.AmountInDkk = 178;
            r11.UserLevel = 3;
            r11.UserId = 10;
            r11.Status = 0;

            receipts.Add(r11);

            Receipt r12 = new Receipt();
            r12.Id = 12;
            r12.InsertDate = new DateTime(14/11/2019);
            r12.PurchaseDate = new DateTime(14/11/2019);
            r12.AmountInDkk = 67;
            r12.UserLevel = 4;
            r12.UserId = 1;
            r12.Status = 0;

            receipts.Add(r12);

            Receipt r13 = new Receipt();
            r13.Id = 13;
            r13.InsertDate = new DateTime(14/11/2019);
            r13.PurchaseDate = new DateTime(14/11/2019);
            r13.AmountInDkk = 302;
            r13.UserLevel = 1;
            r13.UserId = 2;
            r13.Status = 0;

            receipts.Add(r13);

            Receipt r14 = new Receipt();
            r14.Id = 14;
            r14.InsertDate = new DateTime(15/11/2019);
            r14.PurchaseDate = new DateTime(15/11/2019);
            r14.AmountInDkk = 259;
            r14.UserLevel = 5;
            r14.UserId = 3;
            r14.Status = 0;

            receipts.Add(r14);

            Receipt r15 = new Receipt();
            r15.Id = 15;
            r15.InsertDate = new DateTime(17/11/2019);
            r15.PurchaseDate = new DateTime(15/11/2019);
            r15.AmountInDkk = 517;
            r15.UserLevel = 5;
            r15.UserId = 4;
            r15.Status = 0;

            receipts.Add(r15);

            Receipt r16 = new Receipt();
            r16.Id = 16;
            r16.InsertDate = new DateTime(17/11/2019);
            r16.PurchaseDate = new DateTime(16/11/2019);
            r16.AmountInDkk = 688;
            r16.UserLevel = 5;
            r16.UserId = 5;
            r16.Status = 0;

            receipts.Add(r16);

            Receipt r17 = new Receipt();
            r17.Id = 17;
            r17.InsertDate = new DateTime(18/11/2019);
            r17.PurchaseDate = new DateTime(17/11/2019);
            r17.AmountInDkk = 422;
            r17.UserLevel = 4;
            r17.UserId = 6;
            r17.Status = 0;

            receipts.Add(r17);

            Receipt r18 = new Receipt();
            r18.Id = 18;
            r18.InsertDate = new DateTime(18/11/2019);
            r18.PurchaseDate = new DateTime(18/11/2019);
            r18.AmountInDkk = 518;
            r18.UserLevel = 1;
            r18.UserId = 7;
            r18.Status = 0;

            receipts.Add(r18);

            Receipt r19 = new Receipt();
            r19.Id = 18;
            r19.InsertDate = new DateTime(19 / 11 / 2019);
            r19.PurchaseDate = new DateTime(18 / 11 / 2019);
            r19.AmountInDkk = 513;
            r19.UserLevel = 1;
            r19.UserId = 8;
            r19.Status = 0;

            receipts.Add(r19);

            Receipt r20 = new Receipt();
            r20.Id = 18;
            r20.InsertDate = new DateTime(20 / 11 / 2019);
            r20.PurchaseDate = new DateTime(19 / 11 / 2019);
            r20.AmountInDkk = 518;
            r20.UserLevel = 1;
            r20.UserId = 9;
            r20.Status = 0;

            receipts.Add(r20);

            Receipt r21 = new Receipt();
            r21.Id = 18;
            r21.InsertDate = new DateTime(20 / 11 / 2019);
            r21.PurchaseDate = new DateTime(20 / 11 / 2019);
            r21.AmountInDkk = 322;
            r21.UserLevel = 1;
            r21.UserId = 10;
            r21.Status = 0;

            receipts.Add(r21);

            Receipt r22 = new Receipt();
            r22.Id = 18;
            r22.InsertDate = new DateTime(20 / 11 / 2019);
            r22.PurchaseDate = new DateTime(19 / 11 / 2019);
            r22.AmountInDkk = 450;
            r22.UserLevel = 1;
            r22.UserId = 1;
            r22.Status = 0;

            receipts.Add(r22);

            Receipt r23 = new Receipt();
            r23.Id = 18;
            r23.InsertDate = new DateTime(21 / 11 / 2019);
            r23.PurchaseDate = new DateTime(20 / 11 / 2019);
            r23.AmountInDkk = 222;
            r23.UserLevel = 1;
            r23.UserId = 2;
            r23.Status = 0;

            receipts.Add(r23);

            Receipt r24 = new Receipt();
            r24.Id = 18;
            r24.InsertDate = new DateTime(21 / 11 / 2019);
            r24.PurchaseDate = new DateTime(21 / 11 / 2019);
            r24.AmountInDkk = 518;
            r24.UserLevel = 1;
            r24.UserId = 3;
            r24.Status = 0;

            receipts.Add(r24);

            Receipt r25 = new Receipt();
            r25.Id = 18;
            r25.InsertDate = new DateTime(22 / 11 / 2019);
            r25.PurchaseDate = new DateTime(21 / 11 / 2019);
            r25.AmountInDkk = 333;
            r25.UserLevel = 1;
            r25.UserId = 4;
            r25.Status = 0;

            receipts.Add(r25);

            Receipt r26 = new Receipt();
            r26.Id = 18;
            r26.InsertDate = new DateTime(23 / 11 / 2019);
            r26.PurchaseDate = new DateTime(22 / 11 / 2019);
            r26.AmountInDkk = 518;
            r26.UserLevel = 1;
            r26.UserId = 5;
            r26.Status = 0;

            receipts.Add(r26);

            //Levels nulstillet hver måned???




        }

    }
}
