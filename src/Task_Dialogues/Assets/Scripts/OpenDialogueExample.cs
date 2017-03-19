using UnityEngine;
using DialogueSystemScripts;

namespace Other.UsingExamples
{
    /// <summary>
    /// Класс-пример открытия диалога в DialogueSystem.
    /// </summary>
    public class OpenDialogueExample : MonoBehaviour
    {
        DialogueSystem _dialogueSystem;

        [SerializeField]
        int _dialogueID = 0;

        /// <summary>
        /// Метод, открывающий новый диалог в DialogueSystem.
        /// </summary>
        public void OpenDialogue()
        {
            if (_dialogueSystem == null)
            {
                FindDialogueSystem();
            }
            _dialogueSystem.OpenNewDialogue(_dialogueID);
        }

        void FindDialogueSystem()
        {
            _dialogueSystem = FindObjectOfType<DialogueSystem>();
        }
    }
}