using RB.FacilityConfig.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var x = Task.Run(async () =>
            {
                var facilities = await GetFacilityList();

                foreach(var facility in facilities)
                {
                    Console.WriteLine(facility);
                }

            });


            x.Wait();

            Console.ReadLine();

        }

        static public async Task<List<string>> GetFacilityList()
        {
            IFacilityConfigurationClient fc = new FacilityConfigurationClient(new Uri("http://facilityconfigurationservice.devint.dev-r5ead.net"));

            var facilities = await fc.GetAllFacilities();

            return facilities.Select(a=>a.FacilityName).ToList();
        }

    }
}
