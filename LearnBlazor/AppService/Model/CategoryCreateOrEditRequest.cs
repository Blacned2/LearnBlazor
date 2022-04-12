namespace LearnBlazor.AppService.Model
{
    public class CategoryCreateOrEditRequest
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
