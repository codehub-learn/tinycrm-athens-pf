using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();

            // Insert
            var customer = new Customer()
            {
                Firstname = "Xaris",
                Lastname = "Mpouras",
                Email = "mpouras.gr"
            };

            tinyCrmDbContext.Add(customer);

            var petrogiannos = new Customer()
            {
                CustomerId = 155,
                Firstname = "Dimitris",
                Lastname = "Petrogiannos",
                Email = "petrogiannos.gr"
            };

            tinyCrmDbContext.Add(petrogiannos);
            tinyCrmDbContext.SaveChanges();

            // Get data
            var customer2 = tinyCrmDbContext
                .Set<Customer>()
                .Where(c => c.CustomerId == customer.CustomerId)
                .SingleOrDefault();

            // Update
            customer2.VatNumber = "123456789";
            tinyCrmDbContext.SaveChanges();

            // Delete
            tinyCrmDbContext.Remove(customer2);
            tinyCrmDbContext.SaveChanges();
        }
    }
}
