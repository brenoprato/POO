namespace Blackjack.Models;

public class Player
{
    private readonly List<Card> _cards = new();

    public string Name { get; }
    public IReadOnlyList<Card> Cards => _cards;

    public Player(string name = "Jogador")
    {
        Name = name;
    }

    public void AddCard(Card card) => _cards.Add(card);

    public void ClearCards() => _cards.Clear();

    // Soma as cartas visíveis e reduz cada Ás de 11 para 1 caso a soma ultrapasse 21
    public int CalculateScore()
    {
        int sum = 0;
        int aces = 0;

        foreach (Card card in _cards)
        {
            if (card.IsFaceUp)
            {
                sum += card.GetValue();
                if (card.Rank == Rank.Ace) aces++;
            }
        }

        while (sum > 21 && aces > 0)
        {
            sum -= 10;
            aces--;
        }

        return sum;
    }

    public bool IsBust() => CalculateScore() > 21;
}
