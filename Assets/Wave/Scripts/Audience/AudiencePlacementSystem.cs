namespace Wave.Audience
{
	using UnityEngine;

	using Wave.Levels;
	using Wave.Spectators;

	public class AudiencePlacementSystem : MonoBehaviour
	{
		public GameObject AudiencePrefab;
	    public GameObject EmptyChairPrefab;

		public LevelSystem LevelSystem;

	    // Row definition from start to end index: 4 rows
	    public int RowStartId = 0;
	    public int MaxRowId = 3;

	    // Seats per row definiton from start to end index: 7 seats
	    public int SeatStartId = -3;
	    public int SeatMaxId = 3;

	    // Seated audience definition from level configuration
	    private int AudienceMaxRowId { get { return RowStartId + LevelSystem.CurrentConfiguration.Rows; } }
	    private int AudienceSeatStartId { get { return (-1 * LevelSystem.CurrentConfiguration.SeatsPerRow / 2); } }
	    private int AudienceSeatMaxId { get { return AudienceSeatStartId + LevelSystem.CurrentConfiguration.SeatsPerRow; } }

	    [Space (20.0f)]
	    public float CharacterWidth = 8;
	    public float CharacterHeight = 5;

	    [Header ("Extra Spacing")]

	    [Tooltip ("every second row is offset between 0 and this")]
	    public float SecondRowSpacing = 2;

	    [Header ("Scaling")]

	    [Range (0.0f, 1.0f)]
	    [Tooltip ("Minimum Individual Scale")]
	    public float MinimumScale = 0.9f;
	    [Range (1.0f, 2.0f)]
	    [Tooltip ("Maximum Individual Scale")]
	    public float MaximumScale = 1.1f;

	    [Range (0.0f, 1.0f)]
	    [Tooltip ("Maximum scale for depth")]
	    public float MaxDepthScale = 0.4f;

	    [Tooltip ("Scale Factor to Start with")]
	    [Range (0.0f, 2.0f)]
	    public float InitialScale = 1.22f;

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

		private void RenderActor (CharacterPlacer audienceConfiguration, int x, int y, bool emptySeat)
		{
		    float row_id = y + RowStartId; // Have a row id counting up from 0

			float pos_x = x * CharacterWidth;
			float pos_y = y * CharacterHeight;

			// offset every second row
			if (y % 2 == 0) {
				pos_x += SecondRowSpacing;
			}

			Vector3 pos = new Vector3 (pos_x, pos_y, y * 2 + x * 0.01f);
		    var prefab = emptySeat ? this.EmptyChairPrefab : this.AudiencePrefab;
		    var spectatorGameObject = Instantiate (
				                          prefab,
				                          pos,
				                          Quaternion.identity,
				                          audienceConfiguration.Audience);

			// guys in back are smaller than front ...
			float row_scale_factor = InitialScale - (row_id * MaxDepthScale / LevelSystem.CurrentConfiguration.Rows);
			// ... and have a indiviaual scale factor
			float scale = row_scale_factor * Random.Range (MinimumScale, MaximumScale);

			spectatorGameObject.transform.localScale = new Vector3 (scale, scale, scale);
			spectatorGameObject.transform.localPosition = pos;

			var spectator = spectatorGameObject.GetComponent<Spectator> ();
			if (spectator != null && !emptySeat) {
				spectator.ShowSignFactor = this.LevelSystem.CurrentConfiguration.ShowSignFactor;
			}
			var spectatorParticleEffects = spectatorGameObject.GetComponent<Particler> ();
			if (spectatorParticleEffects != null && !emptySeat) {
				spectatorParticleEffects.Duration = this.LevelSystem.CurrentConfiguration.PersuadeDuration;
			}
		}

		private void RenderAudience (CharacterPlacer audienceConfiguration)
		{
		    for (var y = MaxRowId; y >= RowStartId; y--)
            {
                for (var x = SeatStartId; x <= SeatMaxId; x++)
                {
                    if (y >= AudienceMaxRowId ||
                        x < AudienceSeatStartId ||
                        x >= AudienceSeatMaxId ||
                        Random.Range(0.0f, 1.0f) < this.LevelSystem.CurrentConfiguration.EmptySeatsFactor)
                    {
                        this.RenderActor(audienceConfiguration, x, y, true);
                    }
                    else
                    {
                        this.RenderActor (audienceConfiguration, x, y, false);
                    }
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