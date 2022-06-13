using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(StartButtonClicked);
    }

    private void StartButtonClicked()
    {
        SceneLoader.Instance.LoadScene("GameScene");
    }
}