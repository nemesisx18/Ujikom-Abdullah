using System;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Scene.Gameplay
{
    public class GameFlow : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.StartListening("TimeUp", SetGameOverState);
        }

        private void OnDisable()
        {
            EventManager.StopListening("TimeUp", SetGameOverState);
        }

        public void SetGameOverState()
        {
            SceneManager.LoadScene("Level");
        }
    }
}

