

using System.Security.Cryptography;

public static class HashFileProcess
{
    public static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("File is not specified");
            return -1;
        }

    
        string sourceFilePath = args[0];

        if (!File.Exists(sourceFilePath))
        {
            Console.Error.WriteLine();
            return -2;
        }

        string hashFilePath = $"{Path.GetDirectoryName(sourceFilePath)}\\{Path.GetFileNameWithoutExtension(sourceFilePath)}_hash_sha256";

        try
        {
            byte[] bytesFile = File.ReadAllBytes(sourceFilePath);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesHash = sha256.ComputeHash(bytesFile);
                string hashString = Convert.ToBase64String(bytesHash);

                File.WriteAllText(hashFilePath, hashString);
            }
        }
        catch(UnauthorizedAccessException ex)
        {
            Console.Error.WriteLine(ex.Message);
            // probably admin rights're required
            return -3;
        }
        catch(Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return -4;
        }

        return 0;
    }
}
