using System;

namespace TinyCrm
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public decimal TotalGross { get; set; }
        public bool IsActive { get; set; }

        public Customer()
        {
        }

        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }
    }
}
