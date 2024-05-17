public class FileHandler : IDisposable
{
    private StreamReader _fileReader;
    private StreamWriter _fileWriter;

    //constructor
    public FileHandler(string path)
    {
        if (IsValidPath(path))
        {
            _fileReader = new StreamReader(path);
            _fileWriter = new StreamWriter(path, true);
        }
        else
        {
            throw new ArgumentException("Cannot initiate the instance with file path");
        }
    }

    private bool IsValidPath(string path)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("File path should not be null or empty");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            return true;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public void ReadData()
    {
        while (!_fileReader.EndOfStream)
        {
            Console.WriteLine(_fileReader.ReadLine());
        }
    }

    public void WriteData(string text)
    {
        _fileWriter.WriteLine(text);
        Console.WriteLine("Writing to file");
        /*         _fileWriter.Close(); */
    }

    public void Dispose()
    {
        _fileReader.Close();
        _fileWriter.Close();
    }

    // public void WriteMultipleLines(params string[] lines)
    // {
    //     foreach (var line in lines)
    //     {
    //         _fileWriter.WriteLine(line);
    //     }
    //     /*         _fileWriter.Close(); */
    // }


}