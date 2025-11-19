using System.Text;
using System.IO;

namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class containing File Operations demo
    /// </summary>
    internal class FileOperation
    {
        /// <summary>
        /// Method containing all File operations
        /// </summary>
        public static void FileOperationDemo()
        {
            string filePath = "demo.txt";
            string copyPath = "demo_copy.txt";
            string replacedPath = "demo_replaced.txt";
            string movedPath = "demo_moved.txt";
            string[] lines = { "Line 1", "Line 2", "Line 3" };

            Console.WriteLine("Enter the number corresponding to the method to execute it.");
            Console.WriteLine("Type '0' to exit.");
            Console.WriteLine();

            string[] menu = new string[]
            {
            "Exit",
            "Create",
            "AppendAllLines",
            "AppendAllText",
            "AppendText",
            "Copy",
            "CreateText",
            "Move",
            "Open",
            "OpenHandle",
            "OpenRead",
            "OpenText",
            "ReadAllBytes",
            "ReadAllLines",
            "ReadAllText",
            "ReadLines",
            "WriteAllBytes",
            "WriteAllLines",
            "WriteAllText",
            "Encrypt (Windows only)",
            "Decrypt (Windows only)",
            "Equals",
            "Exists",
            "ReferenceEquals",
            "Get File Access Data",
            "Set File Access Data",
            "Delete"
            };

            for (int i = 1; i < menu.Length; i++)
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }

            while (true)
            {
                Console.Write("\nEnter method number (0 to exit): ");
                int input = int.Parse(Console.ReadLine());

                if (input < 0 || input >= menu.Length)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }

                if (input == 0)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                try
                {
                    switch (menu[input])
                    {
                        case "Create":
                            try
                            {
                                using(var fs = File.Create(filePath)) { }
                                Console.WriteLine("File.Create executed: Created demo.txt");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Error while creating file " + e.Message);
                            }
                            break;

                        case "AppendAllLines":
                            File.AppendAllLines(filePath, lines);
                            Console.WriteLine("File.AppendAllLines executed: Lines appended.");
                            break;

                        case "AppendAllText":
                            File.AppendAllText(filePath, "\nAppended Text");
                            Console.WriteLine("File.AppendAllText executed: Text appended.");
                            break;

                        case "AppendText":
                            using (StreamWriter sw = File.AppendText(filePath))
                            {
                                sw.WriteLine("Using AppendText");
                            }
                            Console.WriteLine("File.AppendText executed: Text appended using StreamWriter.");
                            break;

                        case "Copy":
                            File.Copy(filePath, copyPath, overwrite: true);
                            Console.WriteLine($"File.Copy executed: {filePath} copied to {copyPath}.");
                            break;

                        case "CreateText":
                            using (StreamWriter sw = File.CreateText(replacedPath))
                            {
                                sw.WriteLine("Created with CreateText");
                            }
                            Console.WriteLine($"File.CreateText executed: Created {replacedPath} with text.");
                            break;

                        case "Move":
                            if (!File.Exists(copyPath))
                            {
                                Console.WriteLine($"Source file {copyPath} does not exist. Please run Copy first.");
                            }
                            else
                            {
                                File.Move(copyPath, movedPath, overwrite: true);
                                Console.WriteLine($"File.Move executed: {copyPath} moved to {movedPath}.");
                            }
                            break;

                        case "Open":
                            using (FileStream fs = File.Open(filePath, FileMode.Open))
                            {
                                Console.WriteLine($"File.Open executed: Opened {filePath}.");
                            }
                            break;

                        case "OpenHandle":
                            var handle = File.OpenHandle(filePath);
                            Console.WriteLine($"File.OpenHandle executed: Obtained handle for {filePath}.");
                            break;

                        case "OpenRead":
                            using (var reader = File.OpenRead(filePath))
                            {
                                Console.WriteLine($"File.OpenRead executed: Opened {filePath} for reading.");
                            }
                            break;

                        case "OpenText":
                            using (StreamReader sr = File.OpenText(filePath))
                            {
                                Console.WriteLine($"File.OpenText executed: First line: {sr.ReadLine()}");
                            }
                            break;

                        case "ReadAllBytes":
                            byte[] data = File.ReadAllBytes(filePath);
                            Console.WriteLine($"File.ReadAllBytes executed: Read {data.Length} bytes from {filePath}.");
                            break;

                        case "ReadAllLines":
                            string[] readLines = File.ReadAllLines(filePath);
                            Console.WriteLine("File.ReadAllLines executed: Lines:");
                            foreach (var line in readLines) Console.WriteLine($" - {line}");
                            break;

                        case "ReadAllText":
                            string content = File.ReadAllText(filePath);
                            Console.WriteLine("File.ReadAllText executed: Content:");
                            Console.WriteLine(content);
                            break;

                        case "ReadLines":
                            Console.WriteLine("File.ReadLines executed: Lines:");
                            foreach (var line in File.ReadLines(filePath))
                                Console.WriteLine($" - {line}");
                            break;

                        case "WriteAllBytes":
                            byte[] bytesToWrite = Encoding.UTF8.GetBytes("Data for WriteAllBytes");
                            File.WriteAllBytes("bytes.bin", bytesToWrite);
                            Console.WriteLine("File.WriteAllBytes executed: Wrote bytes.bin");
                            break;

                        case "WriteAllLines":
                            File.WriteAllLines("lines.txt", lines);
                            Console.WriteLine("File.WriteAllLines executed: Wrote lines.txt");
                            break;

                        case "WriteAllText":
                            File.WriteAllText("text.txt", "Written text");
                            Console.WriteLine("File.WriteAllText executed: Wrote text.txt");
                            break;

                        case "Encrypt (Windows only)":
                            if (OperatingSystem.IsWindows())
                            {
                                try
                                {
                                    File.Encrypt(filePath);
                                    Console.WriteLine($"File.Encrypt executed: Encrypted {filePath}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"File.Encrypt failed: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("File.Encrypt is supported only on Windows.");
                            }
                            break;

                        case "Decrypt (Windows only)":
                            if (OperatingSystem.IsWindows())
                            {
                                try
                                {
                                    File.Decrypt(filePath);
                                    Console.WriteLine($"File.Decrypt executed: Decrypted {filePath}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"File.Decrypt failed: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("File.Decrypt is supported only on Windows.");
                            }
                            break;

                        case "Equals":
                            bool areEqual = File.Equals(filePath, filePath);
                            Console.WriteLine($"File.Equals executed: Comparing {filePath} with itself: {areEqual}");
                            break;

                        case "Exists":
                            bool exists = File.Exists(filePath);
                            Console.WriteLine($"File.Exists executed: {filePath} exists? {exists}");
                            break;

                        case "ReferenceEquals":
                            bool refEquals = File.ReferenceEquals(filePath, filePath);
                            Console.WriteLine($"File.ReferenceEquals executed: Comparing {filePath} to itself: {refEquals}");
                            break;

                        case "Get File Access Data":
                            Console.WriteLine($"File.GetAttributes: {File.GetAttributes(filePath)}");
                            Console.WriteLine($"File.GetCreationTime: {File.GetCreationTime(filePath)}");
                            Console.WriteLine($"File.GetCreationTimeUtc: {File.GetCreationTimeUtc(filePath)}");
                            Console.WriteLine($"File.GetLastAccessTime: {File.GetLastAccessTime(filePath)}");
                            Console.WriteLine($"File.GetLastAccessTimeUtc: {File.GetLastAccessTimeUtc(filePath)}");
                            Console.WriteLine($"File.GetLastWriteTime: {File.GetLastWriteTime(filePath)}");
                            Console.WriteLine($"File.GetLastWriteTimeUtc: {File.GetLastWriteTimeUtc(filePath)}");
                            break;

                        case "Set File Access Data":
                            if (!File.Exists(replacedPath))
                            {
                                // Create the file first to avoid exceptions
                                File.WriteAllText(replacedPath, "Dummy text to set attributes and times");
                            }

                            File.SetAttributes(replacedPath, FileAttributes.Normal);
                            File.SetCreationTime(replacedPath, DateTime.Now);
                            File.SetCreationTimeUtc(replacedPath, DateTime.UtcNow);
                            File.SetLastAccessTime(replacedPath, DateTime.Now);
                            File.SetLastAccessTimeUtc(replacedPath, DateTime.UtcNow);
                            File.SetLastWriteTime(replacedPath, DateTime.Now);
                            File.SetLastWriteTimeUtc(replacedPath, DateTime.UtcNow);

                            Console.WriteLine($"File.SetTime and SetAttributes executed on {replacedPath}");
                            break;

                        case "Delete":
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                Console.WriteLine("File deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("File doesn't exists!");
                            }
                            break;

                        default:
                            Console.WriteLine("Unknown method number.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing {menu[input]}: {ex.Message}");
                }
            }

            File.Delete(filePath);
            File.Delete(copyPath);
            File.Delete(replacedPath);
            File.Delete(movedPath);
        }
    }
}
