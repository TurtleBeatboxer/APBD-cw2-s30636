using ConsoleApp1.DTOs.Device;
using ConsoleApp1.Interfaces.Services;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Service;

public class DeviceService
{
    private readonly DeviceRepository _repository;
    
    public DeviceService(DeviceRepository repository)
    {
        _repository = repository;
    }

    public int CreateDevice(CreateDeviceDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Device name cannot be null or empty.");

        // 1. Map the DTO to the Entity
        Device newDevice = dto switch
        {
            CreateLaptopDTO laptopDto => new Laptop(
                laptopDto.Name, laptopDto.Serial, laptopDto.RentalPrice, 
                laptopDto.GPUModel, laptopDto.Model, laptopDto.CPUModel),

            CreateCameraDTO cameraDto => new Camera(
                cameraDto.Name, cameraDto.Serial, cameraDto.RentalPrice, 
                cameraDto.LenseBrand, cameraDto.MaxZoomLevel),

            CreateProjectorDTO projectorDto => new Projector(
                projectorDto.Name, projectorDto.Serial, projectorDto.RentalPrice, 
                projectorDto.LightLumen, projectorDto.IsWiFi),

            _ => throw new ArgumentException("Invalid DTO type provided.")
        };
        
        _repository.Add(newDevice);

        return newDevice.Id;
    }
}