using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{ 

    internal class Program
    {
        private static List<Person> people = new List<Person>(); 
        public static Person person = new Person();
        static void Main(string[] args)
        {

            while (true)
            {
           
                Console.Clear();
                Console.WriteLine("Possible options (press the button):\n 'a' - Calculate the amount\n 'q' - Quit");

                var key = Console.ReadKey().KeyChar;
                Console.Clear ();
                switch (key)
                {
                    case 'a':
                        {
                            try {
                                Console.WriteLine("enter a ship: ");
                                var Ship = Console.ReadLine().Trim();
                                person.Spaceship = Ship;

                                Console.WriteLine ("enter date of purchase");
                                int date = 0; 
                                bool ok = int.TryParse(Console.ReadLine().Trim(), out date);
                                if (!ok)
                                {
                                    throw new OnlyNumbersExepcion(); 
                                }
                                else
                                    person.DateOfPurchase = date;

                                Console.WriteLine("Enter the year until which it will be considered: ");
                                date = 0;
                                ok = int.TryParse(Console.ReadLine().Trim(), out date);
                                if (!ok)
                                {
                                    throw new OnlyNumbersExepcion();
                                }
                                else
                                    person.DateOfCalculation = date;

                                Console.WriteLine("Enter miles traveled: ");
                               double  miles = 0;
                                ok = double.TryParse(Console.ReadLine().Trim(), out miles);
                                if (!ok)
                                {
                                    throw new OnlyNumbersExepcion();

                                }
                                else
                                    person.MilesTraveled = miles;


                                // Calculate(person);
                                person.Calculate(); 
                                Console.ReadLine();

                            }
                            catch (NullOrEmptyExeption )
                            {
                                Console.WriteLine("Ship name must be entered!");
                                Console.ReadLine(); 
                               
                            }
                           catch(ArgumentException ex) 
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadLine();
                            }
                            catch (OnlyNumbersExepcion )
                            {
                                Console.WriteLine("Enter only numbers in the appropriate field!");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case 'q':
                        {
                            return; 
                        }
                }
            }
        }
     /*   public static void Calculate(Person person)
        {
            var tax = 0;
            var text = ""; 
            int miles = (int)(person.MilesTraveled )/ 1000;

            if(person.Spaceship == "cargo")
            {
                tax += (10000 + miles*1000 - (person.DateOfCalculation - person.DateOfPurchase) *736) ; 
                text += $"10000 + {miles}*1000 - ({person.DateOfCalculation} - {person.DateOfPurchase})*736"; 
            }else if(person.Spaceship == "family")
            {
                tax += 5000 + miles * 100 - (person.DateOfCalculation - person.DateOfPurchase) * 355;
                text += $"5000 + {miles}*100 -({person.DateOfCalculation} - {person.DateOfPurchase})*355";
            }

            Console.WriteLine(text);
            Console.WriteLine($"tax you need to pay :{tax} DVS");
        }/*

        */
    }
}
