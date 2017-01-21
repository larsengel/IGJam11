namespace Wave.Levels
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class UILevelWon : MonoBehaviour
    {
        public Text scoreText;
        private LevelSystem levelSystem;
        private StatsSystem statsSystem;

        private void Start()
        {
            this.levelSystem = FindObjectOfType<LevelSystem>();
            this.statsSystem = FindObjectOfType<StatsSystem>();
            Debug.Log(statsSystem.AvaragePoints + "-> statsSystem.AvaragePoints");
            scoreText.text = string.Format("Score: {0} %", Mathf.RoundToInt(statsSystem.AvaragePoints * 100));
        }

        public void GoToNextLevel()
        {
            this.levelSystem.StartNextLevel();
        }
    }
}