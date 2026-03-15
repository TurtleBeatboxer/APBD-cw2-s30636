namespace ConsoleApp1.Service;

public class UserService
{
    private static List<User> UserRepository = new List<User>();   
    public static void addUser(User user)
    {
        UserRepository.Add(user);
    }
}