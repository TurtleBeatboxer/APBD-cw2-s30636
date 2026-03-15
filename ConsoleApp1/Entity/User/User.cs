namespace ConsoleApp1;

public abstract class User
{
    private string Username {get; set;}
    private string Name {get; set;}
    private string Lastname {get; set;}
    private static int _idCount; 
    private int Id { get; }
    
    public User()
    {
        Id = ++_idCount;
    }

    protected User(string username, string name, string lastname, int id)
    {
        Username = username;
        Name = name;
        Lastname = lastname;
        Id = id;
    }
}