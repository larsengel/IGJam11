namespace Wave.Levels
{
    using System;

    using UnityEngine;

    [Serializable]
    public class LevelConfiguration
    {
        /// <summary>
        ///   Number of seated rows.
        /// </summary>
        [Tooltip("Number of seated rows")]
        public int Rows = 2;

        /// <summary>
        ///   Number of seated seats per row.
        /// </summary>
        [Tooltip("Number of seated seats per row")]
        public int SeatsPerRow = 5;

        /// <summary>
        ///   Percentage of empty seats in between.
        /// </summary>
        [Tooltip("Percentage of empty seats in between")]
        [Range(0, 1)]
        public float EmptySeatsFactor = 0;

        /// <summary>
        ///   Chance that a spectator shows a sign.
        /// </summary>
        [Tooltip("Chance that a spectator shows a sign")]
        [Range(0, 1)]
        public float ShowSignFactor = 0.3f;

        /// <summary>
        ///   Configuration for the audience setup.
        /// </summary>
        public CharacterPlacer AudienceConfiguration;

        /// <summary>
        ///   Duration of level (in s).
        /// </summary>
        [Tooltip("Duration of level (in s)")]
        [Range(1, 120)]
        public float Duration = 10.0f;

        /// <summary>
        ///   Id of this level.
        /// </summary>
        [Tooltip("Id of this level")]
        public GameStates LevelId;

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
        ///   Duration till a spectator is persuaded (in s).
        /// </summary>
        [Tooltip("Duration till a spectator is persuaded (in s)")]
        [Range(0.1f, 2.0f)]
        public float PersuadeDuration = 1;

        /// <summary>
        ///   Duration between two spectators becoming upset (per second).
        /// </summary>
        [Tooltip("Duration between two spectators becoming upset (per second)")]
        [Range(0.1f, 10.0f)]
        public float UpsetSpectatorsInterval = 1;
    }
}