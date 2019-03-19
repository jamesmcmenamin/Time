using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Ilm.CodeAudition.Service
{
    class CommandLineHost
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(TimeTrackerService), new Uri("http://localhost:8000/TimeTrackerService")))
            {
                try
                {
                    var serviceMetadataBehavior = new ServiceMetadataBehavior
                                                      {
                                                          HttpGetEnabled = true, 
                                                          MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
                                                      };
                    host.Description.Behaviors.Add(serviceMetadataBehavior);

                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                    host.AddServiceEndpoint(typeof(TimeTrackerService), new BasicHttpBinding(), "");
                    host.Open();

                    Console.WriteLine("Press <ENTER> to terminate the service host");
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine("There was a communication problem. " + commProblem.Message);
                    Console.Read();
                }
            }
        }
    }
}
