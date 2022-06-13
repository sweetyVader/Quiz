using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _menuButton;
    [SerializeField] private string _loadSceneName;
    public TextMeshProUGUI RightLabel;
    public TextMeshProUGUI WrongLabel;
    public AnswerManager AnswerManager;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _menuButton.onClick.AddListener(MenuButtonClicked);
    }

    private void Start()
    {
        AnswerManager = FindObjectOfType<AnswerManager>();
    }

    private void Update()
    {
        RightLabel.text = AnswerManager.RightAnswers.ToString();
        WrongLabel.text = AnswerManager.WrongAnswers.ToString();
    }

    #endregion


    #region Private metods

    private static void MenuButtonClicked()
    {
        SceneLoader.Instance.LoadScene("StartScene");
    }

    #endregion
}