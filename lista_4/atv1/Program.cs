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

        public A(int x, int y, int z, bool incrementar)
        {
            if (incrementar)
            {
                this.x = x + 1;
                this.y = y + 2;
                this.z = z + 3;
            }
            else
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        public void Exibir()
        {
            Console.WriteLine($"x = {this.x}, y = {this.y}, z = {this.z}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            A obj1 = new A(10, 20, 30);
            A obj2 = new A(10, 20, 30, true);

            obj1.Exibir();
            obj2.Exibir();
        }
    }
}
