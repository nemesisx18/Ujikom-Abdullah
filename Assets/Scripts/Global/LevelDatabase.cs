using UnityEngine;

namespace TriviaGame.Global.Data
{
    [CreateAssetMenu]
    public class LevelDatabase : ScriptableObject
    {
        public string levelID;
        public string packID;
        public string question;
        public string hint;
        public string[] choice;
        public int answer;
    }
}