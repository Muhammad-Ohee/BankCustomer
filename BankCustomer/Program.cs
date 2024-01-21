//Console.WriteLine("Hello, OS");

using BankCustomer.Models;

namespace BankManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // bank based
            
            using (var dbContext = new ApplicationDbContext())
            {
                // Retrieve data from the database               
                var banksWithCustomers = dbContext.Banks
                    .Select(bank => new
                    {
                        Bank = bank,
                        Customers = bank.Customers.Select(bc => bc.Customer)
                    })
                    .ToList();
                

                // Display banks and associated customers
                foreach (var bankWithCustomers in banksWithCustomers)
                {
                    var bank = bankWithCustomers.Bank;
                    Console.WriteLine($"{bank.Id} | {bank.Name} | {bank.BankCode} | {bank.Branch}");

                    Console.WriteLine("Customers:");
                    foreach (var customer in bankWithCustomers.Customers)
                    {
                        Console.WriteLine($"{customer.Id} | {customer.FirstName} {customer.LastName} | {customer.Address} | {customer.PhoneNumber} | {customer.BankBalance}");
                    }

                    Console.WriteLine();
                }
            }
            


            // customer based
            /*
            using (var dbContext = new ApplicationDbContext())
            {
                // Retrieve data from the database
                var customersWithBanks = dbContext.Customers
                    .Select(customer => new
                    {
                        Customer = customer,
                        Banks = customer.Banks.Select(bc => bc.Bank)
                    })
                    .ToList();

                // Display customers and associated banks
                foreach (var customerWithBanks in customersWithBanks)
                {
                    var customer = customerWithBanks.Customer;
                    //Console.WriteLine($"{customer.Id} | {customer.FirstName} {customer.LastName} | {customer.Address} | {customer.PhoneNumber} | {customer.BankBalance}");
                    Console.WriteLine($"{customer.Id} | {customer.FirstName} {customer.LastName}");


                    Console.WriteLine("Banks:");
                    foreach (var bank in customerWithBanks.Banks)
                    {
                        Console.WriteLine($"{bank.Id} | {bank.Name} | {bank.BankCode} | {bank.Branch}");
                    }

                    Console.WriteLine();
                }
            }
            */


            /*
            using (var dbContext = new ApplicationDbContext())
            {
                // Retrieve data from the database
                var banks = dbContext.Banks.ToList();

                // Display banks
                Console.WriteLine("Banks:");
                foreach (var bank in banks)
                {
                    Console.WriteLine($"{bank.Id} | {bank.Name} | {bank.BankCode} | {bank.Branch}");

                    Console.WriteLine("Customers:");

                    // Display customers associated with the bank
                    foreach (var bankCustomer in bank.Customers)
                    {
                        var customer = bankCustomer.Customer;
                        Console.WriteLine($"{customer.Id} | {customer.FirstName} {customer.LastName} | {customer.Address} | {customer.PhoneNumber} | {customer.BankBalance}");
                    }

                    Console.WriteLine();
                }
            }
            */






            /*
            // seeding to data base
            using (var dbContext = new ApplicationDbContext())
            {
                // Add sample data
                // Add sample data for banks
                var bank1 = new Bank { Name = "Bank A", BankCode = "001", Branch = "Main Branch" };
                var bank2 = new Bank { Name = "Bank B", BankCode = "002", Branch = "Downtown Branch" };
                var bank3 = new Bank { Name = "Bank C", BankCode = "003", Branch = "East Side Branch" };
                var bank4 = new Bank { Name = "Bank D", BankCode = "004", Branch = "West Side Branch" };

                // Add sample data for customers
                var customer1 = new Customer { FirstName = "John", LastName = "Doe", Address = "123 Main St", PhoneNumber = "555-1234", BankBalance = 1000.00m };
                var customer2 = new Customer { FirstName = "Jane", LastName = "Smith", Address = "456 Oak St", PhoneNumber = "555-5678", BankBalance = 1500.00m };
                var customer3 = new Customer { FirstName = "Bob", LastName = "Johnson", Address = "789 Pine St", PhoneNumber = "555-9876", BankBalance = 2000.00m };
                var customer4 = new Customer { FirstName = "Alice", LastName = "Williams", Address = "101 Maple St", PhoneNumber = "555-4321", BankBalance = 1200.00m };
                var customer5 = new Customer { FirstName = "Charlie", LastName = "Brown", Address = "202 Elm St", PhoneNumber = "555-8765", BankBalance = 1800.00m };
                var customer6 = new Customer { FirstName = "Eva", LastName = "Davis", Address = "303 Cedar St", PhoneNumber = "555-1111", BankBalance = 1600.00m };
                var customer7 = new Customer { FirstName = "Frank", LastName = "Taylor", Address = "404 Birch St", PhoneNumber = "555-2222", BankBalance = 1900.00m };
                var customer8 = new Customer { FirstName = "Grace", LastName = "Miller", Address = "505 Walnut St", PhoneNumber = "555-3333", BankBalance = 1400.00m };



                // Associate customers with banks
                var bankCustomer1 = new BankCustomer.Models.BankCustomer { Bank = bank1, Customer = customer1 };
                var bankCustomer2 = new BankCustomer.Models.BankCustomer { Bank = bank2, Customer = customer1 };
                var bankCustomer3 = new BankCustomer.Models.BankCustomer { Bank = bank1, Customer = customer2 };
                var bankCustomer4 = new BankCustomer.Models.BankCustomer { Bank = bank3, Customer = customer2 };
                var bankCustomer5 = new BankCustomer.Models.BankCustomer { Bank = bank2, Customer = customer3 };
                var bankCustomer6 = new BankCustomer.Models.BankCustomer { Bank = bank4, Customer = customer3 };
                var bankCustomer7 = new BankCustomer.Models.BankCustomer { Bank = bank3, Customer = customer4 };
                var bankCustomer8 = new BankCustomer.Models.BankCustomer { Bank = bank4, Customer = customer5 };


                dbContext.AddRange(
                    bank1, bank2, bank3, bank4,
                    customer1, customer2, customer3, customer4, customer5, customer6, customer7, customer8,
                    bankCustomer1, bankCustomer2, bankCustomer3, bankCustomer4, bankCustomer5, bankCustomer6, bankCustomer7, bankCustomer8
                );

                dbContext.SaveChanges();

                Console.WriteLine("Dummy data added successfully.");
            }
            */
        }
    }
}