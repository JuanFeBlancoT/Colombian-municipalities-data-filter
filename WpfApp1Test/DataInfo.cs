using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Test
{
	internal class DataInfo
	{
		public string depCode { get; set; }
		public string munCode { get; set; }
		public string depName { get; set; }
		public string munName { get; set; }
		public string typeX { get; set; }

		public DataInfo(string a, string b, string c, string d, string e)
		{
			this.depCode = a;
			this.munCode = b;
			this.depName = c;
			this.munName = d;
			this.typeX = e;
		}

		public bool IsInitial(string letter)
		{
						if (letter.Equals(" "))
						{
								return true;
						}
						else {
								string actualInitial = depName.Substring(0, 1);
								return actualInitial.Equals(letter);
						}
			
		}

		override
		public string ToString() {

			return "Municipio: " + munCode + "Depto: " + depName ;
		}
	}

}


