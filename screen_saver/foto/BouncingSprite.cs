using System;
using System.Drawing;

namespace foto
{
    /// <summary>
    /// Represents a 2D bouncing sprite with position, size, velocity, and boundary collision physics.
    /// </summary>
    public class BouncingSprite
    {
        /// <summary>
        /// Gets or sets the current (X, Y) location of the sprite.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets the dimensions (Width, Height) of the sprite.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the horizontal velocity.
        /// </summary>
        public int VelocityX { get; set; }

        /// <summary>
        /// Gets or sets the vertical velocity.
        /// </summary>
        public int VelocityY { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BouncingSprite"/> class.
        /// </summary>
        /// <param name="initialPosition">The initial coordinates of the sprite.</param>
        /// <param name="size">The dimensions of the sprite.</param>
        /// <param name="velocityX">The initial horizontal speed and direction.</param>
        /// <param name="velocityY">The initial vertical speed and direction.</param>
        public BouncingSprite(Point initialPosition, Size size, int velocityX = 2, int velocityY = 2)
        {
            Position = initialPosition;
            Size = size;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        /// <summary>
        /// Updates the sprite's position based on its velocity and handles bouncing against container boundaries.
        /// </summary>
        /// <param name="bounds">The dimensions of the container bounding box.</param>
        public void MoveAndBounce(Size bounds)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
            }

            int nextX = Position.X + VelocityX;
            int nextY = Position.Y + VelocityY;

            // Handle left collision
            if (nextX <= 0)
            {
                VelocityX = Math.Abs(VelocityX);
                nextX = 0;
            }
            // Handle right collision
            else if (nextX + Size.Width >= bounds.Width)
            {
                VelocityX = -Math.Abs(VelocityX);
                nextX = Math.Max(0, bounds.Width - Size.Width);
            }

            // Handle top collision
            if (nextY <= 0)
            {
                VelocityY = Math.Abs(VelocityY);
                nextY = 0;
            }
            // Handle bottom collision
            else if (nextY + Size.Height >= bounds.Height)
            {
                VelocityY = -Math.Abs(VelocityY);
                nextY = Math.Max(0, bounds.Height - Size.Height);
            }

            Position = new Point(nextX, nextY);
        }
    }
}
