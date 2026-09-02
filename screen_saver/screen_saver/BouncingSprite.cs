using System;
using System.Drawing;

namespace screen_saver
{
    public class BouncingSprite
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public BouncingSprite(Point initialPosition, Size size, int velocityX = 2, int velocityY = 2)
        {
            Position = initialPosition;
            Size = size;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        // Move o sprite e retorna true caso tenha colidido com qualquer borda
        public bool MoveAndBounce(Size bounds)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return false;
            }

            int nextX = Position.X + VelocityX;
            int nextY = Position.Y + VelocityY;
            bool bounced = false;

            // Inverte a direcao horizontal e ajusta a posicao para nao ultrapassar a borda
            if (nextX <= 0)
            {
                VelocityX = Math.Abs(VelocityX);
                nextX = 0;
                bounced = true;
            }
            else if (nextX + Size.Width >= bounds.Width)
            {
                VelocityX = -Math.Abs(VelocityX);
                nextX = Math.Max(0, bounds.Width - Size.Width);
                bounced = true;
            }

            // Inverte a direcao vertical e ajusta a posicao para nao ultrapassar a borda
            if (nextY <= 0)
            {
                VelocityY = Math.Abs(VelocityY);
                nextY = 0;
                bounced = true;
            }
            else if (nextY + Size.Height >= bounds.Height)
            {
                VelocityY = -Math.Abs(VelocityY);
                nextY = Math.Max(0, bounds.Height - Size.Height);
                bounced = true;
            }

            Position = new Point(nextX, nextY);
            return bounced;
        }
    }
}
