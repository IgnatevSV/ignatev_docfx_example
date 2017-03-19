using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystemScripts.Models
{
    /// <summary>
    /// Класс настроек ответа.
    /// </summary>
    [System.Serializable]
    public class AnswerSettings
    {
        [SerializeField]
        string _text;
        /// <summary>
        /// Текст ответа.
        /// </summary>
        /// <returns>Текст ответа.</returns>
        public string Text
        {
            set { _text = value; }
            get { return _text; }
        }

        [SerializeField]
        bool _isActive = true;
        /// <summary>
        /// Активен ли ответ в начальный момент.
        /// </summary>
        /// <returns>Активен ли ответ в начальный момент.</returns>
        public bool IsActive
        {
            set { _isActive = value; }
            get { return _isActive; }
        }

        [SerializeField]
        Answer _answerLocalPrefab;
        /// <summary>
        /// Префаб ответа.
        /// </summary>
        /// <returns>Ответ в диалоговом окне.</returns>
        public Answer AnswerPrefab
        {
            private set { _answerLocalPrefab = value; }
            get { return _answerLocalPrefab; }
        }

        [SerializeField]
        Button.ButtonClickedEvent _customEvents;
        /// <summary>
        /// Дополнительные события, вызываемые по выбору ответа.
        /// </summary>
        /// <returns>Дополнительные события, вызываемые по выбору ответа.</returns>
        public Button.ButtonClickedEvent CustomEvents
        {
            private set { _customEvents = value; }
            get { return _customEvents; }
        }

        /// <summary>
        /// Конструктор класса AnswerSettings.
        /// </summary>
        /// <param name="text">Текст ответа.</param>
        /// <param name="isActive">Активен ли ответ в начальном состоянии.</param>
        /// <param name="answerPrefab">Префаб диалогового окна класса "Answer".</param>
        /// <param name="customEvents">Дополнительные события, вызываемые по выбору ответа.</param>
        public AnswerSettings(string text, bool isActive, Answer answerPrefab, Button.ButtonClickedEvent customEvents)
        {
            this.Text = text;
            this.IsActive = isActive;
            this.AnswerPrefab = answerPrefab;
            this.CustomEvents = customEvents;
        }

        /// <summary>
        /// Конструктор класса AnswerSettings.
        /// </summary>
        /// <param name="text">Текст ответа.</param>
        public AnswerSettings(string text)
        {
            this.Text = text;
        }
    }
}