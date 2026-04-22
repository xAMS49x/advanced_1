using Contact;
using static Library.Library;

namespace ContactService
{
    public class ContactService
    {
        static Contact.ContactService service = new Contact.ContactService();

        public static void HandleAddContact()
        {
            Log("── Add New Contact ──");

            string name = Ask("Enter contact name (min 2 characters):");
            string phone = Ask("Enter phone number (10–12 digits):");
            string address = Ask("Enter address (optional, press Enter to skip):");

            bool success = service.AddContact(name, phone, address);

            if (success)
            {
                Log($"✓ Contact \"{name}\" successfully added!");
            }
            else
            {
                throw new Exception(
                    "Failed to add contact. Check that:\n  • Name is at least 2 characters\n  • Phone number is between 10 and 12 characters");
            }
        }

        public static void HandleEditById()
        {
            Log("── Edit Contact by ID ──");

            string idInput = Ask("Enter contact ID:");
            if (!int.TryParse(idInput, out int id))
                throw new Exception("Invalid ID format.");

            Contact.Contact? contact = service.GetContactById(id);
            if (contact == null)
                throw new Exception($"No contact found with ID {id}.");

            Log($"Editing: {contact}");
            Log("(Press Enter to keep the current value)");

            string newName = Ask($"New name [{contact.GetName()}]:");
            string newPhone = Ask($"New phone [{contact.GetPhoneNumber()}]:");
            string newAddress = Ask($"New address [{contact.GetAddress()}]:");

            bool success = service.EditContactById(id, newName, newPhone, newAddress);

            if (success)
            {
                Log($"✓ Contact with ID {id} successfully updated!");
                Log($"  {service.GetContactById(id)}");
            }
            else
            {
                throw new Exception(
                    "Update failed. Check that:\n  • Name is at least 2 characters\n  • Phone number is between 10 and 12 characters");
            }
        }

        public static void HandleEditByName()
        {
            Log("── Edit Contact by Name ──");

            string searchName = Ask("Enter the exact contact name to edit:");

            List<Contact.Contact> found = service.SearchContacts(searchName);
            if (found.Count == 0)
                throw new Exception($"No contact found with name \"{searchName}\".");


            Contact.Contact? target = null;
            if (found.Count > 1)
            {
                Log("Multiple contacts found:");
                foreach (var c in found) Log($"  {c}");
                Log("Please use option 2 (Edit by ID) to select a specific contact.");
                return;
            }
            else
            {
                target = found[0];
            }

            Log($"Editing: {target}");
            Log("(Press Enter to keep the current value)");

            string newName = Ask($"New name [{target.GetName()}]:");
            string newPhone = Ask($"New phone [{target.GetPhoneNumber()}]:");
            string newAddress = Ask($"New address [{target.GetAddress()}]:");

            bool success = service.EditContactByName(target.GetName(), newName, newPhone, newAddress);

            if (success)
            {
                Log($"Contact \"{searchName}\" successfully updated!");
            }
            else
            {
                throw new Exception(
                    "Update error. Check if:\n  1. Name is at least 2 characters\n  2. Phone number is between 10 and 12 characters");
            }
        }

        public static void HandleShowAll()
        {
            Log("── All Contacts ──");

            List<Contact.Contact> all = service.GetAllContacts();
            if (all.Count == 0)
            {
                Log("  (no contacts yet)");
                return;
            }

            foreach (Contact.Contact c in all)
            {
                Log($"  {c}");
            }

            Log($"\nTotal: {all.Count} contact(s).");
        }

        public static void HandleFindById()
        {
            Log("── Find Contact by ID ──");

            string idInput = Ask("Enter contact ID:");
            if (!int.TryParse(idInput, out int id))
                throw new Exception("Invalid ID format.");

            Contact.Contact? contact = service.GetContactById(id);
            if (contact == null)
            {
                throw new Exception($"No contact found with ID {id}.");
            }

            Log($"Found: {contact}");
        }

        public static void HandleDeleteById()
        {
            Log("── Delete Contact by ID ──");

            string idInput = Ask("Enter contact ID to delete:");
            if (!int.TryParse(idInput, out int id))
                throw new Exception("Invalid ID format.");


            Contact.Contact? contact = service.GetContactById(id);
            if (contact == null)
                throw new Exception($"No contact found with ID {id}.");


            Log($"You are about to delete: {contact}");
            string confirm = Ask("Are you sure? (y):");

            if (confirm.Trim().ToLower() == "y")
            {
                bool success = service.DeleteContactById(id);
                if (success)
                    Log($"Contact with ID {id} successfully deleted.");
                else
                    throw new Exception("Deletion failed.");
            }
            else
            {
                Log("Deletion cancelled.");
            }
        }


        public static void HandleSearch()
        {
            Log("── Search Contacts ──");

            string query = Ask("Enter part of name or phone number:");
            List<Contact.Contact> results = service.SearchContacts(query);

            if (results.Count == 0)
            {
                Log($"  No contacts found matching \"{query}\".");
            }
            else
            {
                Log($"  Found {results.Count} contact(s):");
                foreach (Contact.Contact c in results)
                {
                    Log($"  {c}");
                }
            }
        }
    }
}