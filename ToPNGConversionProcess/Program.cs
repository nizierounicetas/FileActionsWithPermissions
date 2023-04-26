using System.Drawing;

public static class ToPNGConversionFileProcess
{
    private static readonly string[] graphicalExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };
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

        string extension = Path.GetExtension(sourceFilePath).ToLower();
        if (extension.Equals(".png"))
        {
            Console.Error.WriteLine($"File {sourceFilePath} is already png");
            return -5;
        }

        if (!graphicalExtensions.Contains(extension))
        {
            Console.Error.WriteLine($"File {sourceFilePath} is not graphical");
            return -6;
        }

        string pngFilePath = $"{Path.GetDirectoryName(sourceFilePath)}\\{Path.GetFileNameWithoutExtension(sourceFilePath)}.png";
        try
        {
            using (Image image = Image.FromFile(sourceFilePath))
            {
                image.Save(pngFilePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return -3;
        }
        catch (System.Runtime.InteropServices.ExternalException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return -3;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return -4;
        }

        return 0;
    }
}