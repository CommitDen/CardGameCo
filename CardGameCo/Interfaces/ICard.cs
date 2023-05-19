using System;
namespace CardGameCo.Interfaces
{
    public interface ICard
    {
        string Language1 { get; set; }
        string Language2 { get; set; }
        string Text1 { get; set; }
        string Text2 { get; set; }
    }
}