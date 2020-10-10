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
        double Balance = 1.23; // chnage to 0.00 beofre hand in, default value only for testing purposes
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

            VendingData[0].ProductName = " Mars bar";
            VendingData[1].ProductName = " Twix";
            VendingData[2].ProductName = " Snicker";
            VendingData[3].ProductName = " Cadbury";
            VendingData[4].ProductName = " Crisps";
            VendingData[5].ProductName = " Water";
            VendingData[6].ProductName = " OrangeJ";
            VendingData[7].ProductName = " AppleJ";
            VendingData[8].ProductName = " Iced tea";
            VendingData[9].ProductName = "Pepsi";

            VendingData[0].ProductPrice = 0.80;
            VendingData[1].ProductPrice = 0.80;
            VendingData[2].ProductPrice = 0.80;
            VendingData[3].ProductPrice = 0.90;
            VendingData[4].ProductPrice = 1.10;
            VendingData[5].ProductPrice = 0.50;
            VendingData[6].ProductPrice = 1.20;
            VendingData[7].ProductPrice = 1.20;
            VendingData[8].ProductPrice = 1.25;
            VendingData[9].ProductPrice = 1.45;
            Menu(VendingData, ref Balance);
        }
        
    }
    static void Menu(MachineInfo[] VendingData, ref double Balance)
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
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }




    }
    static void BuyProduct(MachineInfo[] VendingData, ref double Balance)
    {
        Console.WriteLine("Please enter the Number of the item you would like to purchase");
        int ChosenID = int.Parse(Console.ReadLine());
        double ItemCost = VendingData[ChosenID - 1].ProductPrice;
        string ItemName = VendingData[ChosenID - 1].ProductName;

        if (ChosenID >= 1 && ChosenID <= 10)
        {
            if (Balance >= ItemCost)
            {
                Balance = Balance - ItemCost;
                Console.WriteLine("Your {0} has been purchased and will now be dispensed below. Your current balance is £{1}", ItemName, Balance);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, this product is too expensive. Please add more funds or selet a cheaper product.");
                return;
            }

        }
        else
        {
            Console.WriteLine("Wrong product Number, please try again.");
            Console.Clear();
            Menu(VendingData, ref Balance);
        }
    }
    static double AddMoney(ref double Balance)
    {
        Console.WriteLine("Please press the button for how much money for what coin you are entering: \n 1. £2 \n 2. £1 \n 3. 50p \n 4. 20p \n 5. 10p ");
        int ChosenCoin = int.Parse(Console.ReadLine());
        switch(ChosenCoin)
        {
            case 1:
                Balance += 2;
                Console.WriteLine("Your balance is now £{0}", Balance);
                return Balance;
                break;
            case 2:
                Balance += 1;
                Console.WriteLine("Your balance is now £{0}", Balance);
                return Balance;
                break;
            case 3:
                Balance += 0.50;
                Console.WriteLine("Your balance is now £{0}", Balance);
                return Balance;
                break;
            case 4:
                Balance += 0.20;
                Console.WriteLine("Your balance is now £{0}", Balance);
                return Balance;
                break;
            case 5:
                Balance += 0.10;
                Console.WriteLine("Your balance is now £{0}", Balance);
                return Balance;
                break;
            default:
                Console.WriteLine("Invalid unit of currency. please try again");
                Console.WriteLine("Your balance is still £{0}", Balance);
                return Balance;
                break;

        }

    }
}
