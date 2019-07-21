using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBook
    {
        List<Address> addresses;

        public AddressBook()
        {
            addresses = new List<Address>();
        }

        public bool Add(string name, string address)
        {
            Address addr = new Address(name, address);
            Address result = Find(name);

            if (result == null)
            {
                addresses.Add(addr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(string name)
        {
            Address addr = Find(name);

            if (addr != null)
            {
                addresses.Remove(addr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void List(Action<Address> action)
        {
            addresses.ForEach(action);
        }

        public bool IsEmpty()
        {
            if (addresses.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Address Find(string name)
        {
            Address addr = addresses.Find(
                delegate(Address a) 
                {
                    return a.name == name;
                }
            );

            return addr;
        }
    }
}
