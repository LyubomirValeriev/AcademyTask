using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person : IPerson
    {
        private string space;
        public string Spaceship { 
            get => space; 
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new NullOrEmptyExeption();

                if(!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("The name of the ship must " +
                        "contains only letters!");
                }

                if (value.ToLower() == "cargo"
                    || value.ToLower() == "family")
                {
                    space = value.ToLower();
                }
                else
                    throw new ArgumentException("There is no such ship," +
                        " currently only cargo / family is available"); 
            }
        }
        private int _dateOfPurchase; 
        public int DateOfPurchase { 
            get => _dateOfPurchase;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Please do not enter negative" +
                        " numbers for the date of purchase of the ship"); 

                _dateOfPurchase = value;
            }
        }
        private int _dateOfCalculation; 
        public int DateOfCalculation {
            get => _dateOfCalculation;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Please do not enter negative numbers" +
                        " for the date you want to calculate!");

                if (value < _dateOfPurchase)
                    throw new ArgumentException("You must enter a date greater tha" +
                        "n the date of purchase of the ship ");

                _dateOfCalculation = value; 
            }
        }
        private double  _miles; 
        public double MilesTraveled 
        {
            get => _miles;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Please do not enter negative numbers in the mileage field");
                _miles = value;
            }
        } 

        public  void Calculate()
        {
            var tax = 0;
            var text = "";
            int miles = (int)(MilesTraveled) / 1000;

            if (Spaceship == "cargo")
            {
                tax += (10000 + miles * 1000 - (DateOfCalculation - DateOfPurchase) * 736);
                text += $"10000 + {miles}*1000 - ({DateOfCalculation} - {DateOfPurchase})*736";
            }
            else if (Spaceship == "family")
            {
                tax += 5000 + miles * 100 - (DateOfCalculation - DateOfPurchase) * 355;
                text += $"5000 + {miles}*100 -({DateOfCalculation} - {DateOfPurchase})*355";
            }

            Console.WriteLine(text);
            Console.WriteLine($"tax you need to pay :{tax} DVS");
        }
    }
}
