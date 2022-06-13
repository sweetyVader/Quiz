using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public int RightAnswers;
    public int WrongAnswers;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        RightAnswers = QuizGame.Right;
        WrongAnswers = QuizGame.Wrong;
    }
}