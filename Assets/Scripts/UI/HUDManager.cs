using TMPro;
using UnityEngine;

namespace UI {
    public class HUDManager : MonoBehaviour {
        [SerializeField] private TMP_Text _playerHealth;
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private TMP_Text _coinsAmount;
        [SerializeField] private TMP_Text _diamondsAmount;

        private void Awake() {
            //GameEventSystem.onPlayerHealthUpdate += UpdatePlayerHealth;
            //GameEventSystem.onIncreaseScoreUpdate += UpdatePlayerScore;
            //GameEventSystem.onIncreaseCoinsUpdate += UpdateCoinsAmount;
            //GameEventSystem.onIncreaseDiamondsUpdate += UpdateDiamondsAmount;
        }

        private void OnDestroy() {
            //GameEventSystem.onPlayerHealthUpdate -= UpdatePlayerHealth;
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
        private void UpdateCoinsAmount(int currentCoins)
        {
            _coinsAmount.text = $"Coins: {currentCoins}";
        }
        private void UpdateDiamondsAmount(int currentDiamonds)
        {
            _diamondsAmount.text = $"Diamonds: {currentDiamonds}";
        }
    }
}