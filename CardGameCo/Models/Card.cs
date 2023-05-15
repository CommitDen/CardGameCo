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

		public string Hungarian { get; set; }
        public string German { get; set; }
    }
}

