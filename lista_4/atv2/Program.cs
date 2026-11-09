using System;

namespace MyApp
{
    internal class A
    {
        private int x;
        protected int y;
        public int z;

        public A(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int GetX()
        {
            return this.x;
        }
    }

    internal class B : A
    {
        private int w;

        public B(int x, int y, int z, int w) : base(x, y, z)
        {
            this.w = w;

            MostraValores();
        }

        public void MostraValores()
        {
            Console.WriteLine($"x = {this.GetX()}, y = {this.y}, z = {this.z}, w = {this.w}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            B objB = new B(1, 2, 3, 4);
        }
    }
}
