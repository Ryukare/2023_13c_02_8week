using TMPro;
using UnityEngine;

namespace UI {
    public class HUDManager : MonoBehaviour {
        [SerializeField] private TMP_Text _playerHealth;
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private TMP_Text _silverCoinsAmount;
        [SerializeField] private TMP_Text _goldCoinsAmount;
        [SerializeField] private TMP_Text _diamondsAmount;

        private void Awake() {
            PlayerEventSystem.OnPlayerHealthUpdate += UpdatePlayerHealth;
            //GameEventSystem.onIncreaseScoreUpdate += UpdatePlayerScore;
            //GameEventSystem.onIncreaseCoinsUpdate += UpdateCoinsAmount;
            //GameEventSystem.onIncreaseDiamondsUpdate += UpdateDiamondsAmount;
        }

        private void OnDestroy() {
            PlayerEventSystem.OnPlayerHealthUpdate -= UpdatePlayerHealth;
            //GameEventSystem.onIncreaseScoreUpdate -= UpdatePlayerScore;
            //GameEventSystem.onIncreaseCoinsUpdate -= UpdateCoinsAmount;
            //GameEventSystem.onIncreaseDiamondsUpdate -= UpdateDiamondsAmount;
        }

        private void UpdatePlayerHealth(int currentHealth) {
            _playerHealth.text = $"Health: {currentHealth}";
        }
        private void UpdatePlayerScore(int currentScore)
        {
            _playerScore.text = $"Score: {currentScore}";
        }
        private void UpdateSilverCoinsAmount(int currentCoins)
        {
            _silverCoinsAmount.text = $"Coins: {currentCoins}";
        }
        private void UpdateGoldCoinsAmount(int currentCoins)
        {
            _goldCoinsAmount.text = $"Coins: {currentCoins}";
        }
        private void UpdateDiamondsAmount(int currentDiamonds)
        {
            _diamondsAmount.text = $"Diamonds: {currentDiamonds}";
        }
    }
}