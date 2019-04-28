﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Shopping
    {
        private static int money;
        public static int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        //addWheel is the shopping encounter to buy a wheel. The price is encapsulated so that it can vary by location if desired
        public static void addWheel(GolfCart cart, int price)
        {
            Console.Write("\nEach wheel is ${0}. How many would you like to buy?", price);
            int wheels = Convert.ToInt32(Console.ReadLine());
            int total = price * wheels;
            if (total < Money)
            {
                cart.Wheels = cart.Wheels + wheels;
                Money = Money - total;
                Console.WriteLine("Remaining money: $" + Money);
            }

            else
            {
                Console.WriteLine("\nYou do not have enough money for that many. Please enter a valid amount");
                addWheel(cart, price);
            }
            
        }

        //addAxle is the shopping encounter to buy an axle. The price is encapsulated so that it can vary by location if desired
        public static void addAxle(GolfCart cart, int price)
        {
            Console.Write("\nEach Axle is ${0}. How many would you like to buy?", price);
            int axles = Convert.ToInt32(Console.ReadLine());
            int total = price * axles;
            if (total < Money)
            {
                cart.Axles = cart.Axles + axles;
                Money = Money - total;
                Console.WriteLine("Remaining money: $" + Money);
            }

            else
            {
                Console.WriteLine("\nYou do not have enough money for that many. Please enter a valid amount");
                addAxle(cart, price);
            }
        }

        //addBattery is the shopping encounter to buy a battery. The price is encapsulated so that it can vary by location if desired
        public static void addBattery(GolfCart cart, int price)
        {
            Console.Write("\nEach battery is ${0}. How many would you like to buy?", price);
            int batteries = Convert.ToInt32(Console.ReadLine());
            int total = price * batteries;
            if (total < Money)
            {
                cart.Batteries = cart.Batteries + batteries;
                Money = Money - total;
                Console.WriteLine("Remaining money: $" + Money);
            }

            else
            {
                Console.WriteLine("\nYou do not have enough money for that many. Please enter a valid amount");
                addBattery(cart, price);
            }
        }

        //goShopping is the method that allows the actual shopping encounter. Prices are currently hard-coded but can be changed is neccessary
        public static void goShopping(GolfCart cart)
        {
            addWheel(cart, 50);
            addAxle(cart, 100);
            addBattery(cart, 35);
        }
    }
}