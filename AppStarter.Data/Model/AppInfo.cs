using Core.Model;
using System.ComponentModel.DataAnnotations;

namespace AppStarter.Data.Model
{
	public class AppInfo : IModelA
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength(250)]
		public string Description { get; set; }

		[Required]
		[MaxLength(250)]
		public string Path { get; set; }
	}
}