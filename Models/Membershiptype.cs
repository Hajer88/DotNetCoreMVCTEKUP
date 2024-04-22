using System;
namespace Project.FirstMVC._2024.Models
{
	public class Membershiptype
	{
		public Membershiptype()
		{
		}
        public int Id { get; set; }
        public double SignUpFee { get; set; }

        public int DurationInMonth { get; set; }

        public double DiscountRate { get; set; }

        public virtual ICollection<Customer>? Customers { get; set; }
    }
}

