using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Repositories.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;


namespace ProjectPractice.Application.Services.Public
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _repository;

        public ModelService(IModelRepository repository) 
        {
            _repository = repository;   
        }
        public async Task<IEnumerable<Model>> FindAllAsync() => await _repository.FindAllAsync();

        public async Task<Model> SaveAsync(Model m) => await _repository.SaveAsync(m);
    }
}
