using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using DotNetEnv;  // ✅ Import DotNetEnv

class Program
{
    static async Task Main()
{
    Env.Load(); // ✅ Load .env file
    string? apiKey = Environment.GetEnvironmentVariable("HUGGINGFACE_API_KEY");

    if (string.IsNullOrEmpty(apiKey))
    {
        Console.WriteLine("❌ Error: API key is missing! Make sure it's set in the .env file.");
        return;
    }

    Console.WriteLine($"✅ API Key Loaded: {apiKey.Substring(0, 5)}******"); // Debugging (hide most of the key)

    Console.WriteLine("AI Chatbot: Type 'exit' to end the chat.");
    while (true)
{
    Console.Write("You: ");
    string? userInput = Console.ReadLine(); // ✅ Use nullable string

    if (string.IsNullOrWhiteSpace(userInput)) 
    {
        Console.WriteLine("❌ Invalid input. Please enter some text.");
        continue; // ✅ Skip the loop iteration if input is null/empty
    }

    if (userInput.ToLower() == "exit")
        break;

    string aiResponse = await GetAIResponse(userInput, apiKey);
    Console.WriteLine($"AI: {aiResponse}\n");
}
}

    static async Task<string> GetAIResponse(string prompt, string apiKey)
    {
        var client = new RestClient("https://api-inference.huggingface.co/models/tiiuae/falcon-7b-instruct"); // Replace with a working model
        var request = new RestRequest();
        request.Method = Method.Post;

        request.AddHeader("Authorization", $"Bearer {apiKey}");
        request.AddHeader("Content-Type", "application/json");

        var body = new { inputs = prompt };
        request.AddJsonBody(body);

        var response = await client.ExecuteAsync(request);

        if (response is null)
        {
            return "Error: No response received from API.";
        }

        if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
        {
            return $"Error: {response.StatusCode} - {response.ErrorMessage ?? "Unknown API error"}";
        }

        try
        {
            string content = response.Content ?? "";
            var jsonResponse = JArray.Parse(content);
            var generatedText = jsonResponse[0]?["generated_text"]?.ToString()?.Trim();

            return !string.IsNullOrEmpty(generatedText) ? generatedText : "No response.";
        }
        catch (Exception ex)
        {
            return $"Error parsing response: {ex.Message}";
        }
    }
}
