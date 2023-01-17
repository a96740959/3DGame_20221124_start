using UnityEngine;
using UnityEngine.Events;


namespace Alex
{
    public class IntereactableSystem : MonoBehaviour
    {
        [SerializeField, Header("DialogueData")]
        private DialogueData dataDialogue;

        [SerializeField, Header("EventAfterDialogue")]
        private UnityEvent onDialogueFinish;

        [SerializeField, Header("PropActive")]
        private GameObject propActive;

        [SerializeField, Header("DialogueDataActive")]
        private DialogueData dataDialogueActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("DialogueSystemCanvas").GetComponent<DialogueSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive);
                }
            }

        }

        private void OnTriggerExit(Collider other)
        {


        }

        private void OnTriggerStay(Collider other)
        {
            
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}
