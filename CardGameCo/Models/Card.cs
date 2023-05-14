using System;
using System.ComponentModel.DataAnnotations;
using CardGameCo.Interfaces;

namespace CardGameCo.Models
{
	public class Card : ICard
	{
        public Card(string german, string hungarian)
        {
            German = german;
            Hungarian = hungarian;
        }


        [StringLength(10)]
        [Required]
        [Validation(MaxLengthAttribute(10),MinLengthAttribute(10))]
		public string Hungarian { get; set; }
        public string German { get => Hungarian; set => German = value; }

        public int Indexex()
        {
            return 1;
        }
    }
}

