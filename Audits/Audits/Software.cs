using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits
{
    public class Software
    {
		private int id;
		private string code;
		private int description;
		private DateTime instalationDate;
		private int type;
		private int renovation;
		private string keyLicence;

		public string KeyLicence
		{
			get { return keyLicence; }
			set { keyLicence = value; }
		}


		public Software() { }

		public int Renovation
		{
			get { return renovation; }
			set { renovation = value; }
		}

		public int Type
		{
			get { return type; }
			set { type = value; }
		}


		public DateTime MyProperty
		{
			get { return instalationDate; }
			set { instalationDate = value; }
		}


		public int Description
		{
			get { return description; }
			set { description = value; }
		}


		public string Code
		{
			get { return code; }
			set { code = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public override string ToString()
		{
			return string.Format("[{0}] {1}", this.code, this.description);
		}

	}
}
