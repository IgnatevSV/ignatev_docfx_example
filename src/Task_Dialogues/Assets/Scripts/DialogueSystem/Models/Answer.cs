using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystemScripts.Models
{
    /// <summary>
    /// Класс ответа в диалоговом окне.
    /// </summary>
    public class Answer : MonoBehaviour
    {
        [SerializeField]
        Button _answerButton;

        [SerializeField]
        Text _answerText;

        /// <summary>
        /// Активен ли ответ на данный момент.
        /// </summary>
        /// <returns>Активен ли ответ на данный момент.</returns>
        public bool IsAnswerActive
        {
            get { return _answerButton.interactable; }
            set { _answerButton.interactable = value; }
        }
        
        /// <summary>
        /// Инициализация ответа, применение заданных настроек. 
        /// </summary>
        /// <param name="settings">Настройки ответа.</param>
        public void InitAnswer(AnswerSettings settings)
        {
            InitButton(settings.IsActive, settings.CustomEvents);
            InitAnswerText(settings.Text);
        }

        void InitButton(bool isActive, Button.ButtonClickedEvent buttonEvents)
        {
            _answerButton.interactable = isActive;

            for (int i = 0; i < buttonEvents.GetPersistentEventCount(); i++)
            {
                _answerButton.onClick = buttonEvents;
            }
        }

        void InitAnswerText(string text)
        {
            _answerText.text = text;
        }
    }
}