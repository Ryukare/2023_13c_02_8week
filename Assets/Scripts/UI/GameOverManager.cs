#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _healthView;
    [SerializeField] private GameObject _scoreGroupView;
    [SerializeField] private GameObject _gameoverView;
/*    [SerializeField] private TMP_Text _score;*/

    private void Awake()
    {
        _healthView.SetActive(true);
        _scoreGroupView.SetActive(true);
        _gameoverView.SetActive(false);
/*        ScoreEventSystem.OnScoreUpdate += UpdateScore;*/
    }
/*    private void OnDestroy()
    {
        ScoreEventSystem.OnScoreUpdate -= UpdateScore;
    }
    private void UpdateScore(int currentScore)
    {
        _score.text = $"Score: {currentScore}";
    }*/
    public void ShowGameOverView()
    {
        _healthView.SetActive(false);
        _scoreGroupView.SetActive(false);
        _gameoverView.SetActive(true);
    }
    public void ResetClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void MainMenuClicked(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
