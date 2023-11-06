using ProjectPractice.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Interfaces.Services.Public
{
    public interface IModelService
    {
        public Task<IEnumerable<Model>> FindAllAsync();
        public Task<Model> SaveAsync(Model m);
    }
}
