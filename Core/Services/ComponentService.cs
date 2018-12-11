using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IAsyncRepository<Component> _componentRepository;

        public ComponentService(IAsyncRepository<Component> componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public async Task CreateAsync(string name, int price, string description, int weight)
        {
            // log start

            await _componentRepository.AddAsync(new Component()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                IsDeleted = false,
                Name = name,
                Price = price,
                Description = description,
                Weight = weight
            });

            // log end
        }

        public async Task DeleteAsync(Guid id)
        {
            // log start

            var component = await _componentRepository.GetByIdAsync(id);

            await _componentRepository.DeleteAsync(component);

            // log end
        }

        public async Task EditAsync(Guid id, string name, int price, string description, int weight)
        {
            // log start

            var component = await _componentRepository.GetByIdAsync(id);
            component.Name = name;
            component.Price = price;
            component.Description = description;
            component.Weight = weight;

            await _componentRepository.UpdateAsync(component);

            // log end
        }

        public async Task<IEnumerable<Component>> GetAllAsync()
        {
            // log start

            var components = await _componentRepository.ListAllAsync();

            // log end

            return components.OrderBy(c => c.Created);
        }

        public async Task<Component> GetByIdAsync(Guid id)
        {
            // log start

            var component = await _componentRepository.GetByIdAsync(id);

            // log end

            return component;
        }
    }
}
