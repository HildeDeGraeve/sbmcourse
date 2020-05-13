﻿using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyApplication.DomainModel.DeliveryAggregate
{
    public class Delivery : BaseEntity
    {
        public string ForCustomerId { get; set; }
        public string AtDeliveryAddressId { get; set; }
        public string ForDate { get; set; }
        public bool IsPlanned { get; set; }

        private readonly List<DeliveryPart2> _deliveryParts = new List<DeliveryPart2>();

        public IEnumerable<DeliveryPart2> DeliveryParts
        {
            get { return new ReadOnlyCollection<DeliveryPart2>(_deliveryParts); }
        }

        public static Delivery Create(string customerId, string deliveryAddressId, string date)
        {
            return new Delivery
            {
                Id = Guid.NewGuid().ToString(),
                ForCustomerId = customerId,
                AtDeliveryAddressId= deliveryAddressId,
                ForDate = date,
                IsPlanned = false
            };
        }

        public void SetPlanned()
        {
            IsPlanned = true;
            SendDomainEvent(new DeliveryPlannedEvent(Id));
        }
        public void AddDeliverPart(string deliveryId, double weight, double volume, List<string> productIds)
        {
            _deliveryParts.Add(new DeliveryPart2
            {
                Id = Guid.NewGuid().ToString(),
                //ProductIds = new List<DeliveryPartProductId>(),
                Weight = weight,
                Volume = volume
            });
        }
    }
}
