using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Program: To calculate the total cost of painting a room
 * Author: Stephen Cormican
 * Created: 04/01/24
 */
namespace Paint_Calculator
{
    internal class Room_Area_Method
    {
        static void Main()
        {
            /* program starts with WriteLine below
           * asking user to input roomHeight which console converts to double
           */
            double roomHeight;
           
            Console.WriteLine("Please enter the height of the room (min. 2m max. 6m)");
            roomHeight = Convert.ToDouble(Console.ReadLine());

            if ((roomHeight > 2 || roomHeight < 6)) //if statement comparison as reverse of while loop to output user input. WriteLine outputs user message 
            {
                Console.WriteLine("Room height: " + roomHeight + "m" + "\n");
            }

            while ((roomHeight < 2) || (roomHeight > 6)) //introducing while loop to test input against range. 
            {
                Console.WriteLine("Error! Room height must be between 2m and 6m. Please enter a valid number between 2 and 6."); //user should see this error when their input is outside of range
                Console.WriteLine("Please enter the height of the room (min. 2m max. 6m)"); //user prompted to re-enter room height every time their input is outside of range
                roomHeight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Room height: " + roomHeight + "m" + "\n");

            }

            double wallLength1 = GetWallLength(1); //calling function four times allows user input for wall lengths to be stored and used in the room area calculation
            double wallLength2 = GetWallLength(2);
            double wallLength3 = GetWallLength(3);
            double wallLength4 = GetWallLength(4);

            double wallArea1 = roomHeight * wallLength1, wallArea2 = roomHeight * wallLength2, wallArea3 = roomHeight * wallLength3, wallArea4 = roomHeight * wallLength4;
            double roomArea = wallArea1 + wallArea2 + wallArea3 + wallArea4;

            Console.WriteLine("Area of the room is: " + roomArea + " metres squared." + "\n");

            CalculatePaintPrice(0.2, roomArea, 1.1, 4); //calling method within Main. Can't call CalculatePaintPrice method within CalculatePaintPrice code below

        }

        static double GetWallLength(double wallNumber) //function returning wall length. Called within Main to assign to variables wallLength1 - wallLength4
        {
            Console.WriteLine("Please enter the length of wall " + wallNumber + " (min. 1m max. 25m)");
            //wallNumber = Convert.ToDouble(Console.ReadLine());
            double wallLength = Convert.ToDouble(Console.ReadLine());

            if ((wallLength > 1 || wallLength < 25)) //if statement comparison as reverse of while loop to output user input. See WriteLine below for output message upon correct input
            {
                Console.WriteLine("Wall " + wallNumber + " length: " + wallLength + "m" + "\n");
            }

            while ((wallLength < 1) || (wallLength > 25)) //introducing while loop to test input against range
            {
                Console.WriteLine("Error! Wall length " + wallNumber + " must be between 1m and 25m. Please enter a valid number between 1 and 25."); //user should see this error when their input is outside of range
                Console.WriteLine("Please enter the length of the wall (min. 1m max. 25m)"); //user prompted to re-enter room height every time their input is outside of range
                wallLength = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Wall " + wallNumber + " length: " + wallLength + "m" + "\n");
                            
            }

            return wallLength; 

        }
        static void CalculatePaintPrice(double vat, double roomArea, double wasteage, double undercoatPrice) //variables inside parentheses are same as when declaring/assigning variables when not using a function
        {
            Console.WriteLine("Please enter your preferred paint quality type (Luxury, Standard or Economy)");

            string? paintQuality = Console.ReadLine();

            while (!(((paintQuality == "Luxury") || (paintQuality == "Standard") || (paintQuality == "Economy")))) //logical not to catch incorrect input and loop back to correct user input
            {
                Console.WriteLine("Error! Invalid input. Please enter Luxury, Standard or Economy.");
                paintQuality = Console.ReadLine();
            }

            double paintQualityPrice = 0; //paint quality prices are doubles within the 3 cases below

            switch (paintQuality) //switch statement with three cases, one for each paint quality type and each setting out the quality type price
            {
                case "Luxury":
                    paintQualityPrice = 18.50; //declaring constant
                    break;

                case "Standard":
                    paintQualityPrice = 14.25; //declaring constant
                    break;

                case "Economy":
                    paintQualityPrice = 8.75; //declaring constant
                    break;

            }

            /*main part of function in terms of calculating the paint price
             * this function is being called within the Main
             */

            Console.WriteLine(paintQuality + " paint quality is £" + paintQualityPrice.ToString("0.00") + " per square metre.");
            Console.WriteLine("You have chosen " + paintQuality + " quality." + "\n");
            double priceBefore = paintQualityPrice * roomArea;
            double wasteagePrice = priceBefore * wasteage;
            double VATBeforePrice = wasteagePrice;
            double VATPrice = VATBeforePrice * vat;
            double totalPrice = VATBeforePrice + VATPrice;

            Console.WriteLine("Would you like to add undercoat paint for this job? It will cost £4 extra per square metre." + "\n" + "Please enter Y or N");

            string? response = Console.ReadLine();

            while (!((response == "Y" || response == "N"))) //logical not to catch incorrect input that isn't Y or N
            {
                Console.WriteLine("Error! Invalid input. Please enter Y or N");
                Console.WriteLine("Would you like to add undercoat paint for this job? It will cost £4 extra per square metre." + "\n" + "Please enter Y or N");
                response = Console.ReadLine();

            }

            if (response == "Y") //if statement for user response on undercoat choice. Must be "Y" or "N" to continue with calculation below

            {
                double undercoatBefore = priceBefore + (roomArea * undercoatPrice);
                double undercoatWasteage = undercoatBefore * wasteage;
                double undercoatVATBefore = undercoatWasteage;
                double undercoatVATPrice = undercoatVATBefore * vat;
                double undercoatTotalPrice = undercoatVATBefore + undercoatVATPrice;
                Console.WriteLine("You have chosen to apply undercoat paint to this job.");
                Console.WriteLine("The cost of this job excluding VAT is £" + undercoatVATBefore.ToString("0.00"));
                Console.WriteLine("The cost of VAT for this job is £" + undercoatVATPrice.ToString("0.00"));
                Console.WriteLine("The total cost of paint for this job including VAT is £" + undercoatTotalPrice.ToString("0.00"));
            }

            if (response == "N")

            {
                Console.WriteLine("You have chosen not to apply undercoat paint to this job.");
                Console.WriteLine("The cost of this job excluding VAT is £" + VATBeforePrice.ToString("0.00"));
                Console.WriteLine("The cost of VAT for this job is £" + VATPrice.ToString("0.00"));
                Console.WriteLine("The total cost of paint for this job including VAT is £" + totalPrice.ToString("0.00"));
            }


        }
    }
}
