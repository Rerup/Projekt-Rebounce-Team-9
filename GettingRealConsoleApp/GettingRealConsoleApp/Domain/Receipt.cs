using System;
using System.Collections.Generic;
using System.Text;

namespace GettingRealConsoleApp.Domain
{
    public class Receipt
    {
        public static int status;
        public int Id;
        public DateTime InsertDate;
        public DateTime PurchaseDate;
        public int AmountInDkk;
        public int UserLevel;
        public int UserId;
        public int ShopId;
        public int Status;

        public override string ToString()
        {
            return null;
        }
    }
}
