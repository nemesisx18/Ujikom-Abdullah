using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global
{
    public class Currency : MonoBehaviour
    {
        public static Currency currencyInstance;

        public int coin;
        private SaveData _saveData;

        private void Awake()
        {
            if(currencyInstance != null && currencyInstance != this)
            {
                Destroy(this);
            }
            else
            {
                currencyInstance = this;
                DontDestroyOnLoad(this);
            }
        }

        private void Start()
        {
            _saveData = SaveData.saveInstance;
            GetCoin();
        }

        private void GetCoin()
        {
            coin = _saveData.coin;
            Debug.Log(coin);
        }

        public void AddCoin(int amount)
        {
            coin += amount;
            _saveData.UpdateCoin(coin);
        }

        public void SpendCoin(int amount)
        {
            coin -= amount;
            _saveData.UpdateCoin(coin);
        }
    }
}
