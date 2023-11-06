
using ProjectPractice.Domain.Parametrized;

namespace ProjectPractice.Domain.Helpers.IHelperBuilder
{
    public interface IFilterBuilder<T>
    {
        public string BuildeFilter(int size, string columnName, T[]? values);
    }
}
