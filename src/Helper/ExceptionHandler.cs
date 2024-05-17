namespace CustomerDatabase.src.Helper;

public class ExceptionHandler : Exception
{
    private string _message;
    private int _errorCode;

    public ExceptionHandler(string message, int errorCode)
    {
        _message = message;
        _errorCode = errorCode;
    }

    public static ExceptionHandler FileException()
    {
        return new ExceptionHandler("There is error happened when processing the file", 500);
    }

    public static ExceptionHandler FetchDataException()
    {
        return new ExceptionHandler("Cannot read data from the file", 500);
    }
    public static ExceptionHandler AddDataException()
    {
        return new ExceptionHandler("Cannot add data in the file", 500);
    }
    public static ExceptionHandler RemoveDataException()
    {
        return new ExceptionHandler("Cannot remove data in the file", 500);
    }

    public static ExceptionHandler UpdateDataException()
    {
        return new ExceptionHandler("Cannot update data in the file", 500);
    }

    public static ExceptionHandler CustomerNotFound()
    {
        return new ExceptionHandler("We couldn't find this customer", 404);
    }
}

