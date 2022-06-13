using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public string StartScene;

    private void Start()
    {
        SceneLoader.Instance.LoadScene(StartScene);
    }
}