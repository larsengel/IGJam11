namespace Wave.Credits
{
    using UnityEngine;

    public class UICredits : MonoBehaviour
    {
        public void ReturnToMainMenu()
        {
            Main.Instance.SwitchState(GameStates.START);
        }
    }
}