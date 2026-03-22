namespace ConsoleApp1;

public abstract class User
{
    private string Username {get; set;}
    public string Name {get; protected set;}
    public string Lastname {get; protected set;}
    private static int _idCount; 
    public  int Id { get; private set; }
    
    public User()
    {
        Id = ++_idCount;
    }

    protected User(string username, string name, string lastname)
    {
        Id = ++_idCount;
        Username = username;
        Name = name;
        Lastname = lastname;
    }
    
}