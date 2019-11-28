using System;
using System.Collections.Generic;
using System.Text;

namespace GettingRealConsoleApp.Domain
{
    public class Partner
    {
        public int Id;
        public string Name;

        public List<Shop> shops = new List<Shop>();
        public Shop GetShop(int id)
        {
            return new Shop();
        }
        public override string ToString()
        {
            return null;
        }

    }
}
