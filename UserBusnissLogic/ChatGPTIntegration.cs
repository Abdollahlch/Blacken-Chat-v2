using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ChatAppBusinessLogic
{
    public static class ChatGPTClient
    {
       

       public static async Task<string> GetAiAnswer(string prompt)
        {
            // Create an instance of HttpClient
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(2);
                // Set the base URL of the API
                client.BaseAddress = new Uri("http://localhost:11434/api/chat");

                // Define the request data
                var requestData = new
                {
                    model = "llama2",
                    prompt = prompt,
                    stream = false // Set to false to receive a single response
                };

                try
                {
                    // Serialize the request data to JSON
                    string requestDataJson = JsonConvert.SerializeObject(requestData);

                    // Create a StringContent object with the JSON data
                    var content = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

                    // Send a POST request to the API endpoint with the request data
                    HttpResponseMessage response = await client.PostAsync("/api/generate", content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response using Newtonsoft.Json
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);

                        // Get the AI response
                        string aiResponse = jsonResponse.response;

                        // Return the AI response
                        return aiResponse;
                    }
                    else
                    {
                        // If the request was not successful, return an empty string
                        Console.WriteLine($"Request failed with status code {response.StatusCode}");
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions and return an empty string
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return string.Empty;
                }
            }
        }
    }

    // Helper class to deserialize ChatGPT API response
    public class ChatGPTResponse
    {
        public ChatGPTChoice[] choices { get; set; }
    }

    public class ChatGPTChoice
    {
        public string text { get; set; }
    }

}
