using ProjectPractice.Domain.Helpers.IHelperBuilder;
using ProjectPractice.Domain.Parametrized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectPractice.Domain.Helpers.HelperBuilder
{
    public class FilterBuilder<T> : IFilterBuilder<T>
    {
        public string BuildeFilter(int size, string columnName, T[]? values)
        {
            if (values != null && values.Length > 0) 
            {
                return $"{(size > 5 ? " AND ": "")}{columnName} IN ('{string.Join("','", values)}')";
            }
            return "";
        }
    }
}