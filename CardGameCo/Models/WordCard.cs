using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardGameCo.Interfaces;

namespace CardGameCo.Models
{
    [Table("WordCards")]
	public class WordCard : ICard
	{
        public WordCard(string language1, string language2, string word1, string word2)
        {
            Language1 = language1;
            Language2 = language2;
            Word1 = word1;
            Word2 = word2;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public string Language1 { get; set; }

        public string Language2 { get; set; }

        public string Word1 { get; set; }

        public string Word2 { get; set; }


        public string Text1 { get => Word1; set => Word1 = value; }
        public string Text2 { get => Word2; set => Word2 = value; }
    }
}

