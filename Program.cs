using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Play a pre-recorded voice greeting to welcome the user
            PlayVoiceGreeting("welcome_message.wav");

            // Display an ASCII art banner to enhance the user experience
            DisplayAsciiArt();

            // Prompt the user to enter their name for a personalized experience
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            // If the user doesn't enter a name, set a default name "User"
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }

            // Display a welcome message and inform the user about the chatbot's purpose
            Console.WriteLine($"\nHello {userName}, welcome to the Cybersecurity Awareness Bot!");
            Console.WriteLine("I'm here to help you stay safe online. Ask me anything about cybersecurity.");
            Console.ResetColor();

            // Start a loop to continuously receive and process user input
            while (true)
            {
                // Prompt the user for a question or input
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.ToLower(); // Convert input to lowercase for easy comparison
                Console.ResetColor();

                // Ensure the user enters valid input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("\nBot: Please enter a valid question.");
                    continue;
                }

                // Respond to user queries based on keyword detection
                if (userInput.Contains("how are you"))
                {
                    ChatResponse("I'm just a bot, but I'm here to help you stay secure online!");
                }
                else if (userInput.Contains("purpose"))
                {
                    ChatResponse("My purpose is to educate you about cybersecurity and how to stay safe online.");
                }
                else if (cyberSecurityTopics.ContainsKey(userInput)) // Check if the user's query is in the dictionary
                {
                    ChatResponse(cyberSecurityTopics[userInput]);
                }
                else if (userInput.Contains("what can i ask you about"))
                {
                    ChatResponse("You can ask me about: Phishing attacks, Password Safety, Safe Browsing, Online Scams, Data Privacy, Ransomware, VPNs, Firewalls.");
                }
                else if (userInput.Contains("exit")) // Allow the user to exit the chat
                {
                    ChatResponse("Goodbye! Stay safe online!");
                    break;
                }
                else
                {
                    ChatResponse("I didn't quite understand that. Could you rephrase?");
                }
            }
        }

        // Method to play a voice greeting if the file exists
        static void PlayVoiceGreeting(string filePath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer("C:\\Users\\RC_Student_lab\\source\\repos\\CyberSecurityChatbot\\bin\\Debug\\welcome_message.wav");
                player.PlaySync();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[Error] Unable to play the voice greeting. Make sure the file exists.");
                Console.WriteLine(e.Message);
            }
        }

        // Method to display a decorative ASCII art banner to welcome users
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
     ██████╗██╗   ██╗██████╗ ███████╗███████╗███████╗████████╗██╗   ██╗██████╗  ██████╗ ████████╗
    ██╔════╝██║   ██║██╔══██╗██╔════╝██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██╔═══██╗╚══██╔══╝
    ██║     ██║   ██║██████╔╝███████╗█████╗  █████╗     ██║   ██║   ██║██████╔╝██║   ██║   ██║   
    ██║     ██║   ██║██╔═══╝ ╚════██║██╔══╝  ██╔══╝     ██║   ██║   ██║██╔═══╝ ██║   ██║   ██║   
    ╚██████╗╚██████╔╝██║     ███████║███████╗███████╗   ██║   ╚██████╔╝██║     ╚██████╔╝   ██║   
     ╚═════╝ ╚═════╝ ╚═╝     ╚══════╝╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝      ╚═════╝    ╚═╝   
    ");
            Console.ResetColor();
        }


        // Method to display the chatbot's responses with a typing effect
        static void ChatResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Bot: ");
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(20); // Typing effect simulation
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // This acts as a dictionary containing predefined responses for cybersecurity topics
        static readonly Dictionary<string, string> cyberSecurityTopics = new Dictionary<string, string>
        {
            { "phishing", "Phishing is when hackers trick you into giving personal information through fake emails or websites. Don't click suspicious links!" },
            { "password safety", "Use strong passwords with a mix of letters, numbers, and symbols. Enable two-factor authentication for extra security." },
            { "safe browsing", "Always check website URLs, avoid public Wi-Fi for transactions, and keep your browser updated to stay secure online." },
            { "online scams", "Online scams trick users into giving away money or information. Be cautious of too-good-to-be-true offers and verify sources." },
            { "data privacy", "Protect your data by using encryption, avoiding oversharing on social media, and adjusting privacy settings on apps and websites." },
            { "ransomware", "Ransomware is malicious software that locks your files and demands a ransom. Avoid suspicious downloads and back up your data regularly." },
            { "vpns", "A VPN (Virtual Private Network) encrypts your internet connection, making your online activity more private and secure from hackers." },
            { "firewalls", "Firewalls act as a barrier between your computer and the internet, blocking unauthorized access to protect your data." }
        };
    }
}
