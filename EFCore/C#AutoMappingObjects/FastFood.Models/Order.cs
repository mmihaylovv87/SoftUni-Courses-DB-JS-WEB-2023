namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>(); 
        }

        public int Id { get; set; }

        public string Customer { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public OrderType Type { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}