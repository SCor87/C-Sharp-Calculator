/* Program: To calculate the total cost of painting a room
 * Author: Stephen Cormican
 * Created: 04/01/24
 */

using System;

namespace PaintCalculator
{
    internal class RoomAreaMethod
    {
        const double VAT_RATE = 0.2;
        const double WASTE_MULTIPLIER = 1.1;
        const double UNDERCOAT_PRICE = 4.0;

        static void Main()
        {
            double roomHeight = ReadDoubleInRange("Please enter the height of the room (min. 2m max. 6m):", 2, 6);

            double wallLength1 = ReadDoubleInRange("Please enter the length of wall 1 (min. 1m max. 25m):", 1, 25);
            double wallLength2 = ReadDoubleInRange("Please enter the length of wall 2 (min. 1m max. 25m):", 1, 25);
            double wallLength3 = ReadDoubleInRange("Please enter the length of wall 3 (min. 1m max. 25m):", 1, 25);
            double wallLength4 = ReadDoubleInRange("Please enter the length of wall 4 (min. 1m max. 25m):", 1, 25);

            double roomArea = roomHeight * (wallLength1 + wallLength2 + wallLength3 + wallLength4);
            Console.WriteLine("\nArea of the room is: " + roomArea + " square metres.\n");

            CalculatePaintPrice(VAT_RATE, roomArea, WASTE_MULTIPLIER, UNDERCOAT_PRICE);
        }

        static double ReadDoubleInRange(string prompt, double min, double max)
        {
            double value;
            Console.WriteLine(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.WriteLine($"Error! Value must be between {min}m and {max}m. Please try again:");
            }
            Console.WriteLine($"Accepted value: {value}m\n");
            return value;
        }

        static void CalculatePaintPrice(double vat, double roomArea, double wasteage, double undercoatPrice)
        {
            Console.WriteLine("Please enter your preferred paint quality type (Luxury, Standard or Economy):");

            string? paintQuality = Console.ReadLine()?.Trim();
            while (paintQuality != "Luxury" && paintQuality != "Standard" && paintQuality != "Economy")
            {
                Console.WriteLine("Error! Invalid input. Please enter Luxury, Standard or Economy:");
                paintQuality = Console.ReadLine()?.Trim();
            }

            double paintQualityPrice = paintQuality switch
            {
                "Luxury" => 18.50,
                "Standard" => 14.25,
                "Economy" => 8.75,
                _ => 0
            };

            Console.WriteLine($"\nYou have chosen {paintQuality} quality at £{paintQualityPrice:0.00} per square metre.\n");

            double basePrice = paintQualityPrice * roomArea;
            double priceWithWaste = basePrice * wasteage;
            double vatAmount = priceWithWaste * vat;
            double totalPrice = priceWithWaste + vatAmount;

            Console.WriteLine("Would you like to add undercoat paint for this job? It will cost £4 extra per square metre. (Y/N)");
            string? response = Console.ReadLine()?.Trim().ToUpper();

            while (response != "Y" && response != "N")
            {
                Console.WriteLine("Error! Invalid input. Please enter Y or N:");
                response = Console.ReadLine()?.Trim().ToUpper();
            }

            if (response == "Y")
            {
                double undercoatPriceTotal = (basePrice + (roomArea * undercoatPrice)) * wasteage;
                double undercoatVAT = undercoatPriceTotal * vat;
                double undercoatTotal = undercoatPriceTotal + undercoatVAT;

                Console.WriteLine("You have chosen to apply undercoat paint.");
                Console.WriteLine($"Cost before VAT: £{undercoatPriceTotal:0.00}");
                Console.WriteLine($"VAT: £{undercoatVAT:0.00}");
                Console.WriteLine($"Total cost including VAT: £{undercoatTotal:0.00}");
            }
            else
            {
                Console.WriteLine("You have chosen not to apply undercoat paint.");
                Console.WriteLine($"Cost before VAT: £{priceWithWaste:0.00}");
                Console.WriteLine($"VAT: £{vatAmount:0.00}");
                Console.WriteLine($"Total cost including VAT: £{totalPrice:0.00}");
            }
        }
    }
}

