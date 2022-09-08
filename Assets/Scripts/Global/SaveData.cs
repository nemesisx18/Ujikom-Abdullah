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
        public string[] completedLevel;

        public static SaveData saveInstance;
        
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
        }

        public void Load()
        {
            
        }
        
        public void Save()
        {
            
        }
    }
}

