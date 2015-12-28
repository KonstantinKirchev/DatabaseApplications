﻿using System.ComponentModel.DataAnnotations;

namespace _5.Problem
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(0,10)]
        public int Stars { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}