using System.Collections;
using System.Collections.Generic;
using TMPro;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Scene.Level
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private Button[] _selectButton;
        
        [SerializeField] private string[] _levelID;
        [SerializeField] private string _levelName;
        [SerializeField] private bool _isCompleted;
        private SaveData _saveData;
        private Database _database;

        [SerializeField] private LevelScene _levelScene;

        private void Start()
        {
            _saveData = SaveData.saveInstance; 
            _database = Database.databaseInstance;
            _levelName = _database.PackID;
            _levelID = new string[_database.LevelPack.LevelLists.Length];
            
            for (int i = 0; i < _selectButton.Length; i++)
            {
                _selectButton[i].GetComponentInChildren<TextMeshProUGUI>().text = _database.LevelPack.LevelLists[i].name;
            }
            
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
            _database.GetLevelData(_levelID[index]);
            _levelScene.SelectLevel();
        }
    }
}

