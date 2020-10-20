
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MainClass
{

    public struct MachineInfo
    {
        public int ProductID;
        public string ProductName;
        public double ProductPrice;
    }

    public static void Main(string[] args)
    {
        double Balance = 0.00; // chnage to 0.00 beofre hand in, default value only for testing purposes
        int Repeat = 1;
        while (Repeat == 1)
        {
            MachineInfo[] VendingData = new MachineInfo[10];
            VendingData[0].ProductID = 01;
            VendingData[1].ProductID = 02;
            VendingData[2].ProductID = 03;
            VendingData[3].ProductID = 04;
            VendingData[4].ProductID = 05;
            VendingData[5].ProductID = 06;
            VendingData[6].ProductID = 07;
            VendingData[7].ProductID = 08;
            VendingData[8].ProductID = 09;
            VendingData[9].ProductID = 10;

            VendingData[0].ProductName = " Mars-bar    ";
            VendingData[1].ProductName = " Twix      ";
            VendingData[2].ProductName = " Snicker     ";
            VendingData[3].ProductName = " Cadbury     ";
            VendingData[4].ProductName = " Crisps     ";
            VendingData[5].ProductName = " Water     ";
            VendingData[6].ProductName = " Fanta     ";
            VendingData[7].ProductName = " Powerade    ";
            VendingData[8].ProductName = " Iced-tea    ";
            VendingData[9].ProductName = "Pepsi      ";

            VendingData[0].ProductPrice = 0.80;
            VendingData[1].ProductPrice = 0.80;
            VendingData[2].ProductPrice = 0.80;
            VendingData[3].ProductPrice = 0.90;
            VendingData[4].ProductPrice = 1.10;
            VendingData[5].ProductPrice = 0.50;
            VendingData[6].ProductPrice = 1.20;
            VendingData[7].ProductPrice = 1.20;
            VendingData[8].ProductPrice = 1.30;
            VendingData[9].ProductPrice = 1.50;
            Menu(VendingData, ref Balance, ref Repeat);
        }

    }
    static void Menu(MachineInfo[] VendingData, ref double Balance, ref int Repeat)
    {

        int MenuChoice = 0;
        Console.WriteLine("Welcome to the vending Machine: \n\n---------------------------------------------------------------------\n");
        for (int j = 0; j <= 9; j++)
        {

            Console.Write(VendingData[j].ProductID + ":    ");
            Console.Write(VendingData[j].ProductName);
            Console.Write('\t' + "      Price: £" + VendingData[j].ProductPrice + "\n");
        }
        Console.WriteLine("\nYour balance is £{0}", Balance);
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("\nEnter a choice from the list below: \n 1. Purchase a product \n 2. Update balance \n 3. Exit");
        MenuChoice = int.Parse(Console.ReadLine());

        switch (MenuChoice)
        {
            case 1:
                BuyProduct(VendingData, ref Balance);
                break;
            case 2:
                AddMoney(ref Balance);
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("You have been refunded £{0}. Have a Nice Day", Balance);
                Balance = 0;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid option. Please try again.");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                break;

        }




    }
    static double BuyProduct(MachineInfo[] VendingData, ref double Balance)
    {
        Console.WriteLine("Please enter the Number of the item you would like to purchase");
        int ChosenID = int.Parse(Console.ReadLine());
        double ItemCost = VendingData[ChosenID - 1].ProductPrice;
        string ItemName = VendingData[ChosenID - 1].ProductName.Replace(" ", String.Empty);;

        if (ChosenID >= 1 && ChosenID <= 10)
        {
            if (Balance >= ItemCost)
            {
                Console.Clear();
                Balance = Balance - ItemCost;
                Math.Round(Balance, 2);
                Console.WriteLine("---------------------------------------------------------------\nYour {0} has been purchased and will now be dispensed below.\nYour current balance is £{1}\n---------------------------------------------------------------", ItemName, Balance);
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
                return Balance;
            }
            else
            {
              double CostDifference = ItemCost - Balance;
              Console.Clear();
              Console.WriteLine("-------------------------------------------------------\nYour balance is too low, please add £{0} more and try again.  \n you have not been charged \n Click to return to main menu\n-------------------------------------------------------", CostDifference);
              Console.ReadKey();
              Console.Clear();
              return Balance;
            }

        }
        else
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------\nInvalid item number, please try again. \n-------------------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            return Balance;
        }
    }
    static double AddMoney(ref double Balance)
    {
        Console.WriteLine("-------------------------------------------------------\nPlease press the button for what coin you are entering: \n 1. £2 \n 2. £1 \n 3. 50p \n 4. 20p \n 5. 10p ");
        int ChosenCoin = int.Parse(Console.ReadLine());
        switch (ChosenCoin)
        {
            case 1:
                Balance += 2;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYour balance is now £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
            case 2:
                Balance += 1;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYour balance is now £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
            case 3:
                Balance += 0.50;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYour balance is now £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
            case 4:
                Balance += 0.20;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYour balance is now £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
            case 5:
                Balance += 0.10;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYour balance is now £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
            default:
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------\nYou have not pressed a valid number.\nYour balance is still £{0} \nClick to return to main menu\n-------------------------------------------------------", Balance);
                Console.ReadKey();
                Console.Clear();
                return Balance;
        }
    }
}