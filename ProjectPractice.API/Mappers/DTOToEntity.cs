using ProjectPractice.API.DTOs;
using ProjectPractice.Domain.Entities.Public;

namespace ProjectPractice.API.Mappers
{
    public class DTOToEntity
    {
        public static Brand BrandFromBrandDTO(BrandDTO dto) 
        {
            return new()
            {
                BrandName = dto.BrandName,
                BrandStatus = true,
            };
        }

        public static List<Brand> BrandFromBrandListDTO(BrandListDTO dto) 
        {
            List<Brand> brands = new ();

            foreach (var item in dto.Models)
            {
                brands.Add(new() 
                {
                    BrandName = item,
                    BrandStatus = true,
                });
            }

            return brands;
        }

    }
}
