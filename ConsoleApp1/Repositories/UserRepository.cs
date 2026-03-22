namespace ConsoleApp1.Repositories;

public class UserRepository
{
    private readonly List<User> _dbSet = new();

    public void Add(User user)
    {
        _dbSet.Add(user);
    }

    public User GetById(int id)
    {
        var user = _dbSet.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with Id {id} was not found.");
        }
        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return _dbSet.AsReadOnly();
    }
}