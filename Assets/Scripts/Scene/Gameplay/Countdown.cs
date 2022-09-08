using System.Collections;
using System.Collections.Generic;
using TMPro;
using TriviaGame.Global;
using UnityEngine;

namespace TriviaGame.Scene.Gameplay
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countdownText;
        [SerializeField] private float _timer;
        private bool _isCountingDown;
        private bool _isCountdownFinished;
        
        private void Update()
        {
            StartCountdown();
        }
        
        public void StartCountdown()
        {
            _isCountingDown = true;
            _isCountdownFinished = false;
            
            if (_isCountingDown)
            {
                _timer -= Time.deltaTime;
                float seconds = Mathf.FloorToInt(_timer % 60);
                _countdownText.text = string.Format("{0:00}", seconds);
                if (_timer <= 0)
                {
                    _isCountingDown = false;
                    FinishCountdown();
                }
            }
        }

        public void StopCountdown()
        {
            _isCountingDown = false;
            _isCountdownFinished = true;
        }
        
        public void FinishCountdown()
        {
            _isCountdownFinished = true;
            EventManager.TriggerEvent("TimeUp");
        }
    }
}

