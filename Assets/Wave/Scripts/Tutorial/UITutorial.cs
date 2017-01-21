namespace Wave.Tutorial
{
    using UnityEngine;

    public class UITutorial : MonoBehaviour
    {
        public void StartGame()
        {
            Main.Instance.SwitchState(GameStates.LEVEL1);
        }
    }
}