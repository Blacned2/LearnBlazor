using System.ComponentModel.DataAnnotations;

namespace LearnBlazor.Data
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required,StringLength(16,ErrorMessage = "En fazla 16 karakter"),MinLength(3,ErrorMessage = "En az 3 karakter")]
        public string CategoryName { get; set; }
        [Required, StringLength(30, ErrorMessage = "En fazla 30 karakter"), MinLength(5, ErrorMessage = "En az 5 karakter")]
        public string Description { get; set; }
    }
}
