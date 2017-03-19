using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystemScripts.Models
{
    /// <summary>
    /// Класс диалогового окна.
    /// </summary>
    public class Dialogue : MonoBehaviour
    {
        /// <summary>
        /// Делегат диалога.
        /// </summary>
        public delegate void DialogueDelegate();

        /// <summary>
        /// Событие для закрытия диалога из под системы диалогов.
        /// </summary>
        public static event DialogueDelegate OnDialogueClose;

        [SerializeField]
        GameObject _mainWindow;
        /// <summary>
        /// Объект главного окна диалога, с которым будут производиться операции во время работы с диалогами(например, удаление или перемещение окна).
        /// </summary>
        /// <example>
        /// <code language = "c#">
        ///_mainWindow.transform.localPosition = _defaultPosition;
        ///_mainWindow.transform.localEulerAngles = _defaultRotation;
        /// </code>
        /// </example>
        /// <returns>Объект главного окна диалога.</returns>
        public GameObject MainWindow
        {
            get { return _mainWindow; }
        }

        [SerializeField]
        Button _closeWindowButton;

        [SerializeField]
        Image _fader;

        [SerializeField]
        Text _dialogueText;

        [SerializeField]
        VerticalLayoutGroup _answersGroup;
        /// <summary>
        /// Объект группы в которой будут создаваться кнопки ответов.
        /// </summary>
        /// <returns>Объект группы в которой будут создаваться кнопки ответов.</returns>
        public VerticalLayoutGroup AnswersGroup
        {
            get { return _answersGroup; }
        }

        [SerializeField]
        CanvasGroup _canvasGroup;
        /// <summary>
        /// Активно ли окно диалога в данный момент.
        /// </summary>
        /// <returns>Активно ли окно диалога в данный момент.</returns>
        public bool IsDialogueActive
        {
            get
            {
                if (_canvasGroup != null)
                {
                    return _canvasGroup.interactable;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (_canvasGroup != null)
                {
                    _canvasGroup.interactable = value;
                }
                if (_fader != null)
                {
                    _fader.enabled = !value;
                }
            }
        }

        List<Answer> answers;

        Vector3 _defaultPosition;
        Vector3 _defaultRotation;

        /// <summary>
        /// Инициализация окна диалога, применение заданных настроек.
        /// </summary>
        /// <param name="settings">Настройки диалогового окна.</param>
        public void InitDialogue(DialogueSettings settings)
        {
            InitText(settings.Text);
            InitCancelButton(settings.HasExit);
        }

        /// <summary>
        /// Сброс значений текущей позиции и вращения диалогового окна к заданным значениям по умолчанию.
        /// </summary>
        public void ResetTransformValues()
        {
            _mainWindow.transform.localPosition = _defaultPosition;
            _mainWindow.transform.localEulerAngles = _defaultRotation;
        }

        void Start()
        {
            InitDefaultTransformValues();
            InitCanvasGroup();
        }

        void InitCanvasGroup()
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.ignoreParentGroups = true;
            }
        }

        void InitDefaultTransformValues()
        {
            _defaultPosition = _mainWindow.transform.localPosition;
            _defaultRotation = _mainWindow.transform.localEulerAngles;
        }

        void CloseDialogue()
        {
            OnDialogueClose();
        }

        void InitCancelButton(bool isActive)
        {
            _closeWindowButton.gameObject.SetActive(isActive);
            _closeWindowButton.onClick.AddListener(CloseDialogue);
        }

        void InitText(string text)
        {
            _dialogueText.text = text;
        }
    }
}