using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace wiFind.Server.ControlModels
{
    public class PurchaseModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string name { get; set; }

        [Required, DataType(DataType.CreditCard)]
        public string ccNumber { get; set; }

        [Required, System.ComponentModel.DataAnnotations.RangeAttribute(1, 10000)]
        public int cvc { get; set; }

        [Required, MaxLength(200)]
        public string address { get; set; }

        [Required, MaxLength(6)]
        public string zipCode { get; set; }

        [Required]
        public string expDate { get; set; } // would need to implement a regex to validate MM/YYYY

        // added below two for logic in purchaseCart
        public DateTime start {  get; set; }

        [Required]
        public List<string> checkoutCart { get; set; }
    }
}