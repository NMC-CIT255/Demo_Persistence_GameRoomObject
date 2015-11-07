using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Persistence_GameRoomObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = "Data\\Data.txt";

            //SimpleTextReadWrite(textFilePath);
            //StructuredTextReadWrite(textFilePath);
            ObjectArrayReadWrite(textFilePath);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void SimpleTextReadWrite(string dataFile)
        {
            string fieldNames;
            string address01;
            string address02;

            string dataFileContents = "";

            fieldNames = "lastName,firstName,address,city,zip\n";
            address01 = "Flintstone,Fred,301 Cobblestone Way,Bedrock,70777\n";
            address02 = "Rubble,Barney,301 Cobblestone Way,Bedrock,70777\n";

            Console.WriteLine("The following addresses will be added to Data.txt.\n");
            Console.WriteLine(address01 + address02);

            Console.WriteLine("\nAdd addresses. Press any key to continue.\n");
            Console.ReadKey();

            File.WriteAllText(dataFile, fieldNames);
            File.AppendAllText(dataFile, address01);
            File.AppendAllText(dataFile, address02);

            Console.WriteLine("Addresses added successfully.\n");

            Console.WriteLine("Read and display the addresses from Data.txt. Press any key to continue.\n");
            Console.ReadKey();

            dataFileContents = File.ReadAllText(dataFile);

            Console.WriteLine(dataFileContents);

            Console.ReadKey();
        }

        static void StructuredTextReadWrite(string dataFile)
        {
            const char delineator = ',';
            string endOfRecord = "\n";

            string datastring;
            string fieldNames;
            string dataFileContents = "";

            string lastName = "Flintstone";
            string firstName = "Fred";
            string address = "222 Rocky Way";
            string city = "Bedrock";
            string state = "MI";
            string zip = "70777";

            datastring =
                lastName + delineator +
                firstName + delineator +
                address + delineator +
                city + delineator +
                state + delineator +
                zip + endOfRecord;

            fieldNames = "lastName,firstName,address,city,zip\n";

            Console.WriteLine("The following addresses will be added to Data.txt.\n");
            Console.WriteLine(datastring);

            Console.WriteLine("\nAdd addresses. Press any key to continue.\n");
            Console.ReadKey();

            File.WriteAllText(dataFile, fieldNames);
            File.AppendAllText(dataFile, datastring);

            Console.WriteLine("Addresses added successfully.\n");

            Console.WriteLine("Read and display the addresses from Data.txt. Press any key to continue.\n");
            Console.ReadKey();

            dataFileContents = File.ReadAllText(dataFile);

            Console.WriteLine(dataFileContents);
        }

        static void ObjectArrayReadWrite(string dataFile)
        {
            string playerName;
            int highScore;

            HighScore[] highScores = {
                                         new HighScore("John", 1296),
                                         new HighScore("Jeff", 964),
                                         new HighScore("Joan", 275),
                                         new HighScore("Charlie", 2334)
                                     };

            string textForDataFile = "";
            string dataFileContents = "";


            Console.WriteLine("The following high scores will be added to Data.txt.\n");

            foreach (var player in highScores)
            {
                Console.WriteLine("Player: {0}\tScore: {1}", player.PlayerName, player.PlayerScore);
            }


            Console.WriteLine("\nAdd addresses. Press any key to continue.\n");
            Console.ReadKey();

            foreach (var player in highScores)
            {
                Console.WriteLine("Player: {0}\tScore: {1}", player.PlayerName, player.PlayerScore);
            }

            File.WriteAllText(dataFile, textForDataFile);

            Console.WriteLine("Addresses added successfully.\n");

            Console.WriteLine("Read and display the addresses from Data.txt. Press any key to continue.\n");
            Console.ReadKey();

            dataFileContents = File.ReadAllText(dataFile);

            Console.WriteLine(dataFileContents);

            Console.ReadKey();
        }
    }
}
