using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IPerson
    {
        string Spaceship { get; set; }

        int DateOfPurchase { get; set; }

       int  DateOfCalculation { get; set; }

        double MilesTraveled { get; set; }
       
    }
}
