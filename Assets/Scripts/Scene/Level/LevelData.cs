using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TriviaGame.Global;
using TriviaGame.Global.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Scene.Level
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelNameLabel;
        [SerializeField] private Image _completedImage;
        [SerializeField] private Button _selectButton;
        [SerializeField] private string _levelID;
        [SerializeField] private string _levelName;
        [SerializeField] private bool _isCompleted;
        private SaveData _saveData;
        private Database _database;

        [SerializeField] private LevelScene _levelScene;

        private void Awake()
        {
            _saveData = SaveData.saveInstance; 
            _database = Database.databaseInstance;
        }

        private void Start()
        {
            SetSelectButtonListener();
        }

        public void Init(LevelScene ls)
        {
            _levelScene = ls;
        }

        public void SetSelectButtonListener()
        {
            _selectButton.onClick.AddListener(LoadPackList);
        }
        
        public void SetLevelName(int index)
        {
            Debug.Log(Database.databaseInstance.Levels[index]);
            _levelName = _database.Levels[index];
            _levelNameLabel.text = "Level " + _levelName;
            InitLevelList();
        }
        
        public void InitLevelList()
        {
            _levelID = _database.levelStruct.LevelPackID;
            if (_saveData.completedLevel.Contains(_levelName))
            {
                _isCompleted = true;
            }
            _completedImage.gameObject.SetActive(_isCompleted);            
        }
        
        public void LoadPackList()
        {
            _database.GetLevelData(_levelName);
            _levelScene.SelectLevel();
        }
    }
}

