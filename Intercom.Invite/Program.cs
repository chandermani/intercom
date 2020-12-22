using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Intercom.Invite
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments provided!");
                Console.WriteLine("From Intecom.Invite folder RUN: dotnet run <inputfilepath> <outputfilepath>");
                return;
            }

            string inputFilePath = args[0];
            string outputFilePath = args[1];

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Cannot find file: {inputFilePath}");
                return;
            }

            CustomerInviteFilter customerInviteFilter =
                new CustomerInviteFilter(new CustomerListReader(inputFilePath, CustomerModelMapper.Default),
                                        DistanceCalculator.GreatCircleDistance);

            GPSCoordinate dublinCoordinates = new GPSCoordinate(53.339428, -6.257664);
            double radius = 100d;

            using (StreamWriter writer = new StreamWriter(File.OpenWrite(outputFilePath)))
            {
                foreach(var customer in customerInviteFilter.Filter(dublinCoordinates, radius).OrderBy(c=>c.Id))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(new { user_id = customer.Id, name = customer.Name }));
                }
            }
        }
    }
}
