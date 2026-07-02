using System;

namespace _2_7_task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int correct_pin = 1234;
            float balance = 100;
            int attempts = 0;
            bool isAuthenticated = false;

            
            while (attempts < 3)
            {
                try
                {
                    Console.WriteLine("enter PIN: ");
                    int userpin = int.Parse(Console.ReadLine());
                    if (userpin == correct_pin)
                    {
                        isAuthenticated = true;
                        break;
                    }
                    else
                    {
                        attempts = attempts + 1;
                        Console.WriteLine("wrong pin try again");
                    }
                }
                catch (FormatException)
                {
                    attempts = attempts + 1;
                    Console.WriteLine("wrong type of input try again");
                }
            } 

            
            if (!isAuthenticated)
            {
                Console.WriteLine("Card Blocked");
                return;
            }

            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nATM MENU");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3) Check Balance");
                Console.WriteLine("4) Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.Write("enter deposit amount: ");
                            float deposit = float.Parse(Console.ReadLine());
                            if (deposit <= 0)
                            {
                                Console.WriteLine("error: Deposit amount must be positive.");
                            }
                            else
                            {
                                balance = balance + deposit;
                                Console.WriteLine("deposit done");
                                Console.WriteLine("current balance: " + balance);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wrong type of input try again");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.Write("enter withdrawal amount: ");
                            float withdrawal = float.Parse(Console.ReadLine());
                            if (withdrawal <= 0)
                            {
                                Console.WriteLine("error: Withdrawal amount must be positive.");
                            }
                            else if (withdrawal > balance)
                            {
                                Console.WriteLine("error: Insufficient funds.");
                            }
                            else
                            {
                                balance = balance - withdrawal;
                                Console.WriteLine("withdrawal done");
                                Console.WriteLine("current balance: " + balance);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wrong type of input try again");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Your current balance is: " + balance);
                        break;

                    case 4:
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select an option from 1 to 4.");
                        break;
                }
            } 
        } 
    } 
}