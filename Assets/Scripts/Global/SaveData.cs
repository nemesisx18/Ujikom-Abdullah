using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global
{
    public class SaveData : MonoBehaviour
    {
        public int coin;
        public List <string> unlockedPack = new List<string>();
        public List <string> completedPack = new List<string>();
        public List <string> completedLevel = new List<string>();
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
            EventManager.StartListening("UnlockPack", UnlockPack);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", UpdateLevel);
            EventManager.StopListening("UnlockPack", UnlockPack);
        }

        private void UpdateLevel(object data)
        {
            string level = (string)data;
            completedLevel.Add(level);
            Save();
        }
        
        private void UnlockPack(object pack)
        {
            string packName = (string)pack;
            if (!unlockedPack.Contains(packName))
            {
                unlockedPack.Add(packName);
            }
            Save();
        }

        public void UpdateCoin(int amount)
        {
            coin = amount;
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

