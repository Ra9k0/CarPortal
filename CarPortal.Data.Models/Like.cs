using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPortal.Data.Models
{
	public class Like
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public ApplicationUser User { get; set; } = null!;

		[ForeignKey(nameof(Offer))]
		public Guid OfferId { get; set; }

		public Offer Offer { get; set; } = null!;

		public DateTime LikeDate { get; set; }
	}
}
