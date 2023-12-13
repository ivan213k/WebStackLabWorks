public class FileManager
{
    // Private static instance of the class
    private static FileManager _instance;

    // Private constructor to prevent instantiation from outside the class
    private FileManager()
    {
        // Initialization code
    }

    // Public method to get the singleton instance
    public static FileManager GetInstance()
    {
         //create the instance if it doesn't exist
        if (_instance == null)
        {
            _instance = new FileManager();
        }
        return _instance;
    }

    public void SetStorage(string type)
    {
        Console.WriteLine($"Storage type set to: {type}");
    }

    public void UploadFile(string filePath)
    {
        Console.WriteLine($"Uploading file: {filePath}");
    }

    public void DownloadFile(string fileUrl)
    {
        Console.WriteLine($"Downloading file from: {fileUrl}");
    }
}
public class Program
{
    static void Main()
    {
        // Using the singleton instance
        FileManager fileManager = FileManager.GetInstance();

        fileManager.SetStorage("Cloud Storage");

        fileManager.UploadFile("example.txt");

        fileManager.DownloadFile("https://example.com/files/example.txt");
    }
}