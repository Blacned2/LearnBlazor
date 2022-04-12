using System.ComponentModel.DataAnnotations;

namespace LearnBlazor.Data
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, StringLength(16, ErrorMessage = "En fazla 16 karakter"), MinLength(3, ErrorMessage = "En az 3 karakter")]
        public string CustomerName { get; set; }

        [Required, StringLength(16, ErrorMessage = "En fazla 16 karakter"), MinLength(5, ErrorMessage = "En az 5 karakter")]
        public string Address { get; set; }

        [Required, StringLength(16, ErrorMessage = "En fazla 16 karakter"), MinLength(5, ErrorMessage = "En az 5 karakter")]
        public string Email { get; set; }

    }
}
