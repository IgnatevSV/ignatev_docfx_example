using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DialogueSystemScripts.Models
{
    /// <summary>
    /// Класс настроек диалога из XML.
    /// </summary>
    [System.Serializable]
    public class XML_DialogueSettings
    {
        /// <summary>
        /// Идентификатор диалога. ID диалога в базе данных диалогов.
        /// </summary>
        [XmlAttribute("id")]
        public int ID
        {
            private set;
            get;
        }

        /// <summary>
        /// Текст диалога.
        /// </summary>
        [XmlElement("text")]
        public string Text
        {
            private set;
            get;
        }

        /// <summary>
        /// Коллекция настроек ответов.
        /// </summary>
        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public List<XML_AnswerSettings> Answers
        {
            private set;
            get;
        }
    }
}