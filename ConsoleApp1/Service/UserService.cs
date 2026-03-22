using ConsoleApp1.DTOs.User;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Service;

public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public int CreateUser(CreateUserDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Lastname))
            throw new ArgumentException("Name and Lastname are required.");

        User newUser = dto switch
        {
            CreateStudentDTO student => new Student(student.Username, student.Name, student.Lastname),
            CreateEmployeeDTO employee => new Employee(employee.Username, employee.Name, employee.Lastname),
            _ => throw new ArgumentException("Invalid user type.")
        };

        _repository.Add(newUser);
        return newUser.Id;
    }
}