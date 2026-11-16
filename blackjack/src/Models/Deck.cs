namespace Blackjack.Models;

public class Deck
{
    private readonly List<Card> _cards = new();
    private readonly Random _random = new();

    public Deck()
    {
        Reset();
        Shuffle();
    }

    public void Reset()
    {
        _cards.Clear();
        foreach (var suit in Enum.GetValues<Suit>())
        {
            foreach (var rank in Enum.GetValues<Rank>())
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    // Embaralhamento Fisher-Yates
    public void Shuffle()
    {
        int count = _cards.Count;
        for (int i = 0; i < count; i++)
        {
            int pos = _random.Next(i, count);
            (_cards[i], _cards[pos]) = (_cards[pos], _cards[i]);
        }
    }

    public Card Draw()
    {
        // Se o baralho acabar, reinicia e reembaralha
        if (_cards.Count == 0)
        {
            Reset();
            Shuffle();
        }

        int pos = _random.Next(0, _cards.Count);
        Card card = _cards[pos];
        _cards.RemoveAt(pos);
        return card;
    }
}
