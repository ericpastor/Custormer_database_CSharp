using CustomerManagement;
using CustomerDataBaseManagement;

public class Program
{
    public static void Main()
    {
        // var customers = new CustomerDataBase();
        // // string[] customerData = FileHelper.GetAllCustomer();

        // // foreach (string line in customerData)
        // // {
        // //     string[] lineData = line.Split(',');
        // //     if (lineData.Length >= 5)
        // //         customers.AddCustomer(new Customer(lineData[1], lineData[2], lineData[3], lineData[4]));
        // // }

        // while (true)
        // {
        //     var s1 = new Customer("Ernst", "Aib", "a@a", "c.Roma");
        //     var s2 = new Customer("Ramon", "Peluda", "r@r", "c.Tren");
        //     var s3 = new Customer("Erc", "Pas", "p@p", "c.Coche");
        //     var s4 = new Customer("Marc", "Zas", "w@w", "c.Mesa");
        //     var s5 = new Customer("Pau", "Mas", "p@p", "c.Silla");

        //     Console.WriteLine("Customer Management");
        //     Console.WriteLine("Write the number option to proceed");
        //     Console.WriteLine("1. Program");
        //     Console.WriteLine("2. Program with Console");
        //     Console.WriteLine("3. Exit");

        //     string? options = Console.ReadLine();

        //     switch (options)
        //     {
        //         case "1":
        Console.WriteLine($"--------ESTO ES LA PRUEBA-------------");
        using (var fh = new FileHandler("customers.csv"))
        {
            fh.ReadData();
        }
        Console.WriteLine($"--------ESTO ES LA PRUEBA-------------");

        //                 customers.AddCustomer(s1);
        //                 customers.AddCustomer(s2);
        //                 customers.AddCustomer(s3);
        //                 customers.AddCustomer(s4);
        //                 customers.AddCustomer(s5);

        //                 // foreach (Customer customer in customers)
        //                 // {
        //                 //     string customerString = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
        //                 //     if (!FileHelper.RecordExistsInCsv(customerString))
        //                 //         FileHelper.AddNewCustomer(customerString);
        //                 // }

        //                 Console.WriteLine("All customers:");
        //                 customers.PrintCustomers();

        //                 Console.WriteLine("");

        //                 Console.WriteLine("Customer by Id (2):");
        //                 Console.WriteLine(customers.GetCustomerByIdAsync(2).GetAwaiter().GetResult());

        //                 Console.WriteLine("");

        //                 Console.WriteLine("Updating Customer:");
        //                 var update = new CustomerUpdateDTO(firstName: "Anxo", lastName: "Romas", address: "c.Turro");
        //                 int id = 2;
        //                 Console.WriteLine(customers.UpdateCustomer(id, update));

        //                 Console.WriteLine("");

        //                 Console.WriteLine("Deleting Customer:");
        //                 var email = "a@a";
        //                 customers.DeleteCustomer(email);
        //                 // FileHelper.RemoveCustomer(email);

        //                 Console.WriteLine("List of customers after deleting one:");
        //                 customers.PrintCustomers();

        //                 Console.WriteLine("");

        //                 customers.Undo();
        //                 Console.WriteLine("List of customers after Undo:");
        //                 customers.PrintCustomers();

        //                 Console.WriteLine("");

        //                 customers.Redo();
        //                 Console.WriteLine("List of customers after Redo the Undo:");
        //                 customers.PrintCustomers();
        //                 break;

        //             case "2":
        //                 while (true)
        //                 {
        //                     Console.WriteLine("1. Add new customer");
        //                     Console.WriteLine("2. Show all customers");
        //                     Console.WriteLine("3. Search customer by Id");
        //                     Console.WriteLine("4. Delete customer by email");
        //                     Console.WriteLine("5. Update customers fields");
        //                     Console.WriteLine("6. Undo");
        //                     Console.WriteLine("7. Exit");

        //                     string? optionsMenu2 = Console.ReadLine();

        //                     switch (optionsMenu2)
        //                     {
        //                         case "1":
        //                             customers.InputsAddCustomer();
        //                             break;

        //                         case "2":
        //                             customers.PrintCustomers();
        //                             break;

        //                         case "3":
        //                             Console.Write("Enter the Id of the customer you want to search for: ");
        //                             var inputUserId = Console.ReadLine();
        //                             int inputId;
        //                             string? item = inputUserId;

        //                             if (int.TryParse(item, out int number))
        //                             {
        //                                 inputId = number;
        //                             }
        //                             else
        //                             {
        //                                 Console.WriteLine("We couldn't convert the input to a number");
        //                                 continue;
        //                             }
        //                             var customer = customers.GetCustomerByIdAsync(inputId).GetAwaiter().GetResult();
        //                             if (customer != null)
        //                             {
        //                                 Console.WriteLine($"{customer}");

        //                             }
        //                             else
        //                             {
        //                                 Console.WriteLine("Customer not found.");
        //                             }
        //                             break;

        //                         case "4":
        //                             Console.WriteLine("Introduce an email to delete customer:");
        //                             var inputToDelete = Console.ReadLine();
        //                             customers.DeleteCustomer(inputToDelete);
        //                             customers.PrintCustomers();
        //                             break;

        //                         case "5":
        //                             Console.WriteLine("Introduce an email to update customer:");
        //                             var inputToUpdate = Console.ReadLine();
        //                             customers.UpdateFields(inputToUpdate);
        //                             break;

        //                         case "6":
        //                             customers.Undo();
        //                             break;

        //                         case "7":
        //                             Console.WriteLine("Program Terminated. See you next time!");
        //                             Environment.Exit(0);
        //                             break;

        //                         default:
        //                             Console.WriteLine("Invalit Option! Write number option");
        //                             break;
        //                     }
        //                 }

        //             case "3":
        //                 Console.WriteLine("Program Terminated. See you next time!");
        //                 Environment.Exit(0);
        //                 break;

        //             default:
        //                 Console.WriteLine("Invalit Option! Write number option");
        //                 break;
        //         }
        //     }
    }
}