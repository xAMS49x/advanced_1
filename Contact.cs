namespace Contact
{
    public class Contact
    {
        private int _id = 0;
        private static int _autoInc = 1;
        private string _name = "";
        private string _phoneNumber = "";
        private string _address = "";

        public Contact(string name, string phoneNumber, string address = "")
        {
            this._id = _autoInc++;

            this._name = name;
            this._phoneNumber = phoneNumber;
            this._address = address;
        }

        public int GetId() { return _id; }

        public string GetName() { return _name; }
        public void SetName(string name)
        {
            if (name.Trim().Length != 0)
            {
                this._name = name;
            }
        }

        public string GetPhoneNumber() { return _phoneNumber; }
        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Trim().Length != 0)
            {
                this._phoneNumber = phoneNumber;
            }
        }

        public string GetAddress() { return _address; }
        public void SetAddress(string address)
        {
            if (address.Trim().Length != 0)
            {
                this._address = address;
            }
        }

        public override string ToString()
        {
            string addressPart = _address.Trim().Length > 0 ? $" | Address: {_address}" : "";
            return $"[ID: {_id}] {_name} — {_phoneNumber}{addressPart}";
        }
    }
}
