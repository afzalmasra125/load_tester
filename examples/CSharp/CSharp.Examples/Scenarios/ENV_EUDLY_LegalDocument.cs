using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Newtonsoft.Json;

namespace CSharp.Examples.Scenarios
{
    class ENV_EUDLY
    {   
        public static void Run()
        {

            string usid = "450d4d82-9bda-4e53-a1f1-c4c5be40d233";
            var GetAcceptances = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/{usid}/acceptances";
            var IsAcceptanceRequired = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/{usid}/isacceptancerequired?appBrand=toyota&clientVersion=8.0&locale=en-us&platform=ios&region=row";
            var GetLatestDocuments = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestdocument/cd_pp/bmw/ios/row?clientVersion=8.0&locale=en-us";
            var GetLatestDocumentServiceManager = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestservicemanagerdocuments?appBrand=bmw&clientVersion=8.0&locale=en-us&platform=ios&region=row";
            var GetLatestDocument = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestdocument/cd_pp/bmw/ios/row?clientVersion=8.0&locale=bg-bg";
            var GetViewLatestDocument = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/viewlatestdocument/cd_pp/bmw/ios/row?clientVersion=8.0&locale=bg-bg";
            var AcceptLatest = $"https://btceudly.westeurope.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/{usid}/acceptlatest";

            var getAcceptance = HttpStep.Create("GetAcceptances EU DLY", (context) =>
                    Http.CreateRequest("GET", GetAcceptances)
                        .WithHeader("Accept", "text/html")
                        .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
            );
            var isAcceptanceRequired = HttpStep.Create("IsAcceptanceRequired EU DLY", (context) =>
              Http.CreateRequest("GET", IsAcceptanceRequired)
                  .WithHeader("Accept", "text/html")
                  .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
                  );

          var getLatestDocuments = HttpStep.Create("GetLatestDocuments EU DLY", (context) =>
                    Http.CreateRequest("GET", GetLatestDocuments)
                        .WithHeader("Accept", "text/html")
                        .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
            );

            var getLatestDocumentServiceManager = HttpStep.Create("GetLatestDocumentServiceManager EU DLY", (context) =>
                      Http.CreateRequest("GET",GetLatestDocumentServiceManager)
                          .WithHeader("Accept", "text/html")
                          .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
              );

            var getLatestDocument = HttpStep.Create("GetLatestDocument EU DLY", (context) =>
                     Http.CreateRequest("GET", GetLatestDocument )
                         .WithHeader("Accept", "text/html")
                         .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
             );
            var viewLatestDocument = HttpStep.Create("GetViewLatestDocument EU DLY", (context) =>
                     Http.CreateRequest("GET", GetViewLatestDocument)
                         .WithHeader("Accept", "text/html")
                         .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
             );

            var body = "{\"conditions\":[\"a\", \"b\"],\"clientVersion\":\"8.0\",\"region\":\"NA\",\"locale\":\"en_US\",\"platform\":\"ios\",\"appbrand\":\"bmw\"}";
            var acceptLatestStep = HttpStep.Create("AcceptLatest", (context) =>
                    Http.CreateRequest("POST", AcceptLatest)
                        .WithHeader("Content-Type", "application/json")
                        .WithHeader("Authorization", "gcdmToken")
                        .WithHeader("User-Agent", "userAgentHeader")
                        .WithHeader("x-functions-key", "bmHgy94AKlunTKCizP1kuSON/iv1A8aTVsyr75C2oHtsuf6GdOTn/A==")
                        .WithBody(new StringContent(body, Encoding.UTF8, "application/json"))
                        .WithCheck(response => Task.FromResult(response.IsSuccessStatusCode))
                );

            var scenario_1 = ScenarioBuilder.CreateScenario("500", new NBomber.Contracts.IStep[] { getAcceptance, isAcceptanceRequired, getLatestDocuments, getLatestDocumentServiceManager, viewLatestDocument, acceptLatestStep })
               .WithConcurrentCopies(500)
               .WithWarmUpDuration(TimeSpan.FromSeconds(0))
               .WithDuration(TimeSpan.FromSeconds(120));

            NBomberRunner.RegisterScenarios(scenario_1)
                //.LoadConfig("config.json")
                .RunInConsole();
        }
    }
}
