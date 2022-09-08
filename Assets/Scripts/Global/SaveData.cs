using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global
{
    public class SaveData : MonoBehaviour
    {
        public int coin;
        public string[] unlockedPack;
        public string[] completedPack;
        public List <string> completedLevel = new List<string>();
        public string[] allPack;

        public static SaveData saveInstance;
        
        private const string _prefsKey = "TriviaProgress";
        
        private void Awake()
        {
            if (saveInstance == null)
            {
                saveInstance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
            Load();
        }

        private void OnEnable()
        {
            EventManager.StartListening("FinishLevel", UpdateLevel);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", UpdateLevel);
        }

        private void UpdateLevel(object data)
        {
            string level = (string)data;
            completedLevel.Add(level);
            Save();
        }

        public void Load()
        {
            if(PlayerPrefs.HasKey(_prefsKey))
            {
                string json = PlayerPrefs.GetString(_prefsKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                Save();
            }
        }
        
        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_prefsKey, json);
            Debug.Log(json);
        }
    }
}

