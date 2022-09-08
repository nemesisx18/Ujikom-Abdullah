using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global
{
    [CreateAssetMenu]
    public class LevelListData : ScriptableObject
    {
        public string levelID;
        public string question;
        public Sprite hint;
        public string[] choice;
        public int answer;
    }
}

