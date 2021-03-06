﻿using System;
using System.Linq;

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

        public Result<Customer> CreateCustomer(
            CreateCustomerOptions options)
        {
            if (options == null) {
                return Result<Customer>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.Vatnumber)) {
                return Result<Customer>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty VatNumber");
            }

            var customer = new Customer()
            {
                Lastname = options.Lastname,
                Firstname = options.Firstname,
                VatNumber = options.Vatnumber
            };

            context_.Add(customer);

            var rows = 0;

            try {
                rows = context_.SaveChanges();
            } catch(Exception ex) {
                return Result<Customer>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0) {
                return Result<Customer>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Customer could not be updated");
            }

            return Result<Customer>.CreateSuccessful(customer);
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

        public Result<bool> UpdateCustomer(int customerId,
            UpdateCustomerOptions options)
        {
            var result = new Result<bool>();

            if (options == null) {
                result.ErrorCode = StatusCode.BadRequest;
                result.ErrorText = "Null options";

                return result;
            }

            var customer = SearchCustomers(new SearchCustomerOptions
            {
                CustomerId = customerId
            }).SingleOrDefault();

            if (customer == null) {
                result.ErrorCode = StatusCode.NotFound;
                result.ErrorText = $"Customer with id {customerId} was not found";

                return result;
            }

            if (!string.IsNullOrWhiteSpace(options.Email)) {
                customer.Email = options.Email;
            }

            if (options.IsActive != null) {
                customer.IsActive = options.IsActive.Value;
            }

            if (context_.SaveChanges() == 0) {
                result.ErrorCode = StatusCode.InternalServerError;
                result.ErrorText = $"Customer could not be updated";
                return result;
            }

            result.ErrorCode = StatusCode.OK;
            result.Data = true;

            return result;
        }
    }
}
