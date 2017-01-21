using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsDev : MonoBehaviour
{
    public string devName;
    public Sprite hair;
    public Sprite eyes;
    public Sprite nose;
    public Sprite mouth;
    CharGenerator charGenerator;


    void Start()
    {
        charGenerator = GetComponentInChildren<CharGenerator>();
        StartCoroutine(InitDev());
    }

    private IEnumerator InitDev()
    {
        yield return new WaitForSeconds(0.01f);
        CharGenerator.Search(charGenerator.transform, "Hair").GetComponent<SpriteRenderer>().sprite = hair;
        CharGenerator.Search(charGenerator.transform, "Eyes").GetComponent<SpriteRenderer>().sprite = eyes;
        CharGenerator.Search(charGenerator.transform, "Nose").GetComponent<SpriteRenderer>().sprite = nose;
        CharGenerator.Search(charGenerator.transform, "Mouth").GetComponent<SpriteRenderer>().sprite = mouth;


        CharGenerator.Search(charGenerator.transform, "schild_left").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.01f);

        var textLeft = CharGenerator.Search(charGenerator.transform, "text_left");
        textLeft.GetComponent<TextMesh>().text = devName;
        textLeft.GetComponent<MeshRenderer>().enabled = true;
        CharGenerator.Search(charGenerator.transform, "audience").GetComponent<Animator>().SetTrigger("wave_left");

        CharGenerator.Search(charGenerator.transform, "text_right").GetComponent<MeshRenderer>().enabled = false;
        CharGenerator.Search(charGenerator.transform, "schild_right").GetComponent<SpriteRenderer>().enabled = false;
    }

}
