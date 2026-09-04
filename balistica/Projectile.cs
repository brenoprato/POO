using System;

namespace balistica
{
    public class Projectile
    {
        public const double Gravity = 9.81;

        public double InitialVelocityX { get; set; }
        public double InitialVelocityY { get; set; }
        public double ElapsedTime { get; private set; }

        public Projectile(double velocityX, double velocityY)
        {
            InitialVelocityX = velocityX;
            InitialVelocityY = velocityY;
            ElapsedTime = 0;
        }

        // Calcula a posicao X no instante t usando movimento uniforme (MRU)
        public double GetPositionX(double time)
        {
            return InitialVelocityX * time;
        }

        // Calcula a posicao Y no instante t usando a formula do sovetao com gravidade 9.81
        public double GetPositionY(double time)
        {
            return (InitialVelocityY * time) - (0.5 * Gravity * time * time);
        }

        // Avanca o tempo da simulacao
        public void AdvanceTime(double deltaSeconds)
        {
            ElapsedTime += deltaSeconds;
        }

        // Calcula o tempo total de voo ate atingir o solo
        public double GetFlightTime()
        {
            if (InitialVelocityY <= 0)
            {
                return 0;
            }
            return (2 * InitialVelocityY) / Gravity;
        }

        // Calcula a altura maxima atingida pelo projetil
        public double GetMaxHeight()
        {
            if (InitialVelocityY <= 0)
            {
                return 0;
            }
            return (InitialVelocityY * InitialVelocityY) / (2 * Gravity);
        }

        // Calcula o alcance horizontal maximo
        public double GetMaxRange()
        {
            return InitialVelocityX * GetFlightTime();
        }

        // Reinicia a simulacao
        public void Reset()
        {
            ElapsedTime = 0;
        }
    }
}
