using System.Text.RegularExpressions;

namespace bankproject
{


	public abstract class Person
	{
		public string name;
		public string surrname;
		private string pesel;
		public EnumSex sex;
		#region Properties
		public string Pesel
		{
			get => pesel;
			set
			{
				if (!Regex.IsMatch(value, @"\d{11}"))
				{
					throw new WrongPeselException("Pesel is invalid");
				}
				pesel = value;
			}
		}
		#endregion

		public Person() { }
		public Person(string name, string surrname, string pesel, EnumSex sex)
		{
			this.name = name;
			this.surrname = surrname;
			Pesel = pesel;
			this.sex = sex;
		}

		public override string ToString()
		{
			return $"{name} {surrname} [{sex}], PESEL: {Pesel}";
		}


	}





	public enum EnumSex { K, M }
}
