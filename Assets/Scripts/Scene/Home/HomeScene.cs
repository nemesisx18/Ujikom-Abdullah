using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void Start()
        {
            SetStartButtonListener();
        }
        
        private void SetStartButtonListener()
        {
            _startButton.onClick.AddListener(StartPlay);
        }

        public void StartPlay()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}

