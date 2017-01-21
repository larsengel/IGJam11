using UnityEngine;

using Wave;

public class UICredits : MonoBehaviour
{
    public Main Main;

    public void OnButtonClick()
    {
        this.Main.ShowCredits();
    }

    private void Awake()
    {
        this.Main = FindObjectOfType<Main>();
    }
}