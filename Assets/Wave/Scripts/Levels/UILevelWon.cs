namespace Wave.Levels
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

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
                var score = statsSystem.AvaragePoints;
                scoreText.text = string.Format("Score: {0} %", Mathf.RoundToInt(score * 100));
                newspapers[Random.Range(0, newspapers.Count)].Init(true, score);
            }
        }

        public void GoToNextLevel()
        {
            this.levelSystem.StartNextLevel();
        }
    }
}