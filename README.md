# 🤖 AI Chatbot (C# Console App)

This is a simple **AI-powered chatbot** built in **C#** using **.NET**. It connects to an AI API (e.g., Hugging Face, OpenAI, or Ollama) to generate responses to user queries.

## 🚀 Features

- Interactive chatbot in the **console**
- Uses **AI models** to generate intelligent responses
- Supports multiple AI backends (Hugging Face, OpenAI, or local models like Ollama)
- Secure API key management using **.env** file
- Clean and structured error handling

---

## 📌 Prerequisites

Make sure you have the following installed:

- **.NET SDK (8.0 or higher)** → [Download .NET](https://dotnet.microsoft.com/en-us/download)
- **Git** (optional, for version control) → [Download Git](https://git-scm.com/downloads)
- **VS Code or any C# IDE**

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository

```sh
git clone https://github.com/YOUR_USERNAME/AIChatbot.git
cd AIChatbot
```

### 2️⃣ Install Dependencies

```sh
dotnet restore
```

### 3️⃣ Set Up API Key

1. Create a **.env** file in the project folder:
   ```sh
   touch .env
   ```
2. Add your API key inside `.env`:
   ```sh
   HUGGINGFACE_API_KEY=your_real_api_key
   ```
   **For OpenAI users:**
   ```sh
   OPENAI_API_KEY=your_openai_api_key
   ```

> 🚨 **Make sure **``** is added to **`` to prevent API key leaks!

### 4️⃣ Run the Chatbot

```sh
dotnet run
```

💬 **Start chatting!** Type a message and receive AI responses. Type `exit` to end the chat.

---

## 🔥 API Configuration

The chatbot can work with different AI APIs. Update the **API URL** inside `Program.cs` based on your preferred AI service:

### **Hugging Face API (Free Models)**

```csharp
var client = new RestClient("https://api-inference.huggingface.co/models/tiiuae/falcon-7b-instruct");
```

### **OpenAI API (GPT-4 / GPT-3.5)**

```csharp
var client = new RestClient("https://api.openai.com/v1/chat/completions");
```

### **Ollama (Local AI, No API Needed)**

```csharp
var client = new RestClient("http://localhost:11434/api/generate");
```

---

## 🛠️ Development & Deployment

### **Building the App**

```sh
dotnet build
```

### **Creating a Standalone Executable**

```sh
dotnet publish -c Release -r win-x64 --self-contained true
```

Replace `win-x64` with `osx-arm64` or `linux-x64` for other platforms.

---

## 🤝 Contributing

Feel free to fork this repository, submit issues, or make pull requests!

---

## 📜 License

This project is **open-source** under the **MIT License**.

---

## 🎯 Next Steps

🔹 Add **GUI support** (e.g., WPF or Blazor UI)\
🔹 Improve **AI model responses**\
🔹 Integrate **speech-to-text for voice chat** 🎙️

🚀 **Enjoy chatting with AI!** Let me know if you need any modifications. 😊

