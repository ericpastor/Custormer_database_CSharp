namespace CustomerManagement;

public class Customer
{
    // Id, FirstName, LastName, Email, and Address.
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    static int lastId = 0;

    static int GenerateId()
    {
        return Interlocked.Increment(ref lastId);
    }
    public Customer(string? firstName, string? lastName, string? email, string? address)
    {
        Id = GenerateId();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;

    }

    public void UpdateCustomer(CustomerUpdateDTO customerUpdateDTO)
    {
        FirstName = customerUpdateDTO.FirstName;
        LastName = customerUpdateDTO.LastName;
        Address = customerUpdateDTO.Address;
    }

    public override string ToString()
    {
        return $"Customer Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Address: {Address}";
    }

    public static Customer? FromCsv(string csvLine)
    {
        // Crea una instancia de Customer a partir de una cadena CSV
        string[] parts = csvLine.Split(',');
        if (parts.Length == 5)
        {
            string firstName = parts[1];
            string lastName = parts[2];
            string email = parts[3];
            string address = parts[4];
            return new Customer(firstName, lastName, email, address);
        }
        return null;
    }
}

public class CustomerReadDTO
{
    // Id, FirstName, LastName, Email, and Address.
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public CustomerReadDTO(int id, string? firstName, string? lastName, string? email, string? address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return $"Customer Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Address: {Address}";
    }
}

public class CustomerUpdateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public CustomerUpdateDTO(string firstName, string lastName, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}


