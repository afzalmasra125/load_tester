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
    class ENV_NADLY
    {
 
        public static void Run()
           
        {
            string usid = "ba99fcf6-bc5a-4713-ad5d-6f0ca3e952b3";
            var GetAcceptances = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/api/legaldocumentcheck/{usid}/acceptlatest";
            var IsAcceptanceRequired = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check//api/legaldocumentcheck/{usid}/isacceptancerequired?appBrand=bmw&clientVersion=8.0&locale=en-us&platform=ios&region=na";
            var GetLatestDocuments = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestdocument/cd_pp/bmw/ios/na?clientVersion=8.0&locale=en-us;";
            var GetLatestDocumentServiceManager = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestservicemanagerdocuments?appBrand=bmw&clientVersion=8.0&locale=en-us&platform=ios&region=na";
            var GetLatestDocument = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/latestdocument/cd_pp/bmw/ios/na?clientVersion=8.0&locale=bg-bg";
            var GetViewLatestDocument = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/viewlatestdocument/cd_pp/bmw/ios/na?clientVersion=8.0&locale=bg-bg";
            var AcceptLatest = $"https://btcnadly.centralus.cloudapp.azure.com/svc/legal-document-check/api/legaldocumentcheck/{usid}/acceptlatest";


            //var getAcceptance = HttpStep.Create("GetAcceptances NA DLY", (context) =>
            //        Http.CreateRequest("GET", GetAcceptances)
            //            .WithHeader("Accept", "text/html")
            //            .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
            //);
            var isAcceptanceRequired = HttpStep.Create("IsAcceptanceRequired NA DLY", (context) =>
              Http.CreateRequest("GET", IsAcceptanceRequired)
                  .WithHeader("Accept", "text/html")
                  .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
                  );

          var getLatestDocuments = HttpStep.Create("GetLatestDocuments NA DLY", (context) =>
                    Http.CreateRequest("GET", GetLatestDocuments)
                        .WithHeader("Accept", "text/html")
                        .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
            );

            var getLatestDocumentServiceManager = HttpStep.Create("GetLatestDocumentServiceManager NA DLY", (context) =>
                      Http.CreateRequest("GET", GetLatestDocumentServiceManager)
                          .WithHeader("Accept", "text/html")
                          .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
              );

            var getLatestDocument = HttpStep.Create("GetLatestDocument NA DLY", (context) =>
                     Http.CreateRequest("GET", GetLatestDocument)
                         .WithHeader("Accept", "text/html")
                         .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
             );
            var viewLatestDocument = HttpStep.Create("GetViewLatestDocument NA DLY", (context) =>
                     Http.CreateRequest("GET", "GetViewLatestDocument")
                         .WithHeader("Accept", "text/html")
                         .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
             );

            var body = "{\"conditions\":[\"a\", \"b\"],\"clientVersion\":\"8.0\",\"region\":\"NA\",\"locale\":\"en_US\",\"platform\":\"ios\",\"appbrand\":\"bmw\"}";
            var acceptLatestStep = HttpStep.Create("AcceptLatest", (context) =>
                    Http.CreateRequest("POST", "AcceptLatest")
                        .WithHeader("Content-Type", "application/json")
                        .WithHeader("Authorization", "gcdmToken")
                        .WithHeader("User-Agent", "userAgentHeader")
                        .WithHeader("x-functions-key", "SZGsMU/rbFRf/a8LgoZk0TU6ycB3WxwgjaVFIYchDCW0AaKstzjXJA==")
                        .WithBody(new StringContent(body, Encoding.UTF8, "application/json"))
                        .WithCheck(response => Task.FromResult(response.IsSuccessStatusCode))
                        );

            var scenario_1 = ScenarioBuilder.CreateScenario("500", new NBomber.Contracts.IStep[] {isAcceptanceRequired, getLatestDocuments, getLatestDocumentServiceManager, viewLatestDocument, acceptLatestStep })
                        .WithConcurrentCopies(500)
                        .WithWarmUpDuration(TimeSpan.FromSeconds(0))
                        .WithDuration(TimeSpan.FromSeconds(120));

            NBomberRunner.RegisterScenarios(scenario_1)
                //.LoadConfig("config.json")
                .RunInConsole();
        }
    }
}
