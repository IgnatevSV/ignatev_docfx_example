using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystemScripts.Models
{
    /// <summary>
    /// Класс настроек диалогового окна.
    /// </summary>
    [System.Serializable]
    public class DialogueSettings
    {
        [SerializeField]
        int _id;
        /// <summary>
        /// Идентификатор диалога. ID диалога в базе данных диалогов.
        /// </summary>
        /// <returns>Идентификатор диалога.</returns>
        public int ID
        {
            private set { _id = value; }
            get { return _id; }
        }

        [SerializeField]
        string _text;
        /// <summary>
        /// Текст диалога.
        /// </summary>
        /// <returns>Текст диалога.</returns>
        public string Text
        {
            set { _text = value; }
            get { return _text; }
        }

        [SerializeField]
        bool _hasExit;
        /// <summary>
        /// Есть ли в окне диалога кнопка закрытия Close(x).
        /// </summary>
        /// <returns>Есть ли в окне диалога кнопка закрытия.</returns>
        public bool HasExit
        {
            private set { _hasExit = value; }
            get { return _hasExit; }
        }

        [SerializeField]
        Dialogue _dialoguePrefab;
        /// <summary>
        /// Префаб диалогового окна.
        /// </summary>
        /// <returns>Диалоговое окно.</returns>
        public Dialogue DialoguePrefab
        {
            private set { _dialoguePrefab = value; }
            get { return _dialoguePrefab; }
        }

        [SerializeField]
        List<AnswerSettings> _playerAnswers = new List<AnswerSettings>();
        /// <summary>
        /// Коллекция возможных ответов в данном диалоге.
        /// </summary>
        /// <returns>Коллекция возможных ответов в данном диалоге.</returns>
        public List<AnswerSettings> Answers
        {
            private set { _playerAnswers = value; }
            get { return _playerAnswers; }
        }

        /// <summary>
        /// Конструктор класса DialogueSettings.
        /// </summary>
        /// <param name="id">Идентификатор диалога. ID диалога в базе данных диалогов.</param>
        /// <param name="text">Текст диалога.</param>
        /// <param name="hasExit">Есть ли в окне диалога кнопка закрытия Close(x).</param>
        /// <param name="dialogueLocalPrefab">Префаб диалогового окна типа "Dialogue".</param>
        /// <param name="playerAnswers">Возможные ответы в данном диалоге.</param>
        public DialogueSettings(int id, string text, bool hasExit, Dialogue dialogueLocalPrefab, List<AnswerSettings> playerAnswers)
        {
            this.ID = id;
            this.Text = text;
            this.HasExit = hasExit;
            this.DialoguePrefab = dialogueLocalPrefab;
            this.Answers = playerAnswers;
        }

        /// <summary>
        /// Конструктор класса DialogueSettings.
        /// </summary>
        /// <param name="id">Идентификатор диалога. ID диалога в базе данных диалогов.</param>
        /// <param name="text">Текст диалога.</param>
        public DialogueSettings(int id, string text)
        {
            this.ID = id;
            this.Text = text;
        }
    }
}