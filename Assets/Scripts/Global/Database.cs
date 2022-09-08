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
        public static Database databaseInstance;
        private LevelStruct _levelStruct;
        [SerializeField] private LevelPack _levelPack;
        [SerializeField] private string _packID;
        
        public LevelPack LevelPack => _levelPack;
        public string PackID => _packID;
        
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
        }

        public void GetPackList(string packID)
        {
            _packID = packID; 
            _levelPack = Resources.Load<LevelPack>("Pack/" + packID);
        }

        public void GetLevelList(string packID)
        {
            _levelStruct.LevelPackID = packID;
        }
        
        public void GetLevelData(string levelID)
        {
            _levelStruct.LevelID = levelID;
        }
    }
}


