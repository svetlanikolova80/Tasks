using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class Program
    {
        AddressBook book;

        public Program()
        {
            book = new AddressBook();
        }

        static void Main(string[] args)
        {
            string selection = "";
            Program program = new Program();
            program.DisplayMenu();
            while (!selection.ToUpper().Equals("Q"))
            {
                Console.WriteLine("Selection: ");
                selection = Console.ReadLine();
                program.PerformAction(selection);
            }
        }

        public void PerformAction(string selection)
        {
            string name = "";
            string address = "";

            switch (selection.ToUpper())        
            {
                case "A":
                    Console.WriteLine("Enter name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter address: ");
                    address = Console.ReadLine();

                    if (book.Add(name, address))
                    {
                        Console.WriteLine("address added");
                    }
                    else
                    {
                        Console.WriteLine("address exists");
                    }

                    break;

                case "D":
                    Console.WriteLine("Enter address: ");
                    name = Console.ReadLine();

                    if (book.Remove(name))
                    {
                        Console.WriteLine("address removed");
                    }
                    else
                    {
                        Console.WriteLine("address does not exist");
                    }

                    break;

                case "L":
                    if (book.IsEmpty())
                    {
                        Console.WriteLine("No entries");
                    }
                    else
                    {
                        Console.WriteLine("Addresses: ");
                        book.List(
                            delegate(Address a) 
                            {
                                Console.WriteLine("{0} - {1}", a.name, a.address);
                            }
                        );
                    }
                    break;

                case "E":
                    Console.WriteLine("Enter name");
                    name = Console.ReadLine();
                    Address addr = book.Find(name);

                    if (addr == null)       
                    {
                        Console.WriteLine("Address not found");
                    }
                    else
                    {
                        Console.WriteLine("Enter name again: ");
                        addr.address = Console.ReadLine();
                        Console.WriteLine("Address updated");
                    }
                    break;
                default:
                    break;
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("A - add");
            Console.WriteLine("D - delete");
            Console.WriteLine("E - edit");
            Console.WriteLine("L - list");
            Console.WriteLine("Q - quit");
        }
    }
}
