namespace Blackjack.Models;

// Ordem (0 a 3) alinhada às linhas do spritesheet
public enum Suit
{
    Hearts = 0,
    Clubs = 1,
    Diamonds = 2,
    Spades = 3
}

// Ordem (0 a 12) alinhada às colunas do spritesheet
public enum Rank
{
    Two = 0, Three = 1, Four = 2, Five = 3, Six = 4,
    Seven = 5, Eight = 6, Nine = 7, Ten = 8,
    Jack = 9, Queen = 10, King = 11, Ace = 12
}

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }
    public bool IsFaceUp { get; set; }

    public Card(Suit suit, Rank rank, bool isFaceUp = true)
    {
        Suit = suit;
        Rank = rank;
        IsFaceUp = isFaceUp;
    }

    // Ás inicia valendo 11; o ajuste para 1 é feito em Player.CalculateScore()
    public int GetValue()
    {
        return Rank switch
        {
            Rank.Two => 2,
            Rank.Three => 3,
            Rank.Four => 4,
            Rank.Five => 5,
            Rank.Six => 6,
            Rank.Seven => 7,
            Rank.Eight => 8,
            Rank.Nine => 9,
            Rank.Ten or Rank.Jack or Rank.Queen or Rank.King => 10,
            Rank.Ace => 11,
            _ => throw new Exception("Rank inválido em Card.GetValue()")
        };
    }

    public static bool operator ==(Card? a, Card? b) => a?.GetValue() == b?.GetValue();
    public static bool operator !=(Card? a, Card? b) => a?.GetValue() != b?.GetValue();
    public static bool operator >(Card a, Card b) => a.GetValue() > b.GetValue();
    public static bool operator <(Card a, Card b) => a.GetValue() < b.GetValue();
    public static bool operator >=(Card a, Card b) => a.GetValue() >= b.GetValue();
    public static bool operator <=(Card a, Card b) => a.GetValue() <= b.GetValue();

    public override bool Equals(object? obj) => obj is Card other && this == other;
    public override int GetHashCode() => GetValue().GetHashCode();
}
