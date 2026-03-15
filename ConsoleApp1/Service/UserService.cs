namespace ConsoleApp1.Service;

public class UserService
{
    private static List<User> _users;

    public static void addUser(User user)
    {
        _users.Add(user);
    }
}