using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Scene.Pack
{
    public class PackData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _packNameLabel;
        [SerializeField] private TextMeshProUGUI _unlockCostLabel;
        [SerializeField] private PackScene _packScene;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _unlockButton;
        [SerializeField] private string PackID;
        [SerializeField] private string PackName;
        [SerializeField] private bool isCompleted;
        [SerializeField] private bool isUnlocked = false;
        [SerializeField] private int UnlockCost;
        
        private Database _database;
        private SaveData _save;

        private void Start()
        {
            _database = Database.databaseInstance;
            _save = SaveData.saveInstance;
            
            _selectButton.onClick.AddListener(LoadPackList);
            
            InitPackList();
        }

        public void InitPackList()
        {
            _packNameLabel.text = PackName;
            _unlockCostLabel.text = "100 Gold";
            
            if (_save.unlockedPack.Contains(PackName))
            {
                isUnlocked = true;
                if (isUnlocked)
                {
                    _unlockButton.gameObject.SetActive(false);
                }
            }
        }
        
        public void LoadPackList()
        {
            _database.GetLevelList(PackID);
            _packScene.SelectPack();
        }

        public void GetPackList()
        {
            
        }
    }
}
