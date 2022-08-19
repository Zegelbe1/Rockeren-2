using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Rocker
{

    public class Program
    {

        public static void Main()
        {

            double principal = 1000, interest = 0.25;
            double installment, repayment, interest_amount, remaining_principal;

            int term = 3, month = 1;
            string input = "";

            Console.Write("Welcome to RockerLån A/S! We offer shockingly low interest rates of {0}%/month!\n", interest * 100);

            do
            {
                Console.Write("How much would you like to borrow (between 1000 and 25000)?\n");
                input = Console.ReadLine();
                principal = Convert.ToDouble(input);
            } while (principal < 1000 || principal > 25000); //Checks that the principal amount is valid, loops until valid input is entered

            do
            {
                Console.Write("\nOver how many months would you like to repay your loan?\n (between 3 and 24)\n");
                input = Console.ReadLine();
                term = Convert.ToInt16(input);
            } while (term < 3 && term > 24); //Checks that the entered term is valid, loops until valid input is entered

            Console.Write("Your loan amount is: {0}.\n", principal);
            Console.Write("Your term is: {0} months.\n", term);

            installment = principal * (interest * Math.Pow(1 + interest, term)) / (Math.Pow(1 + interest, term) - 1); //Calculates the installment using the fixed annuity formula

            Console.Write("Your monthly installment is: {0:N2}.\n\n", installment);

            Console.Write("Here is your amortization schedule:\n");
            Console.Write("Month \t Principal \t Installment \t Interest \t Repayment \t Remaining Principal \n");

            do
            {

                interest_amount = principal * interest;
                repayment = installment - interest_amount;
                remaining_principal = principal - repayment;

                Console.Write("{0} \t\t {1:N2} \t {2:N2} \t\t {3:N2} \t\t {4:N2} \t\t {5:N2}\n", month, principal, installment, interest_amount, repayment, remaining_principal);

                principal = remaining_principal; //updates the principal to get the new open principal after repayment
                month++;


            } while (principal > 0.00001); // Outputs the payment schedule by looping till the principal reaches 0

            Thread.Sleep(3000);
            Console.ReadKey();
        }

    }
}
