using System;
using UnityEngine;
using Random = System.Random;

public class CharGenerator : MonoBehaviour
{
    private const int People = 12;

    public Sprite[] Eyes;
    public Sprite[] Noses;
    public Sprite[] Mouths;
    public Sprite[] Hairs;

    void Start()
    {
        createFace();
    }

    void createFace()
    {
        Random rnd = new Random();

        var nose = Noses[rnd.Next(0, Noses.Length)];
        var eyes = Eyes[rnd.Next(0, Eyes.Length)];
        var mouth = Mouths[rnd.Next(0, Mouths.Length)];
        var hair = Hairs[rnd.Next(0, Hairs.Length)];


        transform.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes;
        transform.Find("Nose").GetComponent<SpriteRenderer>().sprite = nose;
        transform.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouth;
        transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hair;

    }
}
