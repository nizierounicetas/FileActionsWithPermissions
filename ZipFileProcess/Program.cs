using System.IO.Compression;

public static class ZipFileProcess
{
    public static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Source file is not specified");
            return -1;
        }

        string sourceFilePath = args[0];
        if (!File.Exists(sourceFilePath))
        {
            Console.Error.WriteLine($"File does not exist: {sourceFilePath}");
            return -2;
        }

        string zipArchivePath = $"{Path.GetDirectoryName(sourceFilePath)}\\{Path.GetFileNameWithoutExtension(sourceFilePath)}.zip";
        try
        {
            using (var archive = ZipFile.Open(zipArchivePath, ZipArchiveMode.Update))
            {
                    foreach (var entry in archive.Entries.ToList())
                    {
                        entry.Delete();
                    }
                    archive.CreateEntryFromFile(sourceFilePath, Path.GetFileName(sourceFilePath));
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
