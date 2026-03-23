using ConsoleApp1.Entity.Rent;

namespace ConsoleApp1.Repositories;

public class RentalRepository
{
    private readonly List<Rental> _rentals = new();

    public void Add(Rental rental) => _rentals.Add(rental);

    public Rental GetById(int id)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == id); 
        if (rental == null) throw new KeyNotFoundException($"Rental {id} not found.");
        return rental;
    }
    public IEnumerable<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.IsActive);
    }
    public int GetActiveRentalCountForUser(int userId)
    {
        return _rentals.Count(r => r.User.Id == userId && r.IsActive);
    }
    public IEnumerable<Rental> GetOverdueRentals(DateTimeOffset currentDate)
    {
        return _rentals.Where(r => r.IsActive && r.PlannedReturnDate < currentDate);
    }

    public IEnumerable<Rental> GetAll() => _rentals.AsReadOnly();
}