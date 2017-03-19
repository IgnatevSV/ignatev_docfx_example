using UnityEngine;
using DialogueSystemScripts;

namespace Other.UsingExamples
{
    /// <summary>
    /// Класс-пример разблокировки закрытых(неактивных) вариантов ответа в системе диалогов.
    /// </summary>
    public class UnlockAnswerExample : MonoBehaviour
    {
        DialogueSystem _dialogueSystem;

        [SerializeField]
        int _dialogueID;

        [SerializeField]
        int _answerID;

        /// <summary>
        /// Метод, разблокирующий закрытый(неактивный) вариант ответа в системе диалогов.
        /// </summary>
        public void UnlockAnswer()
        {
            if (_dialogueSystem == null)
            {
                InitDialogueSystem();
            }
            _dialogueSystem.GetDialogueSettings(_dialogueID).Answers[_answerID].IsActive = true;
        }

        void InitDialogueSystem()
        {
            _dialogueSystem = FindObjectOfType<DialogueSystem>();
        }
    }
}