using System.Collections;
using System.Collections.Generic;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Scene.Pack
{
    public class PackDatas : MonoBehaviour
    {
        [Header("Pack Menu")]
        [SerializeField] private Button[] _selectButton;
        [SerializeField] private Button[] _unlockButton;
        
        [SerializeField] private PackScene _packScene;
        [Header("Pack Data")]
        [SerializeField] private string[] _packID;
        [SerializeField] private string[] _packName;
        private SaveData _saveData;
        private Database _database;

        private void Start()
        {
            _saveData = SaveData.saveInstance; 
            _database = Database.databaseInstance;
            _packName = new string[_saveData.unlockedPack.Count];
            LoadPackList();
            SetSelectButtonListener();
        }

        public void SetSelectButtonListener()
        {
            for (int i = 0; i < _selectButton.Length; i++)
            {
                int tempIndex = i;
                _selectButton[i].onClick.AddListener(() => GetPackList(tempIndex));
            }
        }
        
        public void GetPackList(int index)
        {
            Debug.Log(_packName[index]);
            // _database.GetPackList(_packName[index]);
            _packScene.SelectPack();
        }

        public void LoadPackList()
        {
            for (int i = 0; i < SaveData.saveInstance.unlockedPack.Count; i++)
            {
                _packName[i] = _saveData.unlockedPack[i];
            }
            
        }
    }
}

