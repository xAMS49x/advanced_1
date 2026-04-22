using static Library.Library;
using static ContactService.ContactService;

namespace Contact;

internal class Program
{
    private static void Main()
    {
        Log("Welcome! Phonebook v0.2.0 is running.");

        while (true)
        {
            Console.WriteLine();
            Log("════════════════════════════════");
            Log("         PHONEBOOK MENU         ");
            Log("════════════════════════════════");
            Log("1. Add contact");
            Log("2. Edit contact by ID");
            Log("3. Edit contact by Name");
            Log("4. Show all contacts");
            Log("5. Find contact by ID");
            Log("6. Delete contact by ID");
            Log("7. Search by name or phone");
            Log("0. Exit");
            Log("════════════════════════════════");

            var input = Ask("Choose an option (0–7):");
            if (!byte.TryParse(input, out var choice))
                throw new Exception("Enter a number between 0 and 7 only.");


            Console.WriteLine();

            switch (choice)
            {
                case 0:
                    Log("See you soon!\nShutting down...");
                    SaveLog();
                    return;

                case 1:
                    HandleAddContact();
                    break;

                case 2:
                    HandleEditById();
                    break;

                case 3:
                    HandleEditByName();
                    break;

                case 4:
                    HandleShowAll();
                    break;

                case 5:
                    HandleFindById();
                    break;

                case 6:
                    HandleDeleteById();
                    break;

                case 7:
                    HandleSearch();
                    break;

                default:
                    throw new Exception("Invalid option");
            }
        }
    }
}

//AMS (GitHub: xAMS49x) 2026. All rights reserved. 