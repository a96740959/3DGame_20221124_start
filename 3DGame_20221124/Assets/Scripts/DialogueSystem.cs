using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Alex
{
    /// <summary>
    /// dialogue system
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region Data Area
        [SerializeField, Header("Dialogue Interval"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("Dialogue Opening")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("Dialogue Button")]
        private KeyCode dialogueKey = KeyCode.Q;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject nextTriangle;
        #endregion

        private PlayerInput playerInput;

        private UnityEvent onDialogueFinish;

        #region Event Area
        private void Awake()
        {
            groupDialogue = GameObject.Find("DialogueSystemCanvas").GetComponent<CanvasGroup>();
            textName = GameObject.Find("Dialoguer").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("DialogueContent").GetComponent<TextMeshProUGUI>();
            nextTriangle = GameObject.Find("FinishedLogo");
            nextTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();
            StartDialogue(dialogueOpening);
        }
        #endregion

        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }
        /// <summary>
        /// Fadein Fadeout 
        /// </summary>
        /// <returns></returns>
        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContents.Length; j++)

            {
                textContent.text = "";

                nextTriangle.SetActive(false);

                string dialogue = data.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueInterval;
                }

                nextTriangle.SetActive(true);

                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("Button down!");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;

            onDialogueFinish?.Invoke();
        }
    }
}
