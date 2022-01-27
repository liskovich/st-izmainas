using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Models
{    
    public class Schedule // Data
    {
        [Key]
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; }
        public long Date { get; set; }
        public List<Class> Classes { get; set; }
    }
}

/*
    string lesson = "1. st.   8:10-9:10";
	string lessonnum = lesson.Substring(0, 1);
	string classname = "10.A KLASE.1";
	string classnum = classname.Substring(0, classname.IndexOf(' ')).Replace(".", string.Empty).ToLower();
	Console.WriteLine(lessonnum);
	Console.WriteLine(classnum);
*/