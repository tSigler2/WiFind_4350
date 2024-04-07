using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WiFind.Server.ControlModels
{
    public class PaymentReg
    {
        [Required]
        public string userid { get; set; }

        [Required]
        public string name { get; set; }

        [Required, DataType(DataType.CreditCard)]
        public string ccNumber { get; set; }

        [Required, Range(1, 10000)]
        public int cvc { get; set; }

        [Required, MaxLength(200)]
        public string address { get; set; }

        [Required, MaxLength(6)]
        public string zipCode { get; set; }

        [Required]
        public DateOnly expDate { get; set; }
    }
}