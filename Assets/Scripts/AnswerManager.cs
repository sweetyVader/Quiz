using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    #region Variables

    public int RightAnswers;
    public int WrongAnswers;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        RightAnswers = QuizGame.Right;
        WrongAnswers = QuizGame.Wrong;
    }

    #endregion
}