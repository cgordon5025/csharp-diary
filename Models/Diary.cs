using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace csharp_diary.Models
{
    // public class ApplicationUser :IdentityUser
    // {
    //     public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //     {
    //         var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie)
    //             return userIdentity
    //     }
    // }
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
}