using System.Collections.Generic;
using ConsoleApp1;

namespace ConsoleApp1.Interfaces.Repositories;

public interface IDeviceRepository 
{
    void Add(Device device);
    Device GetById(int id);
    IEnumerable<Device> GetAll();
}