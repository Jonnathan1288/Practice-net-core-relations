

using EFCommonCRUD.Interfaces;
using EFCommonCRUD.Models;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Domain.Entities.Public;
using System.Reflection;

namespace ProjectPractice.Infrastructure.Repositories.Generic
{
    public class NPRepository<T, ID> : INPRepository<T, ID> where T : class
    {

        private readonly BdBillContext _context;
        private readonly DbSet<T> _entities;
        public NPRepository(BdBillContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public long Count() => _entities?.AsNoTracking().LongCount() ?? 0;
        

        public async Task<long> CountAsync() => await _entities.AsNoTracking().LongCountAsync();

        public int Delete(T entity)
        {
            _entities.Remove(entity);
            return _context.SaveChanges();
        }

        public int DeleteAll(IEnumerable<T> entities)
        {
            int affectedRows = 0;
            foreach (T entity in entities)
            {
                _entities.Remove(entity);
                affectedRows += _context?.SaveChanges() ?? 0;
            }
            return affectedRows;
        }

        public async Task<int> DeleteAllAsync(IEnumerable<T> entities)
        {
            int affectedRows = 0;
            foreach (T entity in entities)
            {
                _entities.Remove(entity);
                if (_context == null) return 0;
                affectedRows += await _context.SaveChangesAsync();
            }
            return affectedRows;
        }

        public int DeleteAllById(IEnumerable<ID> ids)
        {
            int affectedRows = 0;
            foreach (ID id in ids)
            {
                T? t = _entities.Find(id);
                if (t != null) _context?.Remove(t);
                affectedRows += _context?.SaveChanges() ?? 0;
            }
            return affectedRows;
        }

        public async Task<int> DeleteAllByIdAsync(IEnumerable<ID> ids)
        {
            int affectedRows = 0;
            foreach (ID id in ids)
            {
                T? t = await _context.Set<T>().FindAsync(id);
                if (t != null) _context?.Remove(t);
                affectedRows += await _context!.SaveChangesAsync(); ;

            }
            return affectedRows;
        }

        public Task<int> DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public int DeleteById(ID id)
        {
            T? t = _entities.Find(id);
            if (t != null) _context?.Remove(t);
            return _context?.SaveChanges() ?? 0;
        }

        public async Task<int> DeleteByIdAsync(ID id)
        {
            int affectedRows = 0;
            T? t = await _entities.FindAsync(id);
            if (t != null) _context.Remove(t);
            affectedRows += await _context.SaveChangesAsync();
            return affectedRows;
        }

        public bool ExistsById(ID id) => _context?.Set<T>().Find(id) != null;

        public async Task<bool> ExistsByIdAsync(ID id)
        {
            T? t = await _entities.FindAsync(id);
            return t != null;
        }

        public IPage<T> FindAll(IPageable pageable)
        {   // Get the offset and page size.
            int skip = Convert.ToInt32(pageable.GetOffset());
            int pageSize = pageable.GetPageSize();

            List<T> data = new();
            // Get sort from pageable.
            if (pageable.GetSort().IsSorted())
            {
                Sort sort = pageable.GetSort();
                List<Order> orders = sort.GetOrders();
                foreach (Order order in orders)
                {
                    if (order.IsAscending())
                    {
                        _entities.OrderBy(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                    else
                    {
                        _entities.OrderByDescending(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                }
                data.AddRange(_entities.AsNoTracking().Skip(skip).Take(pageSize).ToList());
            }
            else
            {
                data.AddRange(_entities.AsNoTracking().Skip(skip).Take(pageSize).ToList());
            }
            return new Page<T>(data, pageable, Count());
        }

        public IEnumerable<T> FindAll() => _entities.AsNoTracking().ToList() ?? new();

        public async Task<IPage<T>> FindAllAsync(IPageable pageable)
        {
            // Get the offset and page size.
            int skip = Convert.ToInt32(pageable.GetOffset());
            int pageSize = pageable.GetPageSize();
            List<T> data = new();
            // Get sort from pageable.
            if (pageable.GetSort().IsSorted())
            {
                Sort sort = pageable.GetSort();
                List<Order> orders = sort.GetOrders();
          
                foreach (Order order in orders)
                {
                    if (order.IsAscending())
                    {
                        _entities.OrderBy(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                    else
                    {
                        _entities.OrderByDescending(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                }
                data.AddRange(await _entities.AsNoTracking().Skip(skip).Take(pageSize).ToListAsync());
            }
            else
            {
                data.AddRange(await _entities.AsNoTracking().Skip(skip).Take(pageSize).ToListAsync());
            }
            return new Page<T>(data, pageable, await CountAsync());
        }

        public async Task<IEnumerable<T>> FindAllAsync() => await _entities.AsNoTracking().ToListAsync();

        public IEnumerable<T> FindAllById(IEnumerable<ID> ids)
        {
            return _entities.AsNoTracking().AsEnumerable().Where(t =>
            {
                PropertyInfo property = t.GetType().GetProperties().First(prop =>
                {
                    return prop.PropertyType == ids.First()!.GetType() || prop.Name.Equals("Id");
                });
                return ids.Contains((ID?)property.GetValue(t, null));
            }).ToList();
        }



        public T? FindById(ID id)
        {
            T? entity = _entities.Find(id);
            return entity;
        }

        public ValueTask<T?> FindByIdAsync(ID id) => _entities.FindAsync(id);
        

        public T Save(T entity)
        {
            T saved = _entities.Add(entity).Entity;
            _context.SaveChanges();
            return saved;
        }

        public IEnumerable<T> SaveAll(IEnumerable<T> entities)
        {
            List<T> saved = new();
            foreach (T entity in entities)
            {
                T t = _entities.Add(entity).Entity ?? entity;
                _context.SaveChanges();
                saved.Add(t);
            }
            return saved;
        }

        public async Task<IEnumerable<T>> SaveAllAsync(IEnumerable<T> entities)
        {
            List<T> saved = new();
            foreach (T entity in entities)
            {
                T t = (await _entities.AddAsync(entity)).Entity;
                _ = await _context.SaveChangesAsync();
                saved.Add(t);
            }
            return saved;
        }

        public async ValueTask<T> SaveAsync(T entity)
        {
            T saved = (await _entities.AddAsync(entity)).Entity;
            await SaveBDAsync();
            return saved;
        }

        public async Task SaveBDAsync()
        {
            await _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            T updated = _entities.Update(entity).Entity ?? entity;
            _context.SaveChanges();
            return updated;
        }

        public IEnumerable<T> UpdateAll(IEnumerable<T> entities)
        {
            List<T> updated = new();
            foreach (T entity in entities)
            {
                T t = _entities.Update(entity).Entity;
                _context.SaveChanges();
                updated.Add(t);
            }
            return updated;
        }

        public async Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> entities)
        {
            List<T> updated = new();
            foreach (T entity in entities)
            {
                T t = _entities.Update(entity).Entity;
                await SaveBDAsync();
                updated.Add(t);
            }
            return updated;
        }

        public async ValueTask<T> UpdateAsync(T entity)
        {
            T updated = _entities.Update(entity).Entity;
            await SaveBDAsync();
            return updated;
        }
    }
}
