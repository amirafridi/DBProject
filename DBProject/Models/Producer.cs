using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class Producer
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Rating { get; set; }
        public List<Movie> Movies { get; set; }

    }
}