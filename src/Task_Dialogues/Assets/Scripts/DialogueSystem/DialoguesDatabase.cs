using UnityEngine;
using DialogueSystemScripts.Models;

namespace DialogueSystemScripts
{
    /// <summary>
    /// Абстрактный класс для работы с базой данных диалогов.
    /// </summary>
    public abstract class DialoguesDatabase : MonoBehaviour
    {
        /// <summary>
        /// Абстрактный метод для получения настроек диалогового окна из базы данных по идентификатору диалога.
        /// </summary>
        /// <param name="dialogueID">Идентификатор диалога. ID диалога в базе данных диалогов.</param>
        /// <returns>Настройки диалогового окна.</returns>
        public abstract DialogueSettings GetDialogueSettings(int dialogueID);
    }
}