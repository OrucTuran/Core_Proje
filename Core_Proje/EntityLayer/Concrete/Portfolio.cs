﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string ProjectURL { get; set; }
        public string BigImageURL { get; set; }
        public string Platform { get; set; }
        public string Price { get; set; }
        public bool Status { get; set; }
        public string ImageA { get; set; }
        public string ImageB { get; set; }
        public string ImageC { get; set; }
        public string ImageD { get; set; }
        public int Completion { get; set; }
    }
}
