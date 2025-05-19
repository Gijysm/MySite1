using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace MySite.Components.Parser;
public struct GitUserInfo
{
    [JsonPropertyName("login")]
    public string Name { get; set; }
    [JsonPropertyName("avatar_url")]
    public string Image { get; set; }
    [JsonPropertyName("name")]
    public string? FullName { get; set; }
    [JsonPropertyName("company")]
    public string? Company { get; set; }
    [JsonPropertyName("location")]
    public string? Location { get; set; }
    [JsonPropertyName("bio")]
    public string? Bio { get; set; }
    [JsonPropertyName("public_repos")]
    public int? Public { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime Created { get; set; }
}
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
        /*client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue();*/
        
        client.DefaultRequestHeaders.UserAgent.ParseAdd("MySiteApp");
        var response = await client.GetFromJsonAsync<List<GitRepo>>("https://api.github.com/users/Gijysm/repos");
        return response ?? new();
    }
    private static async Task<GitUserInfo> GetUserInfo()
    {
        using var client = new HttpClient();
        /*client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue();*/
        
        client.DefaultRequestHeaders.UserAgent.ParseAdd("MySiteApp");
        return await client.GetFromJsonAsync<GitUserInfo>("https://api.github.com/users/Gijysm");
    }
    public static async Task<List<(string, string,string, string, string, string, int, string)>> ParseInfoUser()
    {
        var user = await GetUserInfo();
        
        return new List<(string, string, string, string, string, string, int, string)>
        {
            (
                user.Image,
                user.Name,
                user.FullName ?? "",
                user.Location ?? "",
                user.Created.ToString("yyyy-MM-dd HH:mm"),
                user.Bio ?? "",
                user.Public ?? 0,
                user.Company ?? ""
            )
        };
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