using TMPro;
using UnityEngine;

namespace UI {
    public class HUDManager : MonoBehaviour {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _silverCoins;
        private int _levelSilverCoinAmount;
        [SerializeField] private TMP_Text _goldCoins;
        private int _levelGoldCoinAmount;
        [SerializeField] private TMP_Text _diamonds;
        private int _levelDiamondAmount;

        private void Awake() {
            ScoreEventSystem.OnScoreUpdate += UpdateScore;
            ScoreEventSystem.OnSilverCoinAmountUpdate += UpdateSilverCoinAmount;
            ScoreEventSystem.OnGoldCoinAmountUpdate += UpdateGoldCoinAmount;
            ScoreEventSystem.OnDiamondAmountUpdate += UpdateDiamondAmount;
        }

        private void Start()
        {
            _levelSilverCoinAmount = GameObject.FindGameObjectsWithTag("SilverCoin").Length;
            _levelGoldCoinAmount = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
            _levelDiamondAmount = GameObject.FindGameObjectsWithTag("Diamond").Length;
        }

        private void OnDestroy() {
            ScoreEventSystem.OnScoreUpdate -= UpdateScore;
            ScoreEventSystem.OnSilverCoinAmountUpdate -= UpdateSilverCoinAmount;
            ScoreEventSystem.OnGoldCoinAmountUpdate -= UpdateGoldCoinAmount;
            ScoreEventSystem.OnDiamondAmountUpdate -= UpdateDiamondAmount;
        }

        private void UpdateScore(int currentScore)
        {
            _score.text = $"Score: {currentScore}";
        }
        private void UpdateSilverCoinAmount(int currentCoins)
        {
            _silverCoins.text = $"{currentCoins}/{_levelSilverCoinAmount}";
        }
        private void UpdateGoldCoinAmount(int currentCoins)
        {
            _goldCoins.text = $"{currentCoins}/{_levelGoldCoinAmount}";
        }
        private void UpdateDiamondAmount(int currentDiamonds)
        {
            _diamonds.text = $"{currentDiamonds}/{_levelDiamondAmount}";
        }
    }
}