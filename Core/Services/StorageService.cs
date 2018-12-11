using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAsyncRepository<Storage> _storageRepository;
        private readonly IAsyncRepository<Component> _componentRepository;

        public StorageService(IAsyncRepository<Storage> storageRepository, IAsyncRepository<Component> componentRepository)
        {
            _storageRepository = storageRepository;
            _componentRepository = componentRepository;
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            // log start

            var items = await _storageRepository.ListAllAsync();

            return items.OrderBy(i => i.Created);

            // log end
        }

        public async Task<Storage> GetByIdAsync(Guid id)
        {
            // log start

            var item = await _storageRepository.GetByIdAsync(id);

            return item;

            // log end
        }

        public async Task AddAsync(Guid componentId, int piece)
        {
            // log start

            var items = await _storageRepository.ListAllAsync();
            var item = items.Where(i => i.ComponentId == componentId).FirstOrDefault();
            if (item == null)
            {
                var component = await _componentRepository.GetByIdAsync(componentId);

                await _storageRepository.AddAsync(new Storage()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    IsDeleted = false,
                    Piece = piece,
                    ComponentId = componentId,
                    Component = component
                });
            }
            else
            {
                item.Piece += piece;
                await _storageRepository.UpdateAsync(item);
            }

            // log end
        }

        public async Task RemoveAsync(Guid componentId, int piece)
        {
            // log start

            var items = await _storageRepository.ListAllAsync();
            var item = items.Where(i => i.ComponentId == componentId).FirstOrDefault();

            if (item == null || item?.Piece == 0)
            {
                throw new InvalidOperationException("Ez az alkatrész még nincs készleten, nem lehet belőle kivenni!");
            }
            else
            {
                if(item.Piece < piece)
                {
                    throw new InvalidOperationException("Nem lehet több darabot kivenni, mint amennyi készleten van!");
                }

                item.Piece -= piece;
                await _storageRepository.UpdateAsync(item);
            }

            // log end
        }
    }
}
