using System.Collections;
using UnityEngine;

namespace Alex
{
    public class RandomJumpScared : MonoBehaviour
    {
        public GameObject image;
        public float randNum, waitTime;
        public bool looping;

        void Start()
        {
            looping = true;
            StartCoroutine(randoScares());
        }
        IEnumerator randoScares()
        {
            while (looping == true)
            {
                yield return new WaitForSeconds(waitTime);
                randNum = Random.Range(0, 2);
                if (randNum == 0)
                {
                    image.SetActive(true);
                }
                if (randNum == 1)
                {
                    
                }
            }
        }
    }
}

