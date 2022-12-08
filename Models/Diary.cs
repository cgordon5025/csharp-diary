using System;
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

    }
}



