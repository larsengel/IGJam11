﻿namespace Wave.Spectators
{
	using System.Collections.Generic;
	using System.Linq;

	using UnityEngine;

	using Wave.Levels;

	public class SpectatorSystem : MonoBehaviour
	{
		public LevelSystem LevelSystem;

		public List<Spectator> Spectators;

		[ContextMenu ("Find Spectators")]
		private void FindSpectators ()
		{
			this.Spectators = FindObjectsOfType<Spectator> ().ToList ();
		}

		private void OnDisable ()
		{
			this.LevelSystem.LevelStarted -= this.OnLevelStarted;
			this.LevelSystem.LevelFinished -= this.OnLevelFinished;
		}

		private void OnEnable ()
		{
			this.LevelSystem.LevelStarted += this.OnLevelStarted;
			this.LevelSystem.LevelFinished += this.OnLevelFinished;
		}

		private void OnLevelFinished ()
		{
			this.Spectators = null;
		}

		private void OnLevelStarted ()
		{
			this.FindSpectators ();
			this.MakeSpectatorsWave ();
		}

		private void MakeSpectatorsWave ()
		{
			for (int i = 0, maxSpectatorsCount = this.Spectators.Count; i < maxSpectatorsCount; i++) {
				var spectator = this.Spectators [i];
				AudioSource audioSource = spectator.GetComponent<AudioSource> ();
				audioSource.volume = 0.0f;
				spectator.MakeHappy ();
			}

			Invoke ("EnableSoundOnSpectators", 1.0f);
		}

		private void EnableSoundOnSpectators ()
		{
			for (int i = 0, maxSpectatorsCount = this.Spectators.Count; i < maxSpectatorsCount; i++) {
				var spectator = this.Spectators [i];
				AudioSource audioSource = spectator.GetComponent<AudioSource> ();
				audioSource.volume = 1.0f;
			}
		}
	}
}