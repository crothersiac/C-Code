using System;

namespace ConsoleApp22
{
    class Program
    {
        public static void Main(string[] args)
        {
            string emp_name;
            string cust_name;
            Licensed vehicle1 = new Licensed();
            Unlicensed vehicle2 = new Unlicensed();

            double decision = 0;

            //Program is created to ease burden and confusion of repair intake and drop-off process at Hobbytown, a local retailer.

            Console.WriteLine("*------------------------------------------------------*");
            Console.WriteLine("Welcome to the Hobby Plus Repair Drop-Off Help Station!");
            Console.WriteLine("*------------------------------------------------------*");
            Console.WriteLine("Please enter a digit, 1 for Yes, or 0 for No!");
            Console.WriteLine("*------------------------------------------------------*");

            Console.WriteLine("What is your name? Please enter your name below!");
            emp_name = Console.ReadLine();
            Console.WriteLine("What is the name of the customer you are helping?");
            cust_name = Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Is the vehicle that the customer has a supported vehicle in our stock?");
            decision = Input("Please enter either a 1 for Yes, or a 0 for No to indicate the response.");

            //These are the benchmark  questions that an employee must answer to complete the form.

            if (decision == 1)
            {
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("Remember, please enter in values as 1 for Yes, or 0 for No to each subsequent question!");
                Console.WriteLine("--------------------------------------------------------------------------");

                vehicle1.Movement(Input("1. Does the vehicle move in either forward or reverse freely?"));
                vehicle1.Servo1(Input("2. Does the servo(s) in said vehicle operate normally? (i.e. Does the vehicle turn, or pivot as it normally should?)"));
                vehicle1.PartsInstall(Input("3. Is the customer looking to have parts installed on the vehicle?"));
                vehicle1.ESC1(Input("4. Does the ESC turn-on and function? (Does the vehicle cycle through and power on like usual?)"));
                vehicle1.Motor1(Input("5. Is the motor engaging when given signal from the ESC? (Is the motor(s) engaging and starting to run?)"));

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Information:");
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("Employee Name: " + emp_name);
                Console.WriteLine("The current customer being serviced: " + cust_name);
                Console.WriteLine();
                Console.WriteLine("Results:");
                DisplayLicensed(vehicle1.Results());
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Following Up:");
                Console.WriteLine("*------------------------------------------------------*");

                double custdrop = Input("Is the customer leaving the vehicle?");
                DropTicket(custdrop, cust_name, emp_name);

            }
            else if (decision == 0)
            {
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("Remember, please enter in values as 1 for Yes, or 0 for No to each subsequent question!");
                Console.WriteLine("--------------------------------------------------------------------------");

                vehicle2.Discontinued(Input("1. Is the vehicle that the customer has dicontinued?"));
                vehicle2.Move(Input("2. Does the vehicle move freely in either forward and/or reverse?"));
                vehicle2.ServoWork(Input("3.  Does the servo(s) in said vehicle operate normally? (i.e. Does the vehicle turn, or pivot as it normally should?)"));
                vehicle2.Esc2(Input("4. Does the ESC turn-on and function? (Does the vehicle cycle through and power on like usual?)"));
                vehicle2.Motor2(Input("5. Is the motor engaging when given signal from the ESC? (Is the motor(s) engaging and starting to run?)"));
                vehicle2.CustomerParts(Input("6. Does the customer have parts that they brought to be installed?"));

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Information:");
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("Employee Name: " + emp_name);
                Console.WriteLine("The current customer being serviced: " + cust_name);
                Console.WriteLine();
                Console.WriteLine("Results:");
                DisplayUnlicensed(vehicle2.Results());
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Following Up:");
                Console.WriteLine("*------------------------------------------------------*");

                double custdrop = Input("Is the customer leaving the vehicle?");
                DropTicket(custdrop, cust_name, emp_name);
            }


        }

        //User is given this if inputs are incorrect or invalid
        public static double Input(string msg)
        {
            double input;
            Console.WriteLine(msg);
            input = Convert.ToDouble(Console.ReadLine());
            while (input <= -1 || input >= 2)
            {
                Console.WriteLine("Please enter a valid input for the sheet to proceed, thank you!");
                Console.WriteLine(msg);
                input = Convert.ToDouble(Console.ReadLine());
            }
            return input;
        }


        public static void DropTicket(double custdrop, string cust_name, string emp_name)
        {
            Random random = new Random();
            double ticketnum = random.Next(99999);

            if (custdrop == 1)
            {
                Console.WriteLine();
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("Repair Ticket:");
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("Ticket #: " + ticketnum);
                Console.WriteLine("Customer Name: " + cust_name);
                Console.WriteLine("Employee Name: " + emp_name);
                Console.WriteLine("Cost of Labor: (Please enter the amount of hours the repair is estimated to take.)");
                double laborhours = Convert.ToDouble(Console.ReadLine());
                while (laborhours < 0 || laborhours > 10)
                {
                    Console.WriteLine("Please enter a valid input the amount of hours worked for the sheet to proceed, thank you!");
                    Console.WriteLine("Cost of Labor: (Please enter the amount of hours the repair is estimated to take.)");
                    laborhours = Convert.ToDouble(Console.ReadLine());
                }
                double labor = laborhours * 30;
                Console.WriteLine("What is the expected cost of parts to be installed? (Please round to the nearest dollar)");
                double cost = Convert.ToDouble(Console.ReadLine());
                while (cost < 0 || cost > 2000)
                {
                    Console.WriteLine("Please enter a valid input the total cost for the sheet to proceed, thank you!");
                    Console.WriteLine("What is the expected cost of parts to be installed? (Please round to the nearest dollar)");
                    cost = Convert.ToDouble(Console.ReadLine());
                }
                double total = cost + labor;
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("The total estimate for the repair to be done is: {0:C}", total);
                Console.WriteLine("Thanks for using the Hobby Plus Drop-Off System!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("Confirmation:");
                Console.WriteLine("*------------------------------------------------------*");
                Console.WriteLine("No Drop-off initiated!");
                Console.WriteLine();
                Console.WriteLine("Thanks for using the Hobby Plus Drop-Off System!");
            }

        }
        public static void DisplayLicensed(double vehicle1)
        {
            Random random = new Random();
            Console.WriteLine("This is the course of action that you should proceed with: ");
            if (vehicle1 == 1)
            {
                Console.WriteLine("'You need to replace the servo(s) and drop off the vehicle!");
                Console.WriteLine("Try and grab the stock replacement off the shelf, or if not possible, push for an upgrade for greater durability!'");
            }
            else if (vehicle1 == 2)
            {
                Console.WriteLine("'You should drop the vehicle off and pull whatever parts the customer would like to be installed.");
                Console.WriteLine("Try and grab the stock replacement off the shelf, or if not possible, push for an upgrade for greater durability!'");
            }
            else if (vehicle1 == 3)
            {
                Console.WriteLine("'You can't drop the vehicle off due to lack of parts.");
                Console.WriteLine("Customer can find manager if looking to order parts, and then can re-dropoff vehicle when they arrive.'");
            }
            else if (vehicle1 == 4)
            {
                Console.WriteLine("'You need to drop the vehicle off and replace the ESC in the vehicle.");
                Console.WriteLine("Try and grab the stock replacement off the shelf, or if not possible, push for an upgrade for greater durability!'");
            }
            else if (vehicle1 == 5)
            {
                Console.WriteLine("'The ESC in the vehicle is fine, but you need to drop-off for a motor replacement.");
                Console.WriteLine("Try and grab the stock replacement off the shelf, or if not possible, push for an upgrade for greater durability!'");
            }
            else if (vehicle1 == 6)
            {
                int probability = random.Next(10);

                if (probability > 5)
                {
                    Console.WriteLine("'We have available room, you should take the vehicle in for more thorough diagnosis of the issues!'");
                }
                else
                {
                    Console.WriteLine("'The shop doesn't have enough space for the vehicle to be further diagnosed at this time!'");
                }
            }
        }
        public static void DisplayUnlicensed(double vehicle2)
        {
            Console.WriteLine("Below is the method of action that you should proceed with: ");
            if (vehicle2 == 1)
            {
                Console.WriteLine("This vehicle is not one that we can servie due to lack of parts availabilty.");
                Console.WriteLine("This is a discontinued vehicle and doesn't have any parts support.");
            }
            else if (vehicle2 == 2)
            {
                Console.WriteLine("The servo in the vehicle more than liekly needs to be replaced.");
                Console.WriteLine("Replace the servo with a standard, universal replacement with correct tooth count for spline, or they can order one online.");
            }
            else if (vehicle2 == 3)
            {
                Console.WriteLine("The Electronic Speed Controller is more than likely either shorted or burned out.");
                Console.WriteLine("You need to replace the ESC, try to find and match an ESC for the vehicle, or they can order one online.");
            }
            else if (vehicle2 == 4)
            {
                Console.WriteLine("The customer doesn't have parts for the installation on the vehicle, and we do not carry parts for the vehicle.");
                Console.WriteLine("The customer's vehicle can not be dropped off today, they need to try and order parts.");
            }
            else if (vehicle2 == 5)
            {
                Console.WriteLine("The motor is no longer valid and needs to be replaced.");
                Console.WriteLine("The customer can either drop the vehicle off for an appropiate replacement, or they can order one online.");
            }
            else if (vehicle2 == 6)
            {
                Console.WriteLine("After initial assessment, the vehicle would need to be further diagnosed by a more experienced hobbyist.");
                Console.WriteLine("You should not take the vehicle in for a repair.");
            }
            else if (vehicle2 == 7)
            {
                Console.WriteLine("If the customer has dropped off parts for their vehicle, we can service it!");
                Console.WriteLine("Please collect all the parts that they have dropped off and continue forward through the prompts.");
            }
        }

    }
}

//Decsion matrices as follows, below are all the available choice avenues that can be pursued.
class Licensed
{
    double[] answers = new double[7];
    public Licensed()
    {
        answers[0] = 0;
        answers[1] = 0;
        answers[2] = 0;
        answers[3] = 0;
        answers[4] = 0;
        answers[5] = 0;
    }

    public void Movement(double movement)
    {
        answers[0] = movement;
    }
    public void Servo1(double servo1)
    {
        answers[1] = servo1;
    }
    public void PartsInstall(double partsinstall)
    {
        answers[2] = partsinstall;
    }
    public void ESC1(double esc1)
    {
        answers[3] = esc1;
    }
    public void Motor1(double motor1)
    {
        answers[4] = motor1;
    }
    public double Results()
    {
        if (answers[0] == 1 && answers[1] == 0)
        {
            answers[5] = 1;
        }
        else if (answers[0] == 1 && answers[1] == 1 && answers[2] == 1)
        {
            answers[5] = 2;
        }
        else if (answers[0] == 1 && answers[1] == 1 && answers[2] == 0)
        {
            answers[5] = 3;
        }
        else if (answers[0] == 0 && answers[3] == 0)
        {
            answers[5] = 4;
        }
        else if (answers[0] == 0 && answers[3] == 1 && answers[4] == 0)
        {
            answers[5] = 5;
        }
        else if (answers[0] == 0 && answers[3] == 1 && answers[4] == 1)
        {
            answers[5] = 6;
        }
        return answers[5];
    }
}

class Unlicensed
{
    double[] responses = new double[7];
    public Unlicensed()
    {
        responses[0] = 0;
        responses[1] = 0;
        responses[2] = 0;
        responses[3] = 0;
        responses[4] = 0;
        responses[5] = 0;
        responses[6] = 0;
    }
    public void Discontinued(double discontinued)
    {
        responses[0] = discontinued;
    }
    public void Move(double move)
    {
        responses[1] = move;
    }
    public void ServoWork(double servowork)
    {
        responses[2] = servowork;
    }
    public void Esc2(double esc2)
    {
        responses[3] = esc2;
    }
    public void Motor2(double motor2)
    {
        responses[4] = motor2;
    }
    public void CustomerParts(double customerparts)
    {
        responses[5] = customerparts;
    }
    public double Results()
    {
        if (responses[0] == 1)
        {
            responses[6] = 1;
        }
        else if (responses[0] == 0 && responses[1] == 0 && responses[2] == 0)
        {
            responses[6] = 2;
        }
        else if (responses[0] == 0 && responses[1] == 0 && responses[3] == 0)
        {
            responses[6] = 3;
        }
        else if (responses[0] == 0 && responses[1] == 0 && responses[2] == 1 && responses[5] == 0)
        {
            responses[6] = 4;
        }
        else if (responses[0] == 0 && responses[1] == 0 && responses[3] == 0 && responses[4] == 0)
        {
            responses[6] = 5;
        }
        else if (responses[0] == 0 && responses[1] == 1 && responses[3] == 1 && responses[4] == 1)
        {
            responses[6] = 6;
        }
        else if (responses[0] == 0 && responses[1] == 0 && responses[2] == 1 && responses[5] == 1)
        {
            responses[6] = 7;
        }
        return responses[6];
    }

}
