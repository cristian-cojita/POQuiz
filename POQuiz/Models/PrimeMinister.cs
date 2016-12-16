using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POQuiz.Models
{
    public class PrimeMinister
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}