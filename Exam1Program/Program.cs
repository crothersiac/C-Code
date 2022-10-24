using System;

namespace Exam1Program
{
    class Program
    {
        static void Main(string[] args)
        {
            double gas = 0;
            double restaurant = 0;
            double retailers = 0;
            double other = 0;

            //Takes in input from the user regarding their repsective credit card purchases.
            //It then uses a few formulas to create their unique cash-back rewards.

            Console.WriteLine("==============Credit Card Cash Rewards Calculator==============");
            Console.WriteLine("Please enter the amount paid using that credit card when purchasing gas: ");
            gas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the amount paid with that credit card when traveling or using a restaurant: ");
            restaurant = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the amount paid with that credit card for all other purchases at the selected reatilers: ");
            retailers = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the amount paid with that credit card for all other purchases: ");
            other = Convert.ToDouble(Console.ReadLine());

            double rewards_gas = gas * 0.04;
            double rewards_restaurant = restaurant * 0.03;
            double rewards_retailers = retailers * 0.02;
            double rewards_other = other * 0.01;

            decimal total = Convert.ToDecimal(rewards_gas + rewards_restaurant + rewards_other + rewards_retailers);
            decimal total_rewards = Math.Round(total,2);

            Console.WriteLine("You earned $"+total_rewards +" in total cash rewards using that credit card.");
        }
    }
}
