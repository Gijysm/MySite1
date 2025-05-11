using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace MySite.Components.Parser;

public struct GitRepo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("html_url")]
    public string Link { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime Time { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
public class Git_parse
{
    private static async Task<string> CallUrl(string url)
    {
        HttpClient client = new();
        var response = await client.GetStringAsync(url);
        return response;
    }

    private static async Task<List<GitRepo>> GetReposInfo()
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MyApp/1.0)");
        var response = await client.GetFromJsonAsync<List<GitRepo>>("https://api.github.com/users/Gijysm/repos");
        return response ?? new();
    }
    public static async Task<List<(string, string,string, string)>> ParseRepos()
    {
       var repos = await GetReposInfo();
       return repos.Select(x => (x.Name, x.Link, x.Time.ToString("yyyy-MM-dd HH:mm"), x.Description)).ToList();
    }
    public static Task<string> GetGit()
    {
        return CallUrl("https://github.com/Gijysm?tab=repositories");
    }
}