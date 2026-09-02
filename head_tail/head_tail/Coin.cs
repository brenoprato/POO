using System;

namespace head_tail
{
    public enum CoinSide
    {
        Heads = 0,
        Tails = 1
    }

    public class Coin
    {
        private readonly Random _random;

        public CoinSide CurrentSide { get; private set; }

        public Coin(CoinSide initialSide = CoinSide.Heads, Random random = null)
        {
            _random = random ?? new Random();
            CurrentSide = initialSide;
        }

        // Sorteia aleatoriamente entre 0 (Heads) e 1 (Tails)
        public CoinSide Flip()
        {
            CurrentSide = (CoinSide)_random.Next(2);
            return CurrentSide;
        }

        // Alterna o lado atual para o efeito visual de giro
        public void ToggleSide()
        {
            CurrentSide = (CurrentSide == CoinSide.Heads) ? CoinSide.Tails : CoinSide.Heads;
        }

        public bool IsMatch(CoinSide predictedSide)
        {
            return CurrentSide == predictedSide;
        }
    }
}
