﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels
{
    public sealed class InvoiceApiModel : IConvertModel<InvoiceApiModel, Invoice>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }

        public decimal Total { get; set; }

        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        public IList<InvoiceLineApiModel> InvoiceLines { get; set; }
        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        public CustomerApiModel Customer { get; set; }
        
        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        public Invoice Convert => new Invoice
        {
            InvoiceId = InvoiceId,
            CustomerId = CustomerId,
            InvoiceDate = InvoiceDate,
            BillingAddress = BillingAddress,
            BillingCity = BillingCity,
            BillingState = BillingState,
            BillingCountry = BillingCountry,
            BillingPostalCode = BillingPostalCode,
            Total = Total
        };
    }
}