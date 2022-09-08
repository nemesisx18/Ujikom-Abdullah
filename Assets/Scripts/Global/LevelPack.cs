using UnityEngine;

namespace TriviaGame.Global.Data
{
    [CreateAssetMenu]
    public class LevelPack : ScriptableObject
    {
        [SerializeField] private string _packId;
        [SerializeField] private LevelListData[] _levelLists;
        [SerializeField] private bool _isCompleted;
        [SerializeField] private bool _isUnlocked;
        [SerializeField] private int _unlockCost;
        
        public string PackId => _packId;
        public LevelListData[] LevelLists => _levelLists;
    }
}
