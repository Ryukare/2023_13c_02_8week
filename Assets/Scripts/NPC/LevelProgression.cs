using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    private int _goldCoinsRequired;
    [SerializeField] private string _nextLevel;
    private bool _canProgress;

    private void Start()
    {
        _canProgress = false;
        _goldCoinsRequired = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action") && _canProgress)
        {
            SceneManager.LoadScene(_nextLevel);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (collision.GetComponent<PlayerScore>().goldCoinAmount == _goldCoinsRequired)
            {
                _canProgress = true;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            _canProgress = false;
        }
    }
}
