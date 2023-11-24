#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _startView;
    [SerializeField] private GameObject _levelView;
    [SerializeField] private GameObject _scoreView;

    [SerializeField] private TMP_InputField playerNameInput;

    private void Awake()
    {
        _mainView.SetActive(true);
        _startView.SetActive(false);
        _scoreView.SetActive(false);
        _levelView.SetActive(false);
    }
    #region Main view
    public void StartClicked()
    {
        _mainView.SetActive(false);
        _startView.SetActive(true);
    }

    public void ExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    #endregion

    #region HighScore view
    public void HighScoreClicked()
    {
        _mainView.SetActive(false);
        _scoreView.SetActive(true);
    }
    #endregion

    #region Start view
    public void StartGameClicked()
    {
        string playerName = playerNameInput.text;
        Debug.Log("Player Name: " + playerName);

        _startView.SetActive(false);
        _levelView.SetActive(true);
    }
    public void BackToMainClicked()
    {
        _mainView.SetActive(true);
        _startView.SetActive(false);
        _scoreView.SetActive(false);
    }
    #endregion

    #region Level view
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BacktoStartClicked()
    {
        _startView.SetActive(true);
        _levelView.SetActive(false);
    }
    #endregion
}