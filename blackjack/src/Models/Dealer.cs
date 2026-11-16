namespace Blackjack.Models;

public class Dealer : Player
{
    public Dealer() : base("Banca")
    {
    }

    public void RevealCards()
    {
        foreach (Card card in Cards)
            card.IsFaceUp = true;
    }

    // Banca compra enquanto estiver atrás do jogador e abaixo de 21
    public bool ShouldHit(int playerScore)
    {
        int score = CalculateScore();
        return score < playerScore && score < 21;
    }
}
