using System;

namespace TinyCrm
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        public Customer(string vatNumber)
        {
            if (!IsValidVatNumber(vatNumber)) {
                throw new Exception("Invalid VatNumber");
            }

            VatNumber = vatNumber;
            Created = DateTime.Now;
        }

        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}
