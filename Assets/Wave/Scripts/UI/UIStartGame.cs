using UnityEngine;

using Wave;

public class UIStartGame : MonoBehaviour
{
    public Main Main;

    public void OnButtonClick()
    {
        this.Main.SwitchState(GameStates.TUTORIAL);
    }

    private void Awake()
    {
        this.Main = FindObjectOfType<Main>();
    }
}