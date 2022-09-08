using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Pack
{
    public class PackScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _coinText;
        
        private void Start()
        {   
            SetBackButtonListener();
        }

        private void Update()
        {
            //set coin text from currency coin data
            _coinText.text = Currency.currencyInstance.coin.ToString();
        }

        private void SetBackButtonListener()
        {
            _backButton.onClick.AddListener(GoBack);
        }

        public void GoBack()
        {
            SceneManager.LoadScene("Home");
        }

        public void SelectPack()
        {
            SceneManager.LoadScene("Level");
        }
    }
}

