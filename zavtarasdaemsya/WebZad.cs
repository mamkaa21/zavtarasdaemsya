using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavtarasdaemsya
{
    public partial class WebZad : DbContext
    {
        public WebZad() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Razdel> Razdels { get; set; }

        public WebZad(DbContextOptions<WebZad> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=192.168.200.13;userid=student;password=student;database=WebZad", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));
        }


    }
}
