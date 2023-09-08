using System;
using System.Linq;
using BitrareTaskVeda.Class;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;


namespace BitrareTaskVeda
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //solution 1 for parsing
            string octets  = @"{
                ""Device"": ""Arista"",
                ""Model"": ""X-Video"",
                ""NIC"": [{
                    ""Description"": ""Linksys ABR"",
                    ""MAC"": ""14:91:82:3C:D6:7D"",
                    ""Timestamp"": ""2020-03-23T18:25:43.511Z"",
                    ""Rx"": ""3698574500"",
                    ""Tx"": ""122558800""
                }]
            }";
            //solution 2 for parsing
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            string jsonFilePath = Path.Combine(assemblyDirectory, @"..\..\json\data.json");

            string octets2 = File.ReadAllText(jsonFilePath);




            Information information = JsonConvert.DeserializeObject<Information>(octets2);

            Console.WriteLine("MAC: "+ information?.NIC.FirstOrDefault()?.MAC);

            // calculation of the number of bits transmitted per second
            // Without loss of generality assume that values of RX and TX are given in bits
            // from the polling rate we know that 2 x n bits per second are transferred where n is size given in RX or TX
            // so bitrate / number of bits transmitted per second is 2 * 3698574500 ; or ; 2 * 122558800;  

            string rx = information?.NIC.FirstOrDefault()?.Rx;
            string tx = information?.NIC.FirstOrDefault()?.Tx;

            if (rx == null || tx == null || rx == "" || tx == "")
            {
                Console.WriteLine("wrong value given");
                Console.ReadLine();

                throw new ArgumentNullException("Error: null value is given");
            }
            else
            {

                long bitrateRx = Convert.ToInt64(rx);
                long bitrateTx = Convert.ToInt64(tx);




                bitrateTx *= 2;
                bitrateRx *= 2;

                Console.WriteLine("bitrates for RX: ");

                Console.WriteLine(bitrateRx);

                Console.WriteLine("bitrates for TX: ");


                Console.WriteLine(bitrateTx);


                Console.ReadLine();
            }
        }
    }
}
