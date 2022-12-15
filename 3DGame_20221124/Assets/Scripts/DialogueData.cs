using UnityEngine;

namespace Alex
{
    /// <summary>
    /// Dialogue Data
    /// </summary>
    [CreateAssetMenu(menuName = "Alex/Dialogue Data", fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("DiagloueName")]
        public string dialogueName;
        [Header("DiagloueContents"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}
