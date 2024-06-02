namespace MariaAspNet.Models;
using System.ComponentModel.DataAnnotations;

public class StudentModel
	{
		[Key]
		public String nocontrol {get; set;}
		
		public String fullname {get; set;}
		public String career {get; set;}
		public String curp {get; set;}
		public int currentgrade {get; set;}

		public StudentModel () {}
		public StudentModel (String nocontorl, String fullname, String career, String curp, int currentgrade)
		{
			this.nocontrol = nocontorl;
			this.fullname = fullname;
			this.career = career;
			this.curp = curp;
			this.currentgrade = currentgrade;
		}
	}
	
