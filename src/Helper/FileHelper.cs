// using System.Text;
// using CustomerDatabase.src.Helper;

// public class FileHelper
// {
//     public static string[] GetAllCustomer()
//     {
//         try
//         {
//             var data = File.ReadAllLines("customers.csv");
//             return data;
//         }
//         catch (ExceptionHandler)
//         {

//             throw ExceptionHandler.FileException();
//         }
//     }

//     public static bool RecordExistsInCsv(string recordToCheck)
//     {
//         try
//         {
//             string[] csvLines = File.ReadAllLines("customers.csv");

//             foreach (string csvLine in csvLines)
//             {
//                 if (csvLine == recordToCheck)
//                 {
//                     return true;
//                 }
//             }
//             return false;
//         }
//         catch (Exception)
//         {

//             throw ExceptionHandler.FetchDataException();

//         }
//     }

//     public static void AddNewCustomer(string customerData)
//     {
//         StringBuilder output = new StringBuilder();
//         string separator = ",";
//         output.AppendLine(string.Join(separator, customerData));
//         List<string> lines = File.ReadAllLines("customers.csv").ToList();
//         try
//         {
//             File.AppendAllText("customers.csv", output.ToString());
//             Console.WriteLine("The data has been successfully saved to the CSV file");
//         }
//         catch (Exception)
//         {
//             throw ExceptionHandler.AddDataException();
//         }
//     }

//     public static void RemoveCustomer(string email)
//     {
//         try
//         {
//             List<string> lines = File.ReadAllLines("customers.csv").ToList();

//             for (int i = 0; i < lines.Count; i++)
//             {

//                 if (lines[i].Contains(email))
//                 {
//                     lines.RemoveAt(i);
//                     i--;
//                 }
//             }

//             File.WriteAllLines("customers.csv", lines);
//         }
//         catch (Exception)
//         {

//             throw ExceptionHandler.RemoveDataException();
//         }

//     }

//     public static void UpdateCustomer(
//      int id,
//      string? oldFirstName, string? newFirstName,
//      string? oldLastName, string? newLastName,
//      string? oldAddress, string? newAddress
//      )
//     {
//         try
//         {

//             List<string> lines = File.ReadAllLines("customers.csv").ToList();
//             StringBuilder sb = new StringBuilder();

//             foreach (string line in lines)
//             {
//                 if (line.Contains(Convert.ToString(id)))
//                 {
//                     string updatedLine = line;

//                     if (oldFirstName != null && newFirstName != null)
//                     {
//                         updatedLine = updatedLine.Replace(oldFirstName, newFirstName);
//                     }
//                     if (oldLastName != null && newLastName != null)
//                     {
//                         updatedLine = updatedLine.Replace(oldLastName, newLastName);
//                     }
//                     if (oldAddress != null && newAddress != null)
//                     {
//                         updatedLine = updatedLine.Replace(oldAddress, newAddress);
//                     }
//                     sb.AppendLine(updatedLine);
//                 }
//                 else
//                 {
//                     sb.AppendLine(line);
//                 }
//             }

//             File.WriteAllText("customers.csv", sb.ToString());
//             Console.WriteLine("The data has been successfully updated in the CSV file.");
//         }
//         catch (Exception)
//         {
//             ExceptionHandler.UpdateDataException();
//         }
//     }


// }
