namespace ProjectPractice.API.DTOs
{
    public class BrandListDTO 
        //: BrandDTO
    {
        public ICollection<string> Models { get; set; } = new List<string>();
    }
}
