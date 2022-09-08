using System;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.Global.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Level
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private LevelData _levelPrefab;
        [SerializeField] private Transform _levelContainer;

        private void Start()
        {
            SetBackButtonListener();
            Database.databaseInstance.SetLevel();
            InitButton();
        }

        private void InitButton()
        {
            for (int i = 0; i < 5; i++)
            {
                LevelData tmp = Instantiate(_levelPrefab, _levelContainer);
                int index = i;
                tmp.Init(this);
                tmp.SetLevelName(index);
            }
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

