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
            EventManager.StartListening("UnlockPack", TrackUnlockPack);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", TrackFinishLevel);
            EventManager.StopListening("UnlockPack", TrackUnlockPack);
        }
        
        private void TrackFinishLevel(object data)
        {
            string level = (string)data;
            Debug.Log($"Level {level} is Finished");
        }
        
        private void TrackUnlockPack(object data)
        {
            string pack = (string)data;
            Debug.Log($"Pack {pack} is Unlocked");
        }
    }
}

