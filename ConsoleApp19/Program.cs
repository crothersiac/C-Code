using System;

namespace ConsoleApp19
{
    class Program
    {
        public static void Main(string[] args)
        {

            LoanCalculator calculator1 = new LoanCalculator();

            calculator1.LoanPayment();
            calculator1.DisplayLoan();

        }
        public static double Input(string msg)
        {
            double input;
            Console.WriteLine(msg);
            input = Convert.ToDouble(Console.ReadLine());
            while (input <= 0)
            {
                Console.WriteLine("Please enter a valid input value!");
                Console.WriteLine(msg);
                input = Convert.ToDouble(Console.ReadLine());
            }
            return input;
        }
    }

    class LoanCalculator
    {
        double cashflow;
        double loan;
        double loanperiod;
        double MI_rates;
        double payment;

        public void LoanPayment()
        {
            cashflow = Program.Input("What are your current cash flows?: ");
            loan = Program.Input("What is the current loan amount that you have: ");
            loanperiod = Program.Input("What is the loan period for that loan?: ");
            MI_rates = Program.Input("What is the monthly interest rate (in %): ");

            payment = (loan * MI_rates / 100) / (1 - 1 / (Math.Pow(1 + MI_rates / 100, loanperiod)));
        }

        public void DisplayLoan()
        {
            Console.WriteLine("Your calculated monthly loan payment would be: {0:C}", payment);
        }
    }
}





