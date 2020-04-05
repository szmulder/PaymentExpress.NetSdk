using System;
using System.Collections.Generic;
using TestMvcCore.Models;

namespace TestMvcCore.Repository
{
    public class OrderDb
    {
        private decimal vatRate = decimal.Parse("0.20");

        public Order GetNewOrder()
        {
            var order = new Order()
            {
                OrderId = 1000,
                UserName = "test payment",
                UserEmail = "paymentTest@hotmail.com",
                UserId = 79892,
                CreatedDate = DateTime.UtcNow,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem()
                    {
                        OrderItemId = 100001,
                        OrderId = 1000,
                        ProductId = 1099,
                        Quantity = 1,
                        ProductDesc = "Iphone X",
                        UnitPrice = 1000,
                        TotalPrice = 1000
                    }
                }
            };

            decimal total = 0;
            foreach (var item in order.OrderItems)
            {
                total += item.TotalPrice;
            }
            order.SubTotal = total;
            order.Vat = total * vatRate;
            order.Total = total + order.Vat;

            return order;
        }
    }
}
