﻿using System;
using System.Text;

namespace MarketPlace.Application.Utilities
{
    public static class PasswordGenerator
    {
        public static string CreateRandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));

            return builder.ToString();
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static int RandomNumber(int min , int max)
        {
            // Generate a random number  
            Random random = new Random();
            // Any random integer   
            int num = random.Next(min, max);

            return num;
        }
    }
}
