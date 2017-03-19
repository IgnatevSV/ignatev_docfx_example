using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using DialogueSystemScripts.Models;

namespace DialogueSystemScripts
{
    /// <summary>
    /// Класс для работы с базой данных диалогов на XML.
    /// </summary>
    public class XML_DialoguesDatabase : DialoguesDatabase
    {
        [SerializeField]
        TextAsset _xmlFile;

        List<DialogueSettings> _dialoguesSettings = new List<DialogueSettings>();

        /// <summary>
        /// Метод для получения настроек диалога.
        /// </summary>
        /// <param name="dialogueID">Идентификатор диалога. ID диалога в базе данных диалогов.</param>
        /// <returns>Настройки диалогового окна.</returns>
        /// <example>
        /// Примеры использования:
        /// <code language = "c#">
        ///int dialogueSettingsID = 0;
        ///DialogueSettings primarySettings;
        ///DialogueSettings externalSettings = GetDialogueSettings(dialogueSettingsID);
        ///primarySettings.Text = externalSettings.Text;
        /// </code>
        /// </example>
        public override DialogueSettings GetDialogueSettings(int dialogueID)
        {
            DialogueSettings result = _dialoguesSettings.Find(x => x.ID == dialogueID);
            return result;
        }

        void Awake()
        {
            Init();
        }

        void Init()
        {
            List<XML_DialogueSettings> xmlDialoguesSettings = new List<XML_DialogueSettings>();

            XmlSerializer serializer = new XmlSerializer(typeof(XML_DialoguesCollection));

            StringReader reader = new StringReader(_xmlFile.text);

            xmlDialoguesSettings.AddRange((serializer.Deserialize(reader) as XML_DialoguesCollection).Dialogues);

            reader.Close();

            _dialoguesSettings.AddRange(TranslateItems(xmlDialoguesSettings));
        }

        List<DialogueSettings> TranslateItems(List<XML_DialogueSettings> dialoguesSettings)
        {
            List<DialogueSettings> translatedDialogueSettings = new List<DialogueSettings>();

            for (int i = 0; i < dialoguesSettings.Count; i++)
            {
                string text = dialoguesSettings[i].Text;
                int id = dialoguesSettings[i].ID;
                DialogueSettings settings = new DialogueSettings(id, text);

                translatedDialogueSettings.Add(settings);

                translatedDialogueSettings[i].Answers.AddRange(TranslateAnswers(dialoguesSettings[i].Answers));
            }
            return translatedDialogueSettings;
        }

        List<AnswerSettings> TranslateAnswers(List<XML_AnswerSettings> answersSettings)
        {
            List<AnswerSettings> translatedAnswerSettings = new List<AnswerSettings>();
            for (int j = 0; j < answersSettings.Count; j++)
            {
                string text = answersSettings[j].Text;
                AnswerSettings answerSettings = new AnswerSettings(text);

                translatedAnswerSettings.Add(answerSettings);
            }
            return translatedAnswerSettings;
        }
    }
}