namespace ConsoleApp1.DTOs.User;

public abstract class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
}

public abstract class CreateUserDTO
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
}