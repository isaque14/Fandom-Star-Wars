namespace FandomStarWars.API.Models
{
    public class ChatGptInputModel
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }

        public ChatGptInputModel(string prompt)
        {
            this.prompt = $"star wars universe: {prompt}";
            temperature = 0.2m;
            max_tokens = 100;
            model = "text-davinci-003";
        }
    }
}