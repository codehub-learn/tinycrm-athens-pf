﻿using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;

        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Customer GetCustomer(
            int id)
        { return context_.Set<Customer>().Find(id); }


        public Customer CreateCustomer(
            CreateCustomerOptions options)
        {
            if (options == null) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Vatnumber)) {
                return null;
            }

            var customer = new Customer()
            {
                Lastname = options.Lastname,
                Firstname = options.Firstname,
                VatNumber = options.Vatnumber
            };

            context_.Add(customer);
            
            if (context_.SaveChanges() > 0) {
                return customer;
            }

            return null;
        }

        public IQueryable<Customer> GetAll()
        {
            return context_.Set<Customer>();
        }

        public IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options)
        {
            if (options == null) {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Firstname)) {
                query = query.Where(c => c.Firstname == options.Firstname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber)) {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null) {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreateFrom != null) {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }
    }
}
