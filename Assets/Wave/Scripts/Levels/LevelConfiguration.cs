namespace Wave.Levels
{
    using System;

    using UnityEngine;

    [Serializable]
    public class LevelConfiguration
    {
        /// <summary>
        ///   Duration of level (in s).
        /// </summary>
        [Tooltip("Duration of level (in s)")]
        [Range(1, 120)]
        public float Duration = 10.0f;

        /// <summary>
        ///   Maximum duration with little wave activity before level is lost (in s).
        /// </summary>
        [Tooltip("Maximum duration with little wave activity before level is lost (in s)")]
        [Range(0, 120)]
        public float MaxLittleWaveDuration = 3.0f;

        /// <summary>
        ///   Id of the next level to start after this one was won.
        /// </summary>
        [Tooltip("Id of the next level to start after this one was won")]
        public GameStates NextLevelId;

        /// <summary>
        ///   Threshold for waving ratio.
        /// </summary>
        [Tooltip("Threshold for waving ratio")]
        [Range(0, 1)]
        public float WaveThreshold = 0.25f;
    }
}