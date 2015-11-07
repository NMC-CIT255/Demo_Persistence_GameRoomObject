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

            SimpleTextReadWrite(textFilePath);
            //StructuredTextReadWrite(textFilePath);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void SimpleTextReadWrite(string dataFile)
        {
            string address01;
            string address02;

            string dataFileContents = "";

            // initialize strings with addresses
            address01 = "Flintstone,Fred,301 Cobblestone Way,Bedrock,70777\n";
            address02 = "Rubble,Barney,303 Cobblestone Way,Bedrock,70777\n";

            Console.WriteLine("The following addresses will be added to the text file.\n");
            Console.WriteLine(address01 + address02);

            Console.WriteLine("\nAdd addresses. Press any key to continue.\n");
            Console.ReadKey();

            // add address strings to the end of the text file
            File.AppendAllText(dataFile, address01);
            File.AppendAllText(dataFile, address02);

            Console.WriteLine("Addresses added successfully.\n");

            Console.WriteLine("Read and display the addresses from the text file. Press any key to continue.\n");
            Console.ReadKey();
            
            // read all of the data file info into a single string
            dataFileContents = File.ReadAllText(dataFile);

            Console.WriteLine(dataFileContents);
        }

        static void StructuredTextReadWrite(string dataFile)
        {
            string dataString;
            string dataFileContents = "";

            // initialize a string with all of the addresses
            dataString = BuildDataString();

            Console.WriteLine("The following addresses will be added to text file.\n");
            Console.WriteLine(dataString);

            Console.WriteLine("\nAdd addresses. Press any key to continue.\n");
            Console.ReadKey();

            // empty the text file and add the addresses
            File.WriteAllText(dataFile, dataString);

            Console.WriteLine("Address added successfully.\n");

            Console.WriteLine("Read and display the addresses from the text file. Press any key to continue.\n");
            Console.ReadKey();

            // read all addresses from the text file into a single string
            dataFileContents = File.ReadAllText(dataFile);
            Console.WriteLine(dataFileContents);

            Console.WriteLine("Read and display the addresses from the text file. Press any key to continue.\n");
            Console.ReadKey();

            // split the text file string into individual properties and display
            DisplayDataByProperty(dataFile);
        }

        static string BuildDataString()
        {
            StringBuilder dataStringBuilder = new StringBuilder();

            string lastName;
            string firstName;
            string address;
            string city;
            string state;
            string zip;

            // declare a property delineator
            const char delineator = ',';

            string dataString;

            // use the StringBuilder class to build the string of addresses
            lastName = "Flintstone";
            firstName = "Fred";
            address = "301 Cobblestone Way";
            city = "Bedrock";
            state = "MI";
            zip = "70777";

            dataStringBuilder.AppendLine(
                lastName + delineator +
                firstName + delineator +
                address + delineator +
                city + delineator +
                state + delineator +
                zip);

            lastName = "Rubble";
            firstName = "Barney";
            address = "303 Cobblestone Way";
            city = "Bedrock";
            state = "MI";
            zip = "70777";

            dataStringBuilder.AppendLine(
                lastName + delineator +
                firstName + delineator +
                address + delineator +
                city + delineator +
                state + delineator +
                zip);

            dataString = dataStringBuilder.ToString();

            return dataString;
        }


        /// <summary>
        /// method to display the addresses properties
        /// </summary>
        /// <param name="dataFile"></param>
        static void DisplayDataByProperty(string dataFile)
        {
            const char delineator = ',';

            // read each line of addresses as a string element in an array
            string[] addresses = File.ReadAllLines(dataFile);

            // iterate through the address array and display each property
            for (int index = 0; index < addresses.Length; index++)
			{
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = addresses[index].Split(delineator);

                Console.WriteLine("Last Name: {0}", properties[0]);
                Console.WriteLine("First Name: {0}", properties[1]);
                Console.WriteLine("Address: {0}", properties[2]);
                Console.WriteLine("City: {0}", properties[3]);
                Console.WriteLine("State: {0}", properties[4]);
                Console.WriteLine("Zip: {0}", properties[5]);

                Console.WriteLine();
			}
        }
    }
}
