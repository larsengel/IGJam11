using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Wave.Levels
{
    public class StatsSystem : MonoBehaviour
    {
        public DefeatSystem defeatSystem;
        public LevelSystem levelSystem;

        List<float> pointsHistory = new List<float>();
        public float AvaragePoints
        {
            get
            {
                if (pointsHistory.Count == 0) return 0;
                return pointsHistory.Sum() / pointsHistory.Count;
            }
        }

        private void OnEnable()
        {
            levelSystem.LevelStarted += this.OnLevelStarted;
            levelSystem.LevelFinished += this.OnLevelFinished;
        }

        private void OnLevelStarted()
        {
            Debug.Log("OnLevelStarted");
            StartCoroutine(ComputeAvarageRatio());
            pointsHistory = new List<float>();
        }

        private void OnLevelFinished()
        {
            Debug.Log("OnLevelFinished");
            StopAllCoroutines();
        }

        private IEnumerator ComputeAvarageRatio()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                Debug.Log(defeatSystem.WaveRatio + "-> defeatSystem.WaveRatio");
                pointsHistory.Add(defeatSystem.WaveRatio);
            }
        }


    }
}
