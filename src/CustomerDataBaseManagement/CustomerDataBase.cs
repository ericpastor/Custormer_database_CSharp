using System.Collections;
using System.Text;
using CustomerDatabase.src.Helper;
using CustomerManagement;
namespace CustomerDataBaseManagement;

class CustomerDataBase : IEnumerable<Customer>
{
    private List<Customer> _customers;
    // string[] customerData = FileHelper.GetAllCustomer();
    public List<CustomerReadDTO> Customers
    {
        get
        {
            var allCustomers = _customers.Select(customer => new CustomerReadDTO
            (
                id: customer.Id,
                firstName: customer.FirstName,
                lastName: customer.LastName,
                email: customer.Email,
                address: customer.Address
            )).ToList();
            return allCustomers;
        }
    }

    Stack<List<Customer>> undoStack;
    Stack<List<Customer>> redoStack;
    // const string CUSTOMERS_FILE = "customers.csv";

    public CustomerDataBase()
    {
        _customers = new List<Customer>();
        undoStack = new Stack<List<Customer>>();
        redoStack = new Stack<List<Customer>>();
    }

    public bool AddCustomer(Customer customer)
    {
        if (!_customers.Any(c => c.Email == customer.Email))
        {
            _customers.Add(customer);
            SaveStateInUndo();
            ClearStateInRedo();
            return true;
        }
        Console.WriteLine($"We couldn't create {customer}\nThe emil must be unique. Try with another email");
        return false;
    }

    public void InputsAddCustomer()
    {
        Console.Write("FirtsName: ");
        string? firstName = Console.ReadLine();

        Console.Write("LastName: ");
        string? lastName = Console.ReadLine();

        Console.Write("Email: ");
        string? email = Console.ReadLine();

        while (_customers.Any(customer => customer.Email == email))
        {
            Console.WriteLine("Sorry but that email is already in the system");
            Console.Write("Email: ");
            email = Console.ReadLine();
        }

        Console.Write("Address: ");
        string? address = Console.ReadLine();

        var newCustomer = new Customer(firstName, lastName, email, address);
        AddCustomer(newCustomer);
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        try
        {
            var task = new Task<Customer?>(
                () => _customers.Find(c => c.Email == email)
                );
            task.Start();

            return await task;
        }
        catch (ExceptionHandler)
        {
            throw ExceptionHandler.CustomerNotFound();
        }
    }

    public async Task<CustomerReadDTO?> GetCustomerByIdAsync(int id)
    {
        try
        {
            var task = new Task<CustomerReadDTO?>(
                () => Customers.Find(c => c.Id == id)
                );
            task.Start();

            return await task;
        }
        catch (ExceptionHandler)
        {
            throw ExceptionHandler.CustomerNotFound();
        }
    }

    public void DeleteCustomer(string? email)
    {
        if (email != null)
        {
            var customerToDelete = GetCustomerByEmailAsync(email).GetAwaiter().GetResult();
            if (customerToDelete != null)
            {
                _customers.Remove(customerToDelete);
                SaveStateInUndo();
                ClearStateInRedo();

                Console.WriteLine($"Customer with email {email} deleted");
            }
            else
            {
                Console.WriteLine($"Customer with email {email} not found");

            }

        }
    }

    public bool UpdateCustomer(int id, CustomerUpdateDTO update)
    {
        var foundCustomer = _customers.Find(c => c.Id == id);
        if (foundCustomer is not null)
        {
            foundCustomer.UpdateCustomer(update);
            SaveStateInUndo();
            ClearStateInRedo();

            //     FileHelper.UpdateCustomer
            //    (
            //        foundCustomer.Id,
            //        foundCustomer.FirstName, update.FirstName,
            //        foundCustomer.LastName, update.LastName,
            //        foundCustomer.Address, update.Address
            //    );

            Console.WriteLine(foundCustomer);
            return true;
        }

        return false;
    }

    public void UpdateFields(string? email)
    {
        if (email != null)
        {
            var customerToUpdate = GetCustomerByEmailAsync(email).GetAwaiter().GetResult();
            if (customerToUpdate != null)
            {
                while (true)
                {
                    Console.WriteLine("Updating Customer");
                    Console.WriteLine("Write the number option to proceed");
                    Console.WriteLine("1. Update First Name");
                    Console.WriteLine("2. Update Last Name");
                    Console.WriteLine("3. Update email");
                    Console.WriteLine("4. Update Address");
                    Console.WriteLine("5. Return to the main Menu");

                    string? options = Console.ReadLine();

                    switch (options)
                    {
                        case "1":
                            Console.WriteLine($"{customerToUpdate}");
                            Console.Write("FirtsName: ");
                            string? firstName = Console.ReadLine();
                            customerToUpdate.FirstName = firstName;
                            SaveStateInUndo();
                            ClearStateInRedo();

                            Console.WriteLine($"Updated FirstName to: {customerToUpdate.FirstName}");
                            break;

                        case "2":
                            Console.WriteLine($"{customerToUpdate}");
                            Console.Write("LastName: ");
                            string? lastName = Console.ReadLine();
                            customerToUpdate.LastName = lastName;
                            SaveStateInUndo();
                            ClearStateInRedo();

                            Console.WriteLine($"Updated LastName to: {customerToUpdate.LastName}");
                            break;

                        case "3":
                            Console.WriteLine($"{customerToUpdate}");
                            Console.Write("Email: ");
                            string? emailToWish = Console.ReadLine();

                            if (_customers.Any(customer => customer.Email == emailToWish))
                            {
                                Console.WriteLine("Sorry but that email is already in the system");
                                Console.Write("Email: ");
                                goto case "3";
                            }
                            else
                            {
                                customerToUpdate.Email = emailToWish;
                                SaveStateInUndo();
                                ClearStateInRedo();

                                Console.WriteLine($"Updated Email to: {customerToUpdate.Email}");
                                break;
                            }

                        case "4":
                            Console.WriteLine($"{customerToUpdate}");
                            Console.Write("Address: ");
                            string? address = Console.ReadLine();
                            customerToUpdate.Address = address;
                            SaveStateInUndo();
                            ClearStateInRedo();

                            Console.WriteLine($"Updated Address to: {customerToUpdate.Address}");

                            break;

                        case "5":
                            return;

                        default:
                            Console.WriteLine("Invalit Option! Write number option");
                            break;
                    }
                }
            }
        }
    }

    public void PrintCustomers()
    {
        if (Customers.Count == 0)
        {
            Console.WriteLine("No customers yet");
        }
        else
        {
            Console.WriteLine("Customers List:");
            foreach (var customer in Customers)
            {
                Console.WriteLine($"{customer}");
            }
        }
    }

    void SaveStateInUndo()
    {
        undoStack.Push(new List<Customer>(_customers));
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            var lastElement = undoStack.Pop();
            redoStack.Push(lastElement);
            _customers.Clear();
            _customers.AddRange(undoStack.Peek());
            Console.WriteLine("Undo performed");
            Console.WriteLine(undoStack.Count);

        }
        else
        {
            Console.WriteLine("No changes to make");
        }
    }

    void ClearStateInRedo()
    {
        redoStack.Clear();
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            var lastElement = redoStack.Pop();
            undoStack.Push(lastElement);
            _customers = new List<Customer>(undoStack.Peek());
            Console.WriteLine("Redo performed.");
        }
        else
        {
            Console.WriteLine("No changes to make");
        }
    }

    public IEnumerator<Customer> GetEnumerator()
    {
        foreach (var customer in _customers)
        {
            yield return customer;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // public void StoreCustomers()
    // {
    //     string separator = ",";
    //     StringBuilder output = new StringBuilder();
    //     string[] headings = { "ID", "First Name", "Last Name", "Email", "Address" };
    //     output.AppendLine(string.Join(separator, headings));
    //     foreach (Customer customer in _customers)
    //     {
    //         string customerData = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
    //         output.AppendLine(string.Join(separator, customerData));
    //     }
    //     try
    //     {
    //         File.AppendAllText(CUSTOMERS_FILE, output.ToString());
    //     }
    //     catch (Exception)
    //     {
    //         Console.WriteLine("Data could not be written to the CSV file.");
    //         return;
    //     }
    //     Console.WriteLine("The data has been successfully saved to the CSV file");
    // }
}



