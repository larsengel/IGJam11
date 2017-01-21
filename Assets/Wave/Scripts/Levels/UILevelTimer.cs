namespace Wave.Levels
{
    using System;

    using UnityEngine;
    using UnityEngine.UI;

    public class UILevelTimer : MonoBehaviour
    {
        public Text Text;

        public VictorySystem VictorySystem;

        private void Start()
        {
            this.VictorySystem = FindObjectOfType<VictorySystem>();
        }

        private void Update()
        {
            if (this.VictorySystem == null)
            {
                return;
            }

            var remainingDuration = this.VictorySystem.RemainingDuration;
            this.Text.text = string.Format(
                "{0:00}:{1:00}",
                (int)Math.Floor(remainingDuration / 60),
                (int)Math.Ceiling(remainingDuration % 60));
        }
    }
}