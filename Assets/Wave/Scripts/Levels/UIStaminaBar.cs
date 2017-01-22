namespace Wave.Levels
{
	using UnityEngine;
	using UnityEngine.UI;

	public class UIStaminaBar : MonoBehaviour
	{
		public Image FillImage;

		private DefeatSystem defeatSystem;

		private void Start ()
		{
			this.defeatSystem = FindObjectOfType<DefeatSystem> ();
		}

		private void Update ()
		{
			if (this.defeatSystem != null && this.FillImage != null) {
				this.FillImage.fillAmount = this.defeatSystem.RemainingStaminaRatio;

				Shaker shaker = Main.Instance.mainCamera.GetComponent<Shaker> ();
				if (this.FillImage.fillAmount < 0.5f) {
					shaker.shakeAmount = 1 - this.FillImage.fillAmount;
					shaker.StartShake ();
				}
			}
		}
	}
}