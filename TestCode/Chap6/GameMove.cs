using System;
using System.Collections;


namespace Chap6
{
    public class GameMove
    {
        private IEnumerator cross;
        private IEnumerator circle;
        private int move = 0;
        const int MaxMouse = 9;
        public GameMove()
        {
            cross = Cross();
            circle = Circle();
        }

        public IEnumerator Cross()
        {
            while (true)
            {
                Console.WriteLine("Cross,move {0}", move);
                if (++move >= MaxMouse)
                    yield break;
                yield return circle;
            }
        }
        public IEnumerator Circle()
        {
            while (true)
            {
                Console.WriteLine("Circle,move {0}", move);
                if (++move >= MaxMouse)
                    yield break;
                yield return cross;
            }
        }
    }
}
