using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
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

    [SerializeField] private TextMeshProUGUI _lifeLabel;

    [SerializeField] private Image _questionImage;

    [SerializeField] private Question[] _allQuestions;
    [SerializeField] private Button _helpButton;

    private int _choiceIndex;
    private int _life = 3;
    private bool _isEnd = false;
    private int _maxQuestions;

   // private int _button;
    private int _idButton;
  private readonly List<Button> _buttons = new List<Button>();

  public Timer _timer;
     
    private void Start()
    {
        Mix();
        _maxQuestions = _allQuestions.Length;

        Right = 0;
        Wrong = 0;
        SetQuestion(_allQuestions[_choiceIndex]);
        
        
      _buttons.Add(_firstAnswerButton);
      _buttons.Add(_secondAnswerButton);
      _buttons.Add(_thirdAnswerButton);
      _buttons.Add(_fourthAnswerButton);
     
      _firstAnswerButton.onClick.AddListener(delegate { CheckAnswer(1); });
      _secondAnswerButton.onClick.AddListener(delegate { CheckAnswer(2); });
      _thirdAnswerButton.onClick.AddListener(delegate { CheckAnswer(3); });
      _fourthAnswerButton.onClick.AddListener(delegate { CheckAnswer(4); });
      _helpButton.onClick.AddListener(HelperButton);
      
      
    }

    private void SetQuestion(Question question)
    {
        
       // Thread.Sleep(2000);
    /*   foreach (var i in buttons)
        {
            i.image.color = Color.white;
        }*/
    
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
        }


        _choiceIndex++;

        if (_choiceIndex < _maxQuestions)


        {
            
           // _timer.StartTimer(2.5f, ResetButton);
            SetQuestion(_allQuestions[_choiceIndex]);
        }
    else

    SceneLoader.Instance.LoadScene("EndScene");
    }

    private void Update()
    {
        if (_isEnd)
            return;
        
       

        _lifeLabel.text = _life.ToString();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (Wrong < 3)
            return;
        SceneLoader.Instance.LoadScene("EndScene");
        _isEnd = true;
    }

    private bool IsIndexValid(int choiceIndex) =>
        choiceIndex >= 0;

    public static int Right { get; private set; }
    public static int Wrong { get; private set; }

    private void Mix()
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
            if (i+1 == _allQuestions[_choiceIndex].SetRightAnswer)
                continue;
            _buttons[i].enabled = false;
            _buttons[i].image.color = Color.black;
            q++;
        }
    }

    private void ResetButton()
    {
        foreach (var i in _buttons)
        {
            i.image.color = Color.white;
            i.enabled = true;
        }
    }
    
}