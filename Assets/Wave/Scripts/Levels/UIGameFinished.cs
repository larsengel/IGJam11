namespace Wave.Levels
{
	using UnityEngine;

	public class UIGameFinished : MonoBehaviour
	{
		private Main main;

		private StatsSystem statsSystem;

		public void ToCredits ()
		{
			if (this.main != null) {
				this.main.SwitchState (GameStates.CREDITS);
			}
		}

		private void Start ()
		{
			this.main = FindObjectOfType<Main> ();

			statsSystem = FindObjectOfType<StatsSystem> ();
			if (statsSystem != null) {
				var score = statsSystem.AvaragePoints;

			}
		}
	}
}