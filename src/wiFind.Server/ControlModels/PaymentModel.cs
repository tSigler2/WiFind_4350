using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace wiFind.Server.ControlModels
{
    public class PurchaseModel
    {
        [Required]
        public string name { get; set; }

        [Required, DataType(DataType.CreditCard)]
        public string ccNumber { get; set; }

        [Required]
        public string cvc { get; set; }

        [Required, MaxLength(200)]
        public string address { get; set; }

        [Required, MaxLength(6)]
        public string zipCode { get; set; }

        [Required]
        public string expDate { get; set; } // would need to implement a regex to validate MM/YYYY
    }
}