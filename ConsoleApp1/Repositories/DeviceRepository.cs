using System.Collections.Generic;
using System.Linq;
using ConsoleApp1;
using ConsoleApp1.Interfaces.Repositories;

namespace ConsoleApp1.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly List<Device> _dbSet = new();

    public void Add(Device device)
    {
        _dbSet.Add(device);
    }

    public Device GetById(int id)
    {
        var device = _dbSet.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            throw new KeyNotFoundException($"Device with Id {id} was not found.");
        }
        return device;
    }

    public IEnumerable<Device> GetAll()
    {
        return _dbSet;
    }
}