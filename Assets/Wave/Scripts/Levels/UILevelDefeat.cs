namespace Wave.Levels
{
	using System.Collections.Generic;
	using UnityEngine;

	public class UILevelDefeat : MonoBehaviour
	{
		public List<NewsPaper> newspapers;
		private LevelSystem levelSystem;

		public void RestartGame ()
		{
			Main.Instance.SwitchState (GameStates.START);
		}

		public void RestartLevel ()
		{
			if (this.levelSystem != null) {
				this.levelSystem.RestartLevel ();
			}
		}

		private void Start ()
		{
			this.levelSystem = FindObjectOfType<LevelSystem> ();
			newspapers [Random.Range (0, newspapers.Count)].Init (false, 0);
		}
	}
}