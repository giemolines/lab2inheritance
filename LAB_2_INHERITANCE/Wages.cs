using System;
namespace LAB_2_INHERITANCE
{
	internal class Wages:Employee
	{
		//Properties

		public double Rate { get; set; }
		public double Hours { get; set; }

		//Constructors

		public Wages()
		{

		}

		public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
		{
			this.Rate = rate;
			this.Hours = hours;
		}

		//Methods

		public override double getPay()
		{
			if (Hours > 40)
			{
				double OvertimeHours = Hours - 40;
				double pay = (OvertimeHours * (Rate * 1.5)) + 40 * Rate;
				return pay;
			}
			else
			{
				double pay = Hours * Rate;
				return pay;
			}
		}
        public override string ToString()
        {
            return $"ID: {base.ID} \nName: {base.Name} \nAddress: {base.Address} \nPhone: {base.Phone} \nSIN: {base.SIN} \nDOB: {base.DOB} \nDept: {base.Dept} \nPay: {getPay()}";
        }

    }
}

