using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global
{
    public class Analytic : MonoBehaviour
    {
        public static Analytic Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            EventManager.StartListening("FinishLevel", TrackFinishLevel);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", TrackFinishLevel);
        }
        
        private void TrackFinishLevel(object data)
        {
            string level = (string)data;
            Debug.Log($"Level {level} is Finished");
        }
    }
}

