using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    #region Variables

    public string StartScene;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        SceneLoader.Instance.LoadScene(StartScene);
    }

    #endregion
}