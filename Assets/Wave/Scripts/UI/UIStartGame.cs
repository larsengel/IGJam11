using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wave;

public class UIStartGame : MonoBehaviour
{

    public Main Main;

    void Awake ()
    {
        Main = GameObject.Find ("Main").GetComponent<Main> ();
    }

    public void OnButtonClick ()
    {
        Main.StartGame ();
    }

}
