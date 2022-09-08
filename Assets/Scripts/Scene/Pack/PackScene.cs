using System.Collections;
using System.Collections.Generic;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Pack
{
    public class PackScene : MonoBehaviour
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
            SceneManager.LoadScene("Home");
        }

        public void SelectPack(string packID)
        {
            // Database.databaseInstance.GetPackData(packID);
            // SceneManager.LoadScene("Level");
        }
    }
}

