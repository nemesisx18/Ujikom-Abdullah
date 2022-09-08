using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Scene.Gameplay
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private int currentIndex;
        [SerializeField] private string _currentLevel;
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private LevelDatabase _levelDatabase;
        [SerializeField] private Button[] _answerButton;
        [SerializeField] private Image _hintImage;

        private void Start()
        {
            currentIndex = Database.databaseInstance.CurrentLevel;

            InitQuiz(currentIndex);
            
            SetAnswerButtonListener();
        }

        public void SetAnswerButtonListener()
        {
            //loop answer button
            for (int i = 0; i < _answerButton.Length; i++)
            {
                //set listener
                int tmp = i;
                _answerButton[i].onClick.AddListener(() => TryAnswer(tmp));
            }
        }

        public void InitQuiz(int index)
        {
            _levelDatabase =
                Resources.Load<LevelDatabase>("Level List/"+Database.databaseInstance.Levels[index]);

            _hintImage.sprite = Resources.Load<Sprite>("Hint/" + _levelDatabase.hint);
            _questionText.text = _levelDatabase.question;
            _currentLevel = _levelDatabase.levelID;
            for (int i = 0; i < _answerButton.Length; i++)
            {
                _answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = _levelDatabase.choice[i];
            }
        }

        public void TryAnswer(int buttonIndex)
        {
            if (buttonIndex == _levelDatabase.answer)
            {
                Debug.Log("Correct");
                EventManager.TriggerEvent("FinishLevel", _currentLevel);
                int nextIndex = currentIndex + 1;
                if (nextIndex < Database.databaseInstance.Levels.Length)
                {
                    InitQuiz(currentIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene("Pack");
                }
            }
            else
            {
                SceneManager.LoadScene("Level");
                Debug.Log("Wrong");
            }
        }
    }
}

