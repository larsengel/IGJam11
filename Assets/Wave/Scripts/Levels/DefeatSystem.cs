using System.Collections.Generic;

namespace Wave.Levels
{
	using System.Linq;

	using UnityEngine;

	using Wave.Spectators;

	public class DefeatSystem : MonoBehaviour
	{
		public string LevelDefeatScene = "LevelDefeat";

		public LevelSystem LevelSystem;

		public SpectatorSystem SpectatorSystem;

		private float remainingLittleWaveDuration;

		public float RemainingStaminaRatio {
			get {
				if (!this.LevelSystem.IsLevelRunning) {
					return 1.0f;
				}
				return this.remainingLittleWaveDuration / this.LevelSystem.CurrentConfiguration.MaxLittleWaveDuration;
			}
		}

		public float WaveRatio { get; private set; }

		private float ComputeWaveRatio ()
		{
			if (this.SpectatorSystem == null) {
				return 0;
			}

			var spectatorCount = this.SpectatorSystem.Spectators.Count;
			if (spectatorCount == 0) {
				return 1;
			}

			var happySpectatorCount = this.SpectatorSystem.Spectators.Count (spectator => !spectator.IsUpset);
			return happySpectatorCount * 1.0f / spectatorCount;
		}

		[ContextMenu ("Loose Level")]
		private void LooseLevel ()
		{
			Main.Instance.SwitchState (GameStates.LEVEL_DEFEAT);

			UnityEngine.Analytics.Analytics.CustomEvent ("looseLevel", new Dictionary<string, object> {
				{ "levelID", this.LevelSystem.CurrentConfiguration.LevelId }
			});
		}

		private void OnEnable ()
		{
			this.LevelSystem.LevelStarted += this.OnLevelStarted;
			this.LevelSystem.LevelFinished += this.OnLevelFinished;
		}

		private void OnLevelFinished ()
		{
			UnityEngine.Analytics.Analytics.CustomEvent ("levelFinished", new Dictionary<string, object> {
				{ "levelID", this.LevelSystem.CurrentConfiguration.LevelId }
			});
		}

		private void OnLevelStarted ()
		{
			this.remainingLittleWaveDuration = this.LevelSystem.CurrentConfiguration.MaxLittleWaveDuration;

			UnityEngine.Analytics.Analytics.CustomEvent ("levelStarted", new Dictionary<string, object> {
				{ "levelID", this.LevelSystem.CurrentConfiguration.LevelId }
			});
		}

		private void Reset ()
		{
			if (this.LevelSystem == null) {
				this.LevelSystem = FindObjectOfType<LevelSystem> ();
			}
			if (this.SpectatorSystem == null) {
				this.SpectatorSystem = FindObjectOfType<SpectatorSystem> ();
			}
		}

		private void Update ()
		{
			if (!this.LevelSystem.IsLevelRunning) {
				return;
			}

			// Update wave ratio.
			this.WaveRatio = this.ComputeWaveRatio ();

			if (this.WaveRatio < this.LevelSystem.CurrentConfiguration.WaveThreshold) {
				this.remainingLittleWaveDuration -= Time.deltaTime;
			}

			if (this.remainingLittleWaveDuration <= 0) {
				this.LooseLevel ();
			}
		}
	}
}