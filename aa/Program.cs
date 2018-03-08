using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;

namespace aa
{
    public class Program
    {
        public static void Main(string[] args)
        {


            ClientConfiguration config = ClientConfiguration.LoadFromFile("ClientConfiguration.xml");
            config.DeploymentId = "R5Ent-v1.0";
            config.DataConnectionString =
                @"Server=NCI-R5ESQL01.dev-r5ead.net\mssqlsvr02;Database=Orleans;User ID=orleans;password=orleans;";

            var oclient = new ClientBuilder()
                .UseConfiguration(config)
                .ConfigureServices(services => { })
                .Build();

            oclient.Connect().Wait();


            //we need to actual hit the silos to ensure that the silo is up.
            var managementGrain = oclient.GetGrain<IManagementGrain>(0);

            Task.Run(async () =>
            {
                var hosts = await managementGrain.GetHosts();
            });





            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureLogging((hostingContext, logging) =>
                //{
                //    var testSwitch = new SourceSwitch("sourceSwitch", "Logging Sample");
                //    testSwitch.Level = SourceLevels.Verbose;

                //    logging.AddTraceSource(testSwitch, new ElasticSearch.Diagnostics.ElasticSearchTraceListener());
                //})
                .UseStartup<Startup>();
    }
}
