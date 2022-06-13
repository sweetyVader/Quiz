using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _startButton.onClick.AddListener(StartButtonClicked);
    }

    #endregion


    #region Private metods

    private void StartButtonClicked()
    {
        SceneLoader.Instance.LoadScene("GameScene");
    }

    #endregion
}