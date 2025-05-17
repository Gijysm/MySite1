namespace MySite.Models;

public struct UserInfo
{

    public string Name { get; set; }

    public string Image { get; set; }

    public string? FullName { get; set; }

    public string? Company { get; set; }

    public string? Location { get; set; }

    public string? Bio { get; set; }

    public int? Public { get; set; }

    public string Created { get; set; }
}