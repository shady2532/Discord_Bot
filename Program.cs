using Discord;
using Discord.WebSocket;
public class Program
{
    private DiscordSocketClient? _client;
    public static Task Main(string[] args) => new Program().MainAsync();

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
        var token = File.ReadAllText("D:\\discord token\\DiscordToken.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
}