using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace ZezinhoBot
{
    public class BotService
    {

        #region Private

        private readonly string _uri;
        private readonly NetworkCredential _networkCredential;
        private const string _linkWorkspace = "https://gateway.watsonplatform.net/conversation/api/v1/workspaces/{0}/message?version={1}";
        
        #endregion 

        public BotService(string workspaceIBM, string userIBM, string passwordIBM)
        {
            _uri = string.Format(_linkWorkspace, workspaceIBM, DateTime.Today.ToString("yyyy-MM-dd"));
            _networkCredential = new NetworkCredential(userIBM, passwordIBM);
        }

        public async Task<string> ChatService(string inputMessage, string context = null)
        {
            var chatRequest = "{\"input\": {\"text\": \"" + inputMessage + "\"}, \"alternate_intents\": true}";
            if (!string.IsNullOrEmpty(context)) chatRequest = chatRequest + "\"context\": \"" + context + "\"";

            var clientHandler = new HttpClientHandler { Credentials = _networkCredential };
            var uriClient = new HttpClient(clientHandler);
            var uriRequest = new HttpRequestMessage {
                Content = new StringContent(chatRequest.ToString(), Encoding.UTF8, "application/json")
            };

            var chatResponse = await uriClient.PostAsync(_uri, uriRequest.Content);

            uriClient.Dispose();
            clientHandler.Dispose();

            return await chatResponse.Content.ReadAsStringAsync();
        }
    }
}
