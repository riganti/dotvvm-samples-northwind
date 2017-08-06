namespace NorthwindStore.BL.DTO
{
    public class ProductFilterDTO
    {

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }

        public string SearchText { get; set; }

    }
}