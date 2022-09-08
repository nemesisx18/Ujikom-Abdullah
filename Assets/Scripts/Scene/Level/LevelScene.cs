using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Level
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Start()
        {
            SetBackButtonListener();
        }

        private void SetBackButtonListener()
        {
            _backButton.onClick.AddListener(GoBack);
        }
        public void GoBack()
        {
            SceneManager.LoadScene("Pack");
        }

        public void SelectLevel()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}

