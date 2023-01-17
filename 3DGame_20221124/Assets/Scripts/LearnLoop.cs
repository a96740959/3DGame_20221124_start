using UnityEngine;

namespace Alex
{
    public class LearnLoop : MonoBehaviour
    {
        private void Awake()
        {
            for (int i = 0; i < 10; i++)
            {
                print("Loop:" + i);
            }

            if (true)
            {
                print("?");
            }

            int number = 0;

            while (number < 5)
            {
                print("forever");
                print("while count:" + number);
                number++;
            }
        }

    }
}
