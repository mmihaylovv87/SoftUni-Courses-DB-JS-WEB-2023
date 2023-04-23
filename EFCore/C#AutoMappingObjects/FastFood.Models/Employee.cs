namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        public Employee()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}