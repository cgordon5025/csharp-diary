using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace csharp_diary.Models
{
    public class Diary
    {
        public int ID { get; set; }
        public String EntryTitle { get; set; }
        public String EntiryDesc { get; set; }
        public Diary()
        {
            EntryDate = DateTime.Today;

        }
        public DateTime EntryDate { get; set; }
        public string Owner { get; set; }
        // public string UserID { get; set; }
        // [ForeignKey("UserID")]
        // public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class DiaryContext : DbContext
    {
        DbSet<Diary> Diaries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=Test;User=sa; Password=your_password; TrustServerCertificate=True");
        }
    }
}