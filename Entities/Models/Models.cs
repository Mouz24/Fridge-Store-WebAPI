using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class fridge
    {
        [Column("Id")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Fridge name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters.")]
        public string Name { get; set; }
        
        [MaxLength(60, ErrorMessage = "Maximum length for the owner name is 60 characters")]
        public string? OwnerName { get; set; }

        public Guid ModelId { get; set; }
        [ForeignKey("ModelId")]
        public fridge_model FridgeModel { get; set; }
       
    }

    public class fridge_model
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge model name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the fridge model name is 60 characters.")]
        public string NameOfModel { get; set; }

        public int? Year { get; set; }
    }

    public class products
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the product name is 60 characters.")]
        public string Product { get; set; }

        public int? DefaultQuantity { get; set; }
    }

    public class fridge_products
    {
        [Column("Id")]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public products products { get; set; }

        public Guid FridgeId { get; set; }
        [ForeignKey("FridgeId")]
        public fridge fridge { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        public int Quantity { get; set; }

    }
}