using System;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Global.Data
{
    public class Database : MonoBehaviour
    {
        [SerializeField] private LevelPack _levelPack;
        [SerializeField] private string[] levels;
        public static Database databaseInstance;
        private LevelStruct _levelStruct;

        public LevelStruct levelStruct => _levelStruct;
        public LevelPack LevelPack => _levelPack;
        public string[] Levels => levels;
        private void Awake()
        {
            if (databaseInstance == null)
            {
                databaseInstance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _levelStruct = new LevelStruct();
            levels = new string[5];
            
        }

        public void SetLevel()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = _levelStruct.LevelPackID + "-" + (i + 1);
            }
        }

        // public void GetPackList(string packID)
        // {
        //     _packID = packID; 
        //     _levelPack = Resources.Load<LevelPack>("Pack/" + packID);
        // }

        public void GetLevelList(string packID)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = packID + "-" + (i + 1);
            }
            _levelStruct.LevelPackID = packID;
        }
        
        public void GetLevelData(string levelID)
        {
            _levelStruct.LevelID = levelID;
        }
    }
}


