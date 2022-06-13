using UnityEngine;

[CreateAssetMenu(fileName = "Question1", menuName = "Configs/Questions")]
public class Question : ScriptableObject
{
    #region Variables

    [SerializeField] private Sprite _aksQuestionImage;

    [Header("Answers")]
    [SerializeField] private string _firstAnswerText;
    [SerializeField] private string _secondAnswerText;
    [SerializeField] private string _thirdAnswerText;
    [SerializeField] private string _fourthAnswerText;

    [SerializeField] internal int _rightAnswer;

    #endregion


    #region Properties

    public string FirstAnswerText =>
        _firstAnswerText;
    public string SecondAnswerText =>
        _secondAnswerText;
    public string ThirdAnswerText =>
        _thirdAnswerText;
    public string FourthAnswerText =>
        _fourthAnswerText;
    public Sprite AksQuestionImage =>
        _aksQuestionImage;
    public int SetRightAnswer =>
        _rightAnswer;

    #endregion
}