using System;
namespace LAB_2_INHERITANCE
{
	internal class Salaried: Employee
	{
		//Properties
		public double Salary { get; set; }
		//Constructors

		public Salaried()
		{

		}

		public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base (id, name, address, phone, sin, dob, dept)
		{
			this.Salary = salary;
        }

		//Methods

		public override double getPay()
		{
			double WeeklyPay = Salary / 52;
			return WeeklyPay;
		}

		public override string ToString()
		{
            return $"ID: {this.ID} \nName: {this.Name} \nAddress: {this.Address} \nPhone: {this.Phone} \nSIN: {this.SIN} \nDOB: {this.DOB} \nDept: {this.Dept} \nPay: {getPay()}";
        }
    }
       
    }



