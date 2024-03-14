namespace WebApp2.Models;
public class MinorsModel
{
    public List<Ugminor> UgMinors { get; set; }
}

public class Ugminor
{
    public string name { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public List<string> courses { get; set; }
    public string note { get; set; }
}

