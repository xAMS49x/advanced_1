namespace Contact
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>();

        public bool AddContact(string name, string phoneNumber, string address = "")
        {
            if (!ValidationHelper.ValidationHelper.ValidateStringLength(name, 2))
            {
                return false;
            }
            
            if (!ValidationHelper.ValidationHelper.ValidateStringLength(phoneNumber, 10, 12))
            {
                return false;
            }

            _contacts.Add(new Contact(name, phoneNumber, address));
            return true;
        }


        public bool EditContactById(int id, string? newName, string? newPhone, string? newAddress)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.GetId() == id);
            if (contact == null)
            {
                return false;
            }

            return ApplyEdits(contact, newName, newPhone, newAddress);
        }

        public bool EditContactByName(string name, string? newName, string? newPhone, string? newAddress)
        {
            Contact? contact =
                _contacts.FirstOrDefault(c => c.GetName().Equals(name, StringComparison.OrdinalIgnoreCase)
                );
            if (contact == null)
            {
                return false;
            }

            return ApplyEdits(contact, newName, newPhone, newAddress);
        }

        private bool ApplyEdits(Contact contact, string? newName, string? newPhone, string? newAddress)
        {
            bool changed = false;

            if (!string.IsNullOrWhiteSpace(newName))
            {
                if (!ValidationHelper.ValidationHelper.ValidateStringLength(newName, 2))
                {
                    return false;
                }

                contact.SetName(newName.Trim());
                changed = true;
            }

            if (!string.IsNullOrWhiteSpace(newPhone))
            {
                if (!ValidationHelper.ValidationHelper.ValidateStringLength(newPhone, 10, 12))
                {
                    return false;
                }

                contact.SetPhoneNumber(newPhone.Trim());
                changed = true;
            }

            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                contact.SetAddress(newAddress.Trim());
                changed = true;
            }

            return changed;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.GetId() == id);
        }

        public bool DeleteContactById(int id)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.GetId() == id);
            if (contact == null)
            {
                return false;
            }

            _contacts.Remove(contact);
            return true;
        }

        public List<Contact> SearchContacts(string query)
        {
            string q = query.Trim().ToLower();

            return _contacts
                .Where(c =>
                    c.GetName().ToLower().Contains(q) ||
                    c.GetPhoneNumber().ToLower().Contains(q)
                )
                .ToList();
        }
    }
}