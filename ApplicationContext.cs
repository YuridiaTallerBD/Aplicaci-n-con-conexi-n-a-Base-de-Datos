﻿using Microsoft.EntityFrameworkCore;

namespace MariaAspNet.Models
{
	public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
	{
	    public DbSet<StudentModel> student { get; set; }
	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		modelBuilder.Entity<StudentModel>().HasData(
		    new StudentModel
		    {
			nocontrol = "44444", 
			fullname = "Rosa Maria Perez Gallardo", 
			career = "Ing. en Agronomia",
			curp= "AUGI080911MOCQLLA0", 
			currentgrade =  7
		    },
		    new StudentModel
		    {
		    	nocontrol = "5555", 
			fullname = "Marcos Castellanos Orozco", 
			career = "Ing. en Agronomia",
			curp= "BAMY060530HOCRRDA8", 
			currentgrade =  8
		    }
		);
	    }
	}
}