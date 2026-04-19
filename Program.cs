using System;
using System.Collections.Generic;
using static Library.Library;

namespace Homework3
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<int, string> phoneDictionary = new Dictionary<int, string>();
            int orderNumber = 1;
            string numberName = "";
            Log("Welcome! Phonebook v0.1 is running.");
            Log(
                "Feature list:\n1. Add contact\n2. Edit contact\n3.Delete contact\n4.Search contacts\n5. Show full contact list");
            byte phoneBookChoice = Convert.ToByte(Ask("What do you want to do? (1-5)"));
            if (!ValidateRange(phoneBookChoice, 0, 5))
            {
                ShowError("Invalid choice");
                return;
            }

            switch (phoneBookChoice)

            {
                case 1:
                    try
                    {
                        // Add contact function
                        while (true)
                        {
                            string numberAdd = Ask("\nEnter a phone number");
                            if (numberAdd.Trim().Length != 8)
                            {
                                ShowError("Invalid phone number");
                                return;
                            }

                            phoneDictionary.Add(orderNumber, numberAdd);

                            numberName = Ask("Enter a name for this number");
                            if (numberName.Trim().Length == 0)
                            {
                                ShowError("Name can't be empty");
                                return;
                            }

                            Log("Number added as " + phoneDictionary[orderNumber] + "\n" + numberName);
                            orderNumber++;
                            Log("Want to add another number? (y)");
                            if (Console.ReadKey().KeyChar != 'y')
                                break;
                        }

                        Log("\nPhonebook contents:");
                        foreach (KeyValuePair<int, string> entry in phoneDictionary)
                        {
                            Log($": {entry.Key}:{numberName}\n {entry.Value}\n");
                        }

                        SaveLog(0);
                    }
                    catch (Exception exception)
                    {
                        Log("An error has occured: " + exception.Message);
                        SaveLog(1);
                    }

                    break;

                case 2:
                
                    break;
            }
        }
        
    }
}