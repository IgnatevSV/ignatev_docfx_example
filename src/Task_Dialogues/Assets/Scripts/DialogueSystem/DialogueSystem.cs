using System.Collections.Generic;
using UnityEngine;
using DialogueSystemScripts.Models;

namespace DialogueSystemScripts
{
    /// <summary>
    /// Класс, управляющий диалоговыми окнами.
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        enum DataInputType { Direct, External };
        [SerializeField]
        DataInputType _dataInputType;

        [SerializeField]
        DialoguesDatabase _database;

        [SerializeField]
        CanvasGroup _mainCanvasGroup;

        [SerializeField]
        RectTransform _dialogueSpawnPoint;

        [SerializeField]
        Dialogue _dialogueMainPrefab;

        [SerializeField]
        Answer _answerMainPrefab;

        [SerializeField]
        List<DialogueSettings> _dialoguesSettings;

        [SerializeField]
        Vector3 _dialoguePositionOffset;

        Vector3 _dialoguePositionCurrentOffset;

        [SerializeField]
        Vector3 _dialogueAngleOffset;

        Vector3 _dialogueAngleCurrentOffset;

        Stack<Dialogue> _dialogues = new Stack<Dialogue>();

        /// <summary>
        /// Метод, открывающий новое окно диалога.
        /// </summary>
        /// <param name="dialogueID">Идентификатор диалога, который необходимо открыть.</param>
        /// <remarks>
        /// При открытии нового окна диалога предыдущее окно не закрывается!
        /// </remarks>
        public void OpenNewDialogue(int dialogueID)
        {
            if (dialogueID < _dialoguesSettings.Count)
            {
                Dialogue dialogue = CreateDialogue(_dialoguesSettings[dialogueID]);
                InitDialogueAnswers(_dialoguesSettings[dialogueID].Answers, dialogue);

                SetCurrentDialogueVisibility(false);
                _dialogues.Push(dialogue);
                SetCurrentDialogueVisibility(true);

                CheckForControllsBlock();

                IncreaseOffset();
            }
        }

        /// <summary>
        /// Метод, закрывающий текущее активное окно диалога.
        /// </summary>
        public void CloseCurrentDialogue()
        {
            Destroy(_dialogues.Pop().MainWindow);
            SetCurrentDialogueVisibility(true);

            CheckForControllsBlock();

            DecreaseOffset();
        }

        /// <summary>
        /// Метод, закрывающий все текущие открытые окна диалогов.
        /// </summary>
        public void CloseAllDialogues()
        {
            while (_dialogues.Count > 0)
            {
                CloseCurrentDialogue();
            }
        }

        /// <summary>
        /// Метод для получения настроек диалога.
        /// </summary>
        /// <param name="dialogueID">Идентификатор диалога. ID диалога в базе данных диалогов.</param>
        /// <returns>Настройки диалогового окна.</returns>
        /// <example>
        /// Примеры использования:
        /// <code language = "c#">
        /// _dialogueSystem.GetDialogueSettings(_dialogueID).Answers[_answerID].IsActive = true;
        /// </code>
        /// </example>
        public DialogueSettings GetDialogueSettings(int dialogueID)
        {
            return _dialoguesSettings.Find(x => x.ID == dialogueID);
        }

        void Start()
        {
            SubEvents();

            InitMainCanvasGroup();
            InitDefaultRespawnPoint();

            InitDatabase();
            InitDialoguesSettings();
        }

        void SubEvents()
        {
            Dialogue.OnDialogueClose += CloseCurrentDialogue;
        }

        void UnsubEvents()
        {
            Dialogue.OnDialogueClose -= CloseCurrentDialogue;
        }

        void OnDestroy()
        {
            UnsubEvents();
        }

        void InitDialoguesSettings()
        {
            switch (_dataInputType)
            {
                case DataInputType.External: ApplyExternalData(); break;
                default: Debug.Log("Direct inputed data in use!"); break;
            }
        }

        void InitMainCanvasGroup()
        {
            _mainCanvasGroup = FindObjectOfType<CanvasGroup>();
            _mainCanvasGroup.blocksRaycasts = true;
        }

        void InitDefaultRespawnPoint()
        {
            if (_dialogueSpawnPoint == null)
            {
                _dialogueSpawnPoint = (RectTransform)_mainCanvasGroup.transform;
            }
        }

        void InitDatabase()
        {
            _database = FindObjectOfType<DialoguesDatabase>();
        }

        void InitDialogueAnswers(List<AnswerSettings> answers, Dialogue dialogue)
        {
            for (int j = 0; j < answers.Count; j++)
            {
                CreateAnswer(answers[j], dialogue.AnswersGroup.transform);
            }
        }

        void ApplyExternalData()
        {
            for (int i = 0; i < _dialoguesSettings.Count; i++)
            {
                int dialogueSettingsID = _dialoguesSettings[i].ID;
                DialogueSettings externalSettings = _database.GetDialogueSettings(dialogueSettingsID);
                _dialoguesSettings[i].Text = externalSettings.Text;

                for (int j = 0; j < externalSettings.Answers.Count; j++)
                {
                    _dialoguesSettings[i].Answers[j].Text = externalSettings.Answers[j].Text;
                }
            }
        }

        void SetCurrentDialogueVisibility(bool value)
        {
            if (_dialogues.Count > 0)
            {
                _dialogues.Peek().IsDialogueActive = value;

                MoveDialogueByActivity(value);
                RotateDialogueByActivity(value);
            }
        }

        void MoveDialogueByActivity(bool value)
        {
            if (value)
            {
                _dialogues.Peek().ResetTransformValues();
            }
            else
            {
                _dialogues.Peek().transform.localPosition += _dialoguePositionCurrentOffset;
            }
        }

        void RotateDialogueByActivity(bool value)
        {
            if (value)
            {
                _dialogues.Peek().ResetTransformValues();
            }
            else
            {
                _dialogues.Peek().transform.localEulerAngles += _dialogueAngleCurrentOffset;
            }
        }

        Dialogue CreateDialogue(DialogueSettings settings)
        {
            Dialogue dialogue;

            if (settings.DialoguePrefab != null)
            {
                dialogue = Instantiate(settings.DialoguePrefab, _dialogueSpawnPoint, false);
            }
            else
            {
                dialogue = Instantiate(_dialogueMainPrefab, _dialogueSpawnPoint, false);
            }
            dialogue.InitDialogue(settings);

            return dialogue;
        }

        void CreateAnswer(AnswerSettings settings, Transform answersGroup)
        {
            Answer answer = null;

            if (settings.AnswerPrefab != null)
            {
                answer = Instantiate(settings.AnswerPrefab, answersGroup);
            }
            else
            {
                answer = Instantiate(_answerMainPrefab, answersGroup);
            }

            answer.InitAnswer(settings);
        }

        void IncreaseOffset()
        {
            _dialoguePositionCurrentOffset += _dialoguePositionOffset;
            _dialogueAngleCurrentOffset += _dialogueAngleOffset;
        }

        void DecreaseOffset()
        {
            _dialoguePositionCurrentOffset -= _dialoguePositionOffset;
            _dialogueAngleCurrentOffset -= _dialogueAngleOffset;
        }

        void ResetOffset()
        {
            _dialoguePositionCurrentOffset = new Vector3();
            _dialogueAngleCurrentOffset = new Vector3();
        }

        void CheckForControllsBlock()
        {
            _mainCanvasGroup.interactable = !(_dialogues.Count > 0);
        }
    }
}