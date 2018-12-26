using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
//Objective: Get distance between two coordinates using latitude and longitude. Convert JavaScript version to C#.
//Source: http://www.movable-type.co.uk/scripts/latlong.html
/*
Haversine formula:
This uses the ‘haversine’ formula to calculate the great-circle distance between two points – that is, 
the shortest distance over the earth’s surface – giving an ‘as-the-crow-flies’ 
distance between the points (ignoring any hills they fly over, of course!).
*/
namespace HaversineFormula
{
    class Program
    {
        static void Main(string[] args)
        {

            var lat1 = 43.041070;//Milwuakee
            var lon1= -87.909420;//Milwuakee
            var lat2 = 44.952980;//Chicago           
            var lon2= -89.827150;//Chicago 
            //Uncomment if you want enter values into console.
            /*
            Console.WriteLine("Longitude 1: ");
            lat1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Longitude 1: ");
            lon1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Longitude 2: ");
            lat2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Longitude 2: ");
            lon2 = Double.Parse(Console.ReadLine());
            */
            Console.WriteLine("+++++Coordinates+++++");
            Console.WriteLine("Latitude 1: " + lon1 + " Longitude 1: " + lon1);
            Console.WriteLine("Latitude 2: " + lat2 + " Longitude 2: " + lon2);
            //Declare and Initialize variables
            var R = 6371e0; //Constant is used for getting units of distance. km = 6371e0; metres = 6371e3 
            var M = 0.62137119224; // Convert km to miles; 1 km = 0.62137119224 miles
            var φ1 = toRadian(lat1); 
            var φ2 = toRadian(lat2);
            var Δφ = toRadian(lat2 - lat1);
            var Δλ = toRadian(lon2 - lon1);
            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            var miles = d * M;//Convert to miles.
            //Print distance.
            Console.WriteLine("+++++Distance between coordinates+++++");
            Console.WriteLine("Kilometers: " + Math.Ceiling(d));//Round up to nearest whole number.
            Console.WriteLine("Miles: " + Math.Ceiling(miles));//Round up to nearest whole number.
            Console.ReadLine();           
        }
        //Convert angle to radian.
        private static double toRadian(double angle)
        {
            return (Math.PI * angle) / 180.0;
        }
    }
}
