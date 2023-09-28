using System;
namespace LAB_2_INHERITANCE
{
	internal class PartTime: Employee
	{
		//Properties
		public double Rate { get; set; }
		public double Hours { get; set; }
		//Constructors
		public PartTime()
		{

		}

		public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) :base(id, name, address, phone, sin, dob, dept)
		{
			this.Rate = rate;
			this.Hours = hours;
		}
		//Methods

		public override double getPay()
		{
			return Rate * Hours;
		}

		public override string ToString()
		{
           return $"ID: {this.ID} \nName: {this.Name} \nAddress: {this.Address} \nPhone: {this.Phone} \nSIN: {this.SIN} \nDOB: {this.DOB} \nDept: {this.Dept} \nPay: {getPay()}";

        }
	}
}

