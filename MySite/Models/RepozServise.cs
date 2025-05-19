using System.Globalization;
using Microsoft.AspNetCore.Components;
using MySite.Components.Parser;

namespace MySite.Models;

public class RepozServise
{
    public static List<Product> Repozes { get; }= new ();
    public static async Task<int> GetLaterRepose(DateTime date)
    { 
        Repozes.Clear();
        
        var links = await Git_parse.ParseRepos();

        if (links.Count == 0)
        {
            Repozes.Add(new Product
            {
                _image = "",
                IsPublic = true,
                Name = "ERROR",
                Id = "ERROR",
                Time = "ERROR",
                Description = "No repositories found."
            });

            return 0;
        }

        int index = 0;
        foreach (var (name, link, time, description) in links)
        {
            var product = new Product
            {
                _image = null,
                IsPublic = true,
                Name = null,
                Number = null,
                Description = default,
                Id = default,
                Time = DateTime.Parse(time).ToString("yyyy")
            };

            Repozes.Add(product);
        }
        
        int count= 0;
        foreach (var repose in Repozes)
        {
            if (repose.IsPublic && date.ToString("yyyy") == repose.Time)
            {
                count++;
            }
        }

        return count;
    }
}