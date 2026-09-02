using System;

namespace cara_coroa
{
    /// <summary>
    /// Represents the two faces of a coin.
    /// </summary>
    public enum CoinSide
    {
        Heads = 0,
        Tails = 1
    }

    /// <summary>
    /// Encapsulates the state and behavior of a coin in an Object-Oriented model.
    /// </summary>
    public class Coin
    {
        private readonly Random _random;

        /// <summary>
        /// Gets the current face of the coin.
        /// </summary>
        public CoinSide CurrentSide { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class.
        /// </summary>
        /// <param name="initialSide">Initial coin face (defaults to Heads).</param>
        /// <param name="random">Optional Random instance.</param>
        public Coin(CoinSide initialSide = CoinSide.Heads, Random random = null)
        {
            _random = random ?? new Random();
            CurrentSide = initialSide;
        }

        /// <summary>
        /// Flips the coin randomly and returns the resulting side.
        /// </summary>
        /// <returns>The resulting <see cref="CoinSide"/>.</returns>
        public CoinSide Flip()
        {
            CurrentSide = (CoinSide)_random.Next(2);
            return CurrentSide;
        }

        /// <summary>
        /// Toggles the coin side (used during flipping animation).
        /// </summary>
        public void ToggleSide()
        {
            CurrentSide = (CurrentSide == CoinSide.Heads) ? CoinSide.Tails : CoinSide.Heads;
        }

        /// <summary>
        /// Verifies whether the player's prediction matches the coin's current side.
        /// </summary>
        /// <param name="predictedSide">The prediction made by the player.</param>
        /// <returns>True if the prediction matches; otherwise, false.</returns>
        public bool IsMatch(CoinSide predictedSide)
        {
            return CurrentSide == predictedSide;
        }
    }
}
