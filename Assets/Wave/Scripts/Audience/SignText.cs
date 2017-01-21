using UnityEngine;

public class SignText : MonoBehaviour
{
    public string[] Texts;

    void Start()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TextMesh>().text = Texts[Random.Range(0, Texts.Length)];
    }
}