using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectiveGame.Domain.Entities
{
	public class Breadcrumb
	{
		public string AspArea { get; set; }

		public string AspPage{ get; set; }

		public string LinkName { get; set; }

		public bool IsActive { get; set; }
	}
}
