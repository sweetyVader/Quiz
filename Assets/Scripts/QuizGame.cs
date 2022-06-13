using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    #region Variables

    [Header("Button answers")]
    [SerializeField] private Button _firstAnswerButton;
    [SerializeField] private Button _secondAnswerButton;
    [SerializeField] private Button _thirdAnswerButton;
    [SerializeField] private Button _fourthAnswerButton;

    [Header("Text answers")]
    [SerializeField] private TextMeshProUGUI _firstAnswerLabel;
    [SerializeField] private TextMeshProUGUI _secondAnswerLabel;
    [SerializeField] private TextMeshProUGUI _thirdAnswerLabel;
    [SerializeField] private TextMeshProUGUI _fourthAnswerLabel;

    [Header(" ")]
    [SerializeField] private TextMeshProUGUI _lifeLabel;

    [Header("Image question")]
    [SerializeField] private Image _questionImage;

    [Header("List questions")]
    [SerializeField] private Question[] _allQuestions;

    [Header("Helper")]
    [SerializeField] private Button _helpButton;

    private int _choiceIndex;
    private int _life = 3;
    private int _maxQuestions;
    private int _idButton;

    private readonly List<Button> _buttons = new List<Button>();

    private Timer _timer;

    #endregion


    #region Properties

    public static int Right { get; private set; }
    public static int Wrong { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _firstAnswerButton.onClick.AddListener(delegate { CheckAnswer(1); });
        _secondAnswerButton.onClick.AddListener(delegate { CheckAnswer(2); });
        _thirdAnswerButton.onClick.AddListener(delegate { CheckAnswer(3); });
        _fourthAnswerButton.onClick.AddListener(delegate { CheckAnswer(4); });
        _helpButton.onClick.AddListener(HelperButton);
    }

    private void Start()
    {
        MixQuestions();

        _maxQuestions = _allQuestions.Length;
        Right = 0;
        Wrong = 0;

        SetQuestion(_allQuestions[_choiceIndex]);

        _buttons.Add(_firstAnswerButton);
        _buttons.Add(_secondAnswerButton);
        _buttons.Add(_thirdAnswerButton);
        _buttons.Add(_fourthAnswerButton);
    }

    private void Update()
    {
        _lifeLabel.text = _life.ToString();
        CheckGameOver();
    }

    #endregion


    #region Private metods

    private void SetQuestion(Question question)
    {
        _firstAnswerLabel.text = question.FirstAnswerText;
        _secondAnswerLabel.text = question.SecondAnswerText;
        _thirdAnswerLabel.text = question.ThirdAnswerText;
        _fourthAnswerLabel.text = question.FourthAnswerText;
        _questionImage.sprite = question.AksQuestionImage;
    }

    private void CheckAnswer(int answer)
    {
        if (answer == _allQuestions[_choiceIndex].SetRightAnswer)
        {
            Right++;
            _buttons[answer - 1].image.color = Color.green;
        }
        else
        {
            Wrong++;
            _life--;
            _buttons[answer - 1].image.color = Color.red;
            _buttons[_allQuestions[_choiceIndex].SetRightAnswer - 1].image.color = Color.green;
        }

        _choiceIndex++;

        if (_choiceIndex < _maxQuestions)
        {
            EnableButton();
            Invoke(nameof(ResetButton), 2f);
            //_timer.StartTimer(2.5f, ResetButton);
        }
        else
            SceneLoader.Instance.LoadScene("EndScene");
    }

    private void CheckGameOver()
    {
        if (Wrong < 3)
            return;
        SceneLoader.Instance.LoadScene("EndScene");
    }

    private void MixQuestions()
    {
        System.Random random = new System.Random();
        for (int i = _allQuestions.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            (_allQuestions[j], _allQuestions[i]) = (_allQuestions[i], _allQuestions[j]);
        }
    }

    private void HelperButton()
    {
        int q = 0;
        for (int i = 0; i < _buttons.Count & q < 2; i++)
        {
            if (i + 1 == _allQuestions[_choiceIndex].SetRightAnswer)
                continue;
            _buttons[i].gameObject.SetActive(false);
            q++;
        }
    }

    private void ResetButton()
    {
        foreach (var i in _buttons)
        {
            i.image.color = Color.white;
            i.gameObject.SetActive(true);
            i.enabled = true;
        }

        _helpButton.enabled = true;
        SetQuestion(_allQuestions[_choiceIndex]);
    }

    private void EnableButton()
    {
        foreach (var i in _buttons)
        {
            i.enabled = false;
        }

        _helpButton.enabled = false;
    }

    #endregion
}