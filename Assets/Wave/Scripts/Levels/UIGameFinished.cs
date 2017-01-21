namespace Wave.Levels
{
    using UnityEngine;

    public class UIGameFinished : MonoBehaviour
    {
        private Main main;

        public void ToCredits()
        {
            if (this.main != null)
            {
                this.main.SwitchState(GameStates.CREDITS);
            }
        }

        private void Start()
        {
            this.main = FindObjectOfType<Main>();
        }
    }
}