namespace Wave.Audience
{
	using UnityEngine;

	using Wave.Levels;
	using Wave.Spectators;

	public class AudiencePlacementSystem : MonoBehaviour
	{
		public GameObject AudiencePrefab;

		[Range (0.0f, 1.0f)]
		public float EmptySeatsFactor = 0.1f;

		public LevelSystem LevelSystem;

		private void OnDisable ()
		{
			this.LevelSystem.LevelLoaded -= this.OnLevelLoaded;
		}

		private void OnEnable ()
		{
			this.LevelSystem.LevelLoaded += this.OnLevelLoaded;
		}

		private void OnLevelLoaded ()
		{
			this.RenderAudience (this.LevelSystem.CurrentConfiguration.AudienceConfiguration);
		}

		private void RenderActor (CharacterPlacer audienceConfiguration, int x, int y)
		{
			float row_id = y + audienceConfiguration.rowStartId; // Have a row id counting up from 0

			float pos_x = x * audienceConfiguration.CharacterWidth;
			float pos_y = y * audienceConfiguration.CharacterHeight;

			// offset every second row
			if (y % 2 == 0) {
				pos_x += audienceConfiguration.SecondRowSpacing;
			}

			Vector3 pos = new Vector3 (pos_x, pos_y, y * 2 + x * 0.01f);
			var spectatorGameObject = Instantiate (
				                          this.AudiencePrefab,
				                          pos,
				                          Quaternion.identity,
				                          audienceConfiguration.Audience);

			// guys in back are smaller than front ...
			float row_scale_factor = audienceConfiguration.InitialScale
			                         - (row_id * audienceConfiguration.MaxDepthScale / audienceConfiguration.NoOfRows);
			// ... and have a indiviaual scale factor
			float scale = row_scale_factor
			              * Random.Range (audienceConfiguration.MinimumScale, audienceConfiguration.MaximumScale);

			spectatorGameObject.transform.localScale = new Vector3 (scale, scale, scale);
			spectatorGameObject.transform.localPosition = pos;

			var spectator = spectatorGameObject.GetComponent<Spectator> ();
			if (spectator != null) {
				spectator.ShowSignFactor = this.LevelSystem.CurrentConfiguration.ShowSignFactor;
			}
			var spectatorParticleEffects = spectatorGameObject.GetComponent<Particler> ();
			if (spectatorParticleEffects != null) {
				spectatorParticleEffects.Duration = this.LevelSystem.CurrentConfiguration.PersuadeDuration;
			}
		}

		private void RenderAudience (CharacterPlacer audienceConfiguration)
		{
			for (int y = audienceConfiguration.rowMaxId; y > -audienceConfiguration.rowStartId; y--) {
				for (int x = -audienceConfiguration.seatStartId; x < audienceConfiguration.seatMaxId; x++) {
					// Seat may stay empty
					if (Random.Range (0.0f, 1.0f) < this.EmptySeatsFactor) {
						continue;
					}

					this.RenderActor (audienceConfiguration, x, y);
				}
			}
		}

		private void Reset ()
		{
			if (this.LevelSystem == null) {
				this.LevelSystem = FindObjectOfType<LevelSystem> ();
			}
		}
	}
}