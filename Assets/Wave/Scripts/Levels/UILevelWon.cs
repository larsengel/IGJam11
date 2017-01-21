using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wave.Levels
{
    public class UILevelWon : MonoBehaviour
    {
        public Text scoreText;
        public List<NewsPaper> newspapers;
        private LevelSystem levelSystem;
        private StatsSystem statsSystem;


        private void Start()
        {
            levelSystem = FindObjectOfType<LevelSystem>();
            statsSystem = FindObjectOfType<StatsSystem>();
            if (statsSystem != null)
            {
                scoreText.text = string.Format("Score: {0} %", Mathf.RoundToInt(statsSystem.AvaragePoints * 100));
            }
            newspapers[Random.Range(0, newspapers.Count)].Init(true);
        }

        public void GoToNextLevel()
        {
            this.levelSystem.StartNextLevel();
        }
    }
}