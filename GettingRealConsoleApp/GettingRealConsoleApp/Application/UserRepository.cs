using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.Domain;

namespace GettingRealConsoleApp.Appl
{
    public class UserRepository
    {
        public List<User> users = new List<User>(); //Initialisering af liste med brugere

        public List<User> GetUser(int Id)  //Henter liste over Brugere
        {
            return users;
        }

        public void AddHardCode()
        {
            User u1 = new User();
            u1.Id = 1;
            u1.UserName = "Basse1";
            u1.FullName = "Lone Nielsen";
            u1.Phone = "23877532";
            u1.Level = new Level(LevelEnum.five);
            users.Add(u1);

            User u2 = new User();
            u2.Id = 2;
            u2.UserName = "Basse2";
            u2.FullName = "Lone Hansen";
            u2.Phone = "23837532";
            u2.Level = new Level(LevelEnum.five);
            users.Add(u2);

            User u3 = new User();
            u3.Id = 3;
            u3.UserName = "Basse3";
            u3.FullName = "Lone Jensen";
            u3.Phone = "23857532";
            u3.Level = new Level(LevelEnum.five);
            users.Add(u3);

            User u4 = new User();
            u4.Id = 4;
            u4.UserName = "Basse4";
            u4.FullName = "Lone Næsby";
            u4.Phone = "23857542";
            u4.Level = new Level(LevelEnum.five);
            users.Add(u4);

            User u5 = new User();
            u5.Id = 5;
            u5.UserName = "Basse5";
            u5.FullName = "Lone Jensen";
            u5.Phone = "23857531";
            u5.Level = new Level(LevelEnum.five);
            users.Add(u5);

            User u6 = new User();
            u6.Id = 6;
            u6.UserName = "CupQuake1";
            u6.FullName = "Maria Johansson";
            u6.Phone = "23870982";
            u6.Level = new Level(LevelEnum.five);
            users.Add(u6);

            User u7 = new User();
            u7.Id = 7;
            u7.UserName = "CupQuake2";
            u7.FullName = "Maria Hansen";
            u7.Phone = "29684532";
            u7.Level = new Level(LevelEnum.five);
            users.Add(u7);

            User u8 = new User();
            u8.Id = 8;
            u8.UserName = "CupQuake3";
            u8.FullName = "Maria Jensen";
            u8.Phone = "23857772";
            u8.Level = new Level(LevelEnum.five);
            users.Add(u8);

            User u9 = new User();
            u9.Id = 9;
            u9.UserName = "Rick";
            u9.FullName = "Ernst Pewdersmith";
            u9.Phone = "42897584";
            u9.Level = new Level(LevelEnum.five);
            users.Add(u9);

            User u10 = new User();
            u10.Id = 10;
            u10.UserName = "Morty";
            u10.FullName = "Lucas Iversen";
            u10.Phone = "14829131";
            u10.Level = new Level(LevelEnum.five);
            users.Add(u10);

        }
    }


    
}
