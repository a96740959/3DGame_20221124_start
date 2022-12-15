using UnityEngine;
using TMPro;

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

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject nextTriangle;
        #endregion

        #region Event Area
        private void Awake()
        {
            groupDialogue = GameObject.Find("DialogueSystemCanvas").GetComponent<CanvasGroup>();
            textName = GameObject.Find("Dialoguer").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("DialogueContent").GetComponent<TextMeshProUGUI>();
            nextTriangle = GameObject.Find("FinishedLogo");
            nextTriangle.SetActive(false);
        } 
        #endregion
    }
}
