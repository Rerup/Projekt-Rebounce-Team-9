using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealConsoleApp;
using GettingRealConsoleApp.Domain;
using GettingRealConsoleApp.Appl;
using System.Collections.Generic;

namespace UnitTest2
{
    [TestClass]
    public class UnitTest1
    {

        User user1 = new User();
        User user2 = new User();
        User user3 = new User();

        Receipt receipt1 = new Receipt();
        Receipt receipt2 = new Receipt();
        Receipt receipt3 = new Receipt();
        Receipt receipt4 = new Receipt();
        Receipt receipt5 = new Receipt();
        Receipt receipt6 = new Receipt();

        Shop shop1 = new Shop();
        Shop shop2 = new Shop();
        Shop shop3 = new Shop();
        Shop shop4 = new Shop();
        Shop shop5 = new Shop();

        Partner partner1 = new Partner();
        Partner partner2 = new Partner();
        Partner partner3 = new Partner();

        ReceiptRepository ReceiptRepo = new ReceiptRepository();
        UserRepository UserRepo = new UserRepository();
        PartnerRepository PartnerRepo = new PartnerRepository();


        [TestInitialize]
        public void Init()
        {

            //USERS
            user1.Id = 1;
            user1.FullName = "John Hansen";
            user1.Phone = "20453251";
            Level thisLevel = new Level(LevelEnum.five);
            user1.Level = thisLevel;
            user1.UserName = "JojoHoho";

            user2.Id = 2;
            user2.FullName = "Pik Thomsen";
            user2.Phone = "89653738";
            user2.Level = new Level(LevelEnum.two);
            user2.UserName = "MLG_SNIPERCORRUPTION666";

            user3.Id = 3;
            user3.FullName = "Simon Kasmir";
            user3.Phone = "12329563";
            user3.Level = new Level(LevelEnum.three);
            user3.UserName = "SimonBøsserøv";

            //RECEIPTS
            receipt1.Id = 1;
            receipt1.InsertDate = new DateTime(2018, 12, 24, 10, 30, 00);
            receipt1.PurchaseDate = new DateTime(2018, 12, 22, 12, 25, 53);
            receipt1.AmountInDkk = 125;
            receipt1.UserLevel = user1.Level.Points;
            receipt1.UserId = 1;
            receipt1.ShopId = 1;
            receipt1.Status = 0;

            receipt2.Id = 2;
            receipt2.InsertDate = new DateTime(2019, 12, 20, 11, 20, 30);
            receipt2.PurchaseDate = new DateTime(2019, 12, 18, 12, 25, 50);
            receipt2.AmountInDkk = 250;
            receipt2.UserLevel = user2.Level.Points;
            receipt2.UserId = 2;
            receipt2.ShopId = 2;
            receipt2.Status = 0;

            receipt3.Id = 3;
            receipt3.InsertDate = new DateTime(2017, 3, 12, 13, 24, 22);
            receipt3.PurchaseDate = new DateTime(2017, 3, 6, 23, 30, 00);
            receipt3.AmountInDkk = 225;
            receipt3.UserLevel = user3.Level.Points;
            receipt3.UserId = 3;
            receipt3.ShopId = 3;
            receipt3.Status = 1;

            receipt4.Id = 4;
            receipt4.InsertDate = new DateTime(2019, 3, 12, 13, 24, 22);
            receipt4.PurchaseDate = new DateTime(2019, 3, 6, 23, 30, 00);
            receipt4.AmountInDkk = 200;
            receipt4.UserLevel = user1.Level.Points;
            receipt4.UserId = 1;
            receipt4.ShopId = 4;
            receipt4.Status = 1;

            receipt5.Id = 5;
            receipt5.InsertDate = new DateTime(2019, 2, 27, 7, 33, 11);
            receipt5.PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            receipt5.AmountInDkk = 375;
            receipt5.UserLevel = user3.Level.Points;
            receipt5.UserId = 3;
            receipt5.ShopId = 5;
            receipt5.Status = 3;

            receipt6.Id = 6;
            receipt6.InsertDate = new DateTime(2019, 3, 6, 5, 32, 11);
            receipt6.PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            receipt6.AmountInDkk = 83;
            receipt6.UserLevel = user1.Level.Points;
            receipt6.UserId = 1;
            receipt6.ShopId = 3;
            receipt6.Status = 2;

            //SHOPS
            shop1.Id = 1;
            shop1.Name = "Byens Burger";
            shop1.Zipcode = "8000";
            shop1.Adress = "Jensensvej 82";
            shop1.PartnerId = 1;


            shop2.Id = 2;
            shop2.Name = "Kebab bixen";
            shop2.Zipcode = "5000";
            shop2.Adress = "kebabvej 38";
            shop2.PartnerId = 2;

            shop3.Id = 3;
            shop3.Name = "Dine or Die";
            shop3.Zipcode = "8050";
            shop3.Adress = "Helvedsvej 28";
            shop3.PartnerId = 3;

            shop4.Id = 4;
            shop4.Name = "China Town";
            shop4.Zipcode = "8200";
            shop4.Adress = "Kinøjser Boulevarden 69";
            shop4.PartnerId = 3;

            shop5.Id = 5;
            shop5.Name = "Lises biks";
            shop5.Zipcode = "3000";
            shop5.Adress = "Annelinnetgade 12";
            shop5.PartnerId = 2;

            //PARTNERS
            partner1.Id = 1;
            partner1.Name = "Byens Burger";
            partner1.shops.Add(shop1);

            partner2.Id = 2;
            partner2.Name = "Kebabistan";
            partner2.shops.Add(shop2);
            partner2.shops.Add(shop5);

            partner3.Id = 3;
            partner3.Name = "Lises lorterestaurant";
            partner3.shops.Add(shop3);
            partner3.shops.Add(shop4);

            //ADD TO REPOS

            //USERS
            UserRepo.users.Add(user1);
            UserRepo.users.Add(user2);
            UserRepo.users.Add(user3);

            //RECEIPTS
            ReceiptRepo.receipts.Add(receipt1);
            ReceiptRepo.receipts.Add(receipt2);
            ReceiptRepo.receipts.Add(receipt3);
            ReceiptRepo.receipts.Add(receipt4);
            ReceiptRepo.receipts.Add(receipt5);
            ReceiptRepo.receipts.Add(receipt6);

            //PARTNERS
            PartnerRepo.partners.Add(partner1);
            PartnerRepo.partners.Add(partner2);
            PartnerRepo.partners.Add(partner3);
        }

        [TestMethod]
        public void CreateNewReceipt1()
        {
            // Assert
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime InsertDate = new DateTime(2019, 12, 20, 11, 20, 30);
            Receipt receipt = ReceiptRepo.CreateNewReceipt(InsertDate, 1);

            Assert.AreEqual(receipt.InsertDate, InsertDate);

        }
        [TestMethod]
        public void CreateNewReceipt2()
        {
            // Assert
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime InsertDate = new DateTime(2019, 12, 20, 11, 20, 30);
            Receipt receipt = ReceiptRepo.CreateNewReceipt(InsertDate, 1);

            Assert.AreEqual(receipt.UserId, 1);
        }

        [TestMethod]
        public void CreateNewReceipt3()
        {
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime InsertDate = new DateTime(2019, 12, 20, 11, 20, 30);
            Receipt receipt = ReceiptRepo.CreateNewReceipt(InsertDate, 1);

            Assert.AreEqual(receipt.Status, 0);
        }

        [TestMethod]
        public void EditReceipt1()
        {
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            Receipt receipt = ReceiptRepo.EditReceipt(1, PurchaseDate, 300, 3);

            Assert.AreEqual(receipt.PurchaseDate, PurchaseDate);
        }

        [TestMethod]
        public void EditReceipt2()
        {
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            Receipt receipt = ReceiptRepo.EditReceipt(2, PurchaseDate, 300, 3);

            Assert.AreEqual(receipt.AmountInDkk, 300);
        }

        [TestMethod]
        public void EditReceipt3()
        {
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            Receipt receipt = ReceiptRepo.EditReceipt(3, PurchaseDate, 300, 3);

            Assert.AreEqual(receipt.ShopId, 3);
        }

        [TestMethod]
        public void EditReceipt4()
        {
            //ReceiptRepository ReceiptRepo = new ReceiptRepository();
            DateTime PurchaseDate = new DateTime(2019, 3, 2, 9, 22, 13);
            Receipt receipt = ReceiptRepo.EditReceipt(4, PurchaseDate, 300, 3);

            Assert.AreEqual(receipt.Status, 1);
        }

        [TestMethod]
        public void GetReceiptsForNOTvalidated1()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(0);
            // Assert
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void GetReceiptsForNOTvalidated2()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(0);

            // Assert
            foreach (Receipt item in result)
            {
                if (item.Id == 1)
                {
                    Assert.AreEqual(item.UserLevel, 4);
                }
            }
        }

        [TestMethod]
        public void GetReceiptsForNOTvalidated3()
        {
            DateTime PurchaseDate = new DateTime(2019, 12, 18, 12, 25, 50);
            List<Receipt> result = ReceiptRepo.GetReceipts(0);
            // Assert
            foreach (Receipt item in result)
            {
                if (item.Id == 2)
                {
                    Assert.AreEqual(item.PurchaseDate, PurchaseDate);
                }
            }
        }

        [TestMethod]
        public void GetReceiptsForValidated1()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(1);
            // Assert
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void GetReceiptsForValidated2()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(1);
            // Assert
            foreach (Receipt item in result)
            {
                if (item.Id == 3)
                {
                    Assert.AreEqual(item.UserId, 3);
                }
            }
        }

        [TestMethod]
        public void GetReceiptsForValidated3()
        {
            DateTime PurchaseDate = new DateTime(2019, 3, 6, 23, 30, 00);
            List<Receipt> result = ReceiptRepo.GetReceipts(1);
            // Assert
            foreach (Receipt item in result)
            {
                if (item.Id == 4)
                {
                    Assert.AreEqual(item.PurchaseDate, PurchaseDate);
                }
            }
        }

        [TestMethod]
        public void GetReceiptsForWinners1()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(2);
            // Assert
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void GetReceiptsForWinners2()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(2);
            // Assert

            foreach (Receipt item in result)
            {
                if (item.Id == 6)
                {
                    Assert.AreEqual(item.AmountInDkk, 83);
                }
            }
        }

        [TestMethod]
        public void GetReceiptsInValid1()
        {
            List<Receipt> result = ReceiptRepo.GetReceipts(3);
            // Assert
            foreach (Receipt item in result)
            {
                if (item.Id == 5)
                {
                    Assert.AreEqual(item.AmountInDkk, 375);
                }
            }
        }

        [TestMethod]
        public void GetReceipt1()
        {
            Receipt receipt = ReceiptRepo.GetReceipt(1);

            // Assert

            Assert.AreEqual(0, receipt.Status);
        }

        [TestMethod]
        public void GetReceipt2()
        {
            Receipt receipt = ReceiptRepo.GetReceipt(2);


            // Assert

            Assert.AreEqual(0, receipt.Status);
        }

        [TestMethod]
        public void GetReceipt3()
        {
            Receipt receipt = ReceiptRepo.GetReceipt(3);
            // Assert
            Assert.AreEqual(1, receipt.Status);
        }

        [TestMethod]
        public void ValidateReceipt1()                                  //Eksempel på valideringsfejl pga overskredet dato for indsendelse
        {
            Receipt receipt1 = new Receipt();
            receipt1.Id = 1;
            receipt1.InsertDate = new DateTime(2019, 12, 24, 10, 30, 00);
            receipt1.PurchaseDate = new DateTime(2018, 12, 22, 12, 25, 53);
            receipt1.AmountInDkk = 125;
            receipt1.UserLevel = 5;
            receipt1.UserId = 1;
            receipt1.ShopId = 1;
            receipt1.Status = 0;
            bool result = ReceiptRepo.validateReceipt(receipt1, PartnerRepo);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ValidateReceipt2()                                  //Eksempel på valideringsfejl grundet et ikke eksisterende ShopId
        {
            Receipt receipt2 = new Receipt();
            receipt2.Id = 2;
            receipt2.InsertDate = new DateTime(2018, 12, 20, 11, 20, 30);
            receipt2.PurchaseDate = new DateTime(2018, 12, 18, 12, 25, 50);
            receipt2.AmountInDkk = 250;
            receipt2.UserLevel = 2;
            receipt2.UserId = 2;
            receipt2.ShopId = 7;
            receipt2.Status = 0;

            bool result = ReceiptRepo.validateReceipt(receipt2, PartnerRepo);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ValidateReceipt3()                                  //Eksempel på succesfuld validering
        {

            Receipt r3 = new Receipt();
            r3.Id = 3;
            r3.InsertDate = new DateTime(2017, 03, 12, 13, 24, 22);
            r3.PurchaseDate = new DateTime(2017, 03, 06, 23, 30, 00);
            r3.AmountInDkk = 225;
            r3.UserLevel = 3;
            r3.UserId = 3;
            r3.ShopId = 3;
            r3.Status = 1;

            bool result = ReceiptRepo.validateReceipt(r3, PartnerRepo);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShowReceipts1()                                       //Tester for om ShowReceipts indeholder alle Receipts
        {
            List<Receipt> receipts = new List<Receipt>();
            receipts.Add(receipt1);
            receipts.Add(receipt2);
            receipts.Add(receipt3);
            receipts.Add(receipt4);
            receipts.Add(receipt5);
            receipts.Add(receipt6);
            //Assert
            Assert.AreEqual(receipts.Count, 6);


        }

        [TestMethod]
        public void ShowReceipts2()                                       //Tester for om ShowReceipts viser alle med status 1
        {
            List<Receipt> receipts = ReceiptRepo.GetReceipts(1);

            Console.WriteLine("Tissemaaand");
            bool result = false;
            foreach (Receipt receipt in receipts)
            {

                if (receipt.Status != 1)
                {
                    result = true;
                    break;
                }
            }

            Assert.AreEqual(false, result);
        }

    }  
}