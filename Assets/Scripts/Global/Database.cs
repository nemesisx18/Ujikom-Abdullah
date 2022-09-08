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
    }
}


