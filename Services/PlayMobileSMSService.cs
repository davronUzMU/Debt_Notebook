using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs;
using Debt_Notebook.Model.DTOs.MessageDTO;
using Debt_Notebook.Repositories.MessageRep;
using Debt_Notebook.Repositories.UserRep;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace Debt_Notebook.Services
{
    public class PlayMobileSMSService
    {
        private readonly HttpClient _httpClient;
        private readonly ISendSMSMessage sendSMSMessage;
        private readonly IUserRepository _userRepository;

        public PlayMobileSMSService(HttpClient httpClient,ISendSMSMessage sMSMessage,IUserRepository userRepository)
        {
            _httpClient = httpClient;
            sendSMSMessage= sMSMessage;
            _userRepository = userRepository;
        }
        public async Task<InformationDTO> Activate(PlayMobileActivationDTO mobileActivationDTO)
        {
            var requestData = new {
                apiKey=mobileActivationDTO.ApiKey
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            HttpResponseMessage response=await _httpClient.PostAsync(mobileActivationDTO.ApiUrl, content);
            if (response.IsSuccessStatusCode) {
                 var dto= new InformationDTO("successfully activated");
                 return dto;

            }
            else
            {
                var dto = new InformationDTO("Activation failed");
                return dto;
            }
            
        }

        public async Task<InformationDTO> SendSMS(MessageRequestDTO messageRequestDTO, PlayMobileActivationDTO playMobileActivationDTO)
        {
            var user = _userRepository.GetUserById(messageRequestDTO.userId);
            var client = new RestClient(playMobileActivationDTO.ApiUrl);
            var request = new RestRequest("/sms/2/text/advanced", RestSharp.Method.Post);
            request.AddHeader("Authorization", "App a1d4e89bed96f755f5e20117ec78f9e0-3f6d2db9-7640-4768-ba46-eb4e523c6140");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var body = new
            {
                messages = new[]
                {
            new
            {
                destinations = new[]
                {
                    new { to = "+998" + user.Phone_nummer }
                },
                from = messageRequestDTO.RecipientPhoneNumber,
                text = user.FullName + " " + messageRequestDTO.Message
            }
        }
            };

            //var jsonBody = JsonConvert.SerializeObject(body);
            //request.AddJsonBody(jsonBody); // 'AddJsonBody' method for setting request body
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Content: {response.Content}");
            Console.WriteLine($"Error Message: {response.ErrorMessage}");

            if (response.IsSuccessful)
            {
                var dto = new InformationDTO("send sms");
                return dto;
            }
            else
            {
                var dto = new InformationDTO("send sms failed");
                return dto;
            }
        }
    }
}
//var options = new RestClientOptions("https://z3jq8w.api.infobip.com")
//{
//    MaxTimeout = -1,
//};
//var client = new RestClient(options);
//var request = new RestRequest("/sms/2/text/advanced", Method.Post);
//request.AddHeader("Authorization", "App a1d4e89bed96f755f5e20117ec78f9e0-3f6d2db9-7640-4768-ba46-eb4e523c6140");
//request.AddHeader("Content-Type", "application/json");
//request.AddHeader("Accept", "application/json");
//var body = @"{""messages"":[{""destinations"":[{""to"":""998773164660""}],""from"":""447491163443"",""text"":""Congratulations on sending your first message.\nGo ahead and check the delivery report in the next step.""}]}";
//request.AddStringBody(body, DataFormat.Json);
//RestResponse response = await client.ExecuteAsync(request);
//Console.WriteLine(response.Content);
