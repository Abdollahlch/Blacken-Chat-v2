using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UserBusnissLogic
{
    public   class GeminiAI
    {
        public GeminiAI(string apiKey)
        {
            this.apiKey = apiKey;

        }

        public string apiKey { set; get; }
        private  async Task<string> SendRequestAndGetResponse(string userInput)
        {
            string jsonBody = $@"{{
                ""contents"": [
                    {{
                        ""role"": """",
                        ""parts"": [
                            {{
                                ""text"": ""{userInput}""
                            }}
                        ]
                    }}
                ],
                ""generationConfig"": {{
                    ""temperature"": 0.9,
                    ""topK"": 50,
                    ""topP"": 0.95,
                    ""maxOutputTokens"": 4096,
                    ""stopSequences"": []
                }},
                ""safetySettings"": [

                ]
            }}";

            var client = new HttpClient();
            //client.Timeout = TimeSpan.FromSeconds(10);
            
            

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.0-pro:generateContent?key={apiKey}");
            request.Content = new StringContent(jsonBody, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
            
                
                var response = await client.SendAsync(request).ConfigureAwait(false);
                

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody.Substring(responseBody.IndexOf("\"text\": \"") + 9, responseBody.IndexOf("\"", responseBody.IndexOf("\"text\": \"") + 10) - responseBody.IndexOf("\"text\": \"") - 9);
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<string> GetAiResponse(string userInput)
        {
        

            string output = await SendRequestAndGetResponse(userInput);
            if (output ==null)
            {
                return null;
            }
            output = output.Replace("\\n", Environment.NewLine)
                           .Replace("\n", "")
                           .Replace("**", "");

            return output;
        }
    }
}
