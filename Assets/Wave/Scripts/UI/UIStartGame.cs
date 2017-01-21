using UnityEngine;

using Wave;

public class UIStartGame : MonoBehaviour
{
    public Main Main;

    public void OnButtonClick()
    {
        this.Main.StartGame();
    }

    private void Awake()
    {
        this.Main = FindObjectOfType<Main>();
    }
}