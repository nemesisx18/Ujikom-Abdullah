using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Scene.Gameplay
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private Button[] _answerButton;

        private void Start()
        {
            InitQuiz();
        }

        public void InitQuiz()
        {
            for (int i = 0; i < _answerButton.Length; i++)
            {
                _answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    Database.databaseInstance.LevelPack.LevelLists[0].choice[i];
            }
        }
    }
}

