using CarService3.BL.Interfaces;
using CarService3.DL.Interfaces;
using CarService3.Models.Entities;

namespace CarService3.BL.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(
            ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Add(Car? car)
        {
            if (car == null) return;

            _carRepository.Add(car);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car? GetById(Guid id)
        {
            return _carRepository.GetById(id);
        }

        public void Delete(Guid id)
        {
            _carRepository.Delete(id);
        }
    }
}
