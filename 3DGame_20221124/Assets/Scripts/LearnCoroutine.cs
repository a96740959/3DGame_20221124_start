using UnityEngine;
using System.Collections;

namespace Alex
{
    /// <summary>
    /// Coroutine System
    /// </summary>

    public class LearnCoroutine : MonoBehaviour
    {
        private string testDialogue = "Ah.... Who am I? What is this place?";

        private void Awake()
        {
            StartCoroutine(Test());

            print("Letter 1:" + testDialogue[0]);

            StartCoroutine(ShowDialogue());

            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator Test()
        {
            print("<color=#33ff33>First program</color>");
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>Second program</color>");
            yield return new WaitForSeconds(3);
            print("<color=#3333ff>Third program</color>");


        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0-6]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[7-10]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[11-13]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[14-15]);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator ShowDialogueUseFor()
        {
            for (int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
