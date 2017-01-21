using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharGenerator : MonoBehaviour
{
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
        var nose = Noses[Random.Range(0, Noses.Length)];
        var eyes = Eyes[Random.Range(0, Eyes.Length)];
        var mouth = Mouths[Random.Range(0, Mouths.Length)];
        var hair = Hairs[Random.Range(0, Hairs.Length)];


        Search(transform, "Eyes").GetComponent<SpriteRenderer>().sprite = eyes;
        Search(transform, "Nose").GetComponent<SpriteRenderer>().sprite = nose;
        Search(transform, "Mouth").GetComponent<SpriteRenderer>().sprite = mouth;
        Search(transform, "Hair").GetComponent<SpriteRenderer>().sprite = hair;

    }

    public static Transform Search(Transform target, string name)
    {
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; ++i)
        {
            var result = Search(target.GetChild(i), name);

            if (result != null) return result;
        }

        return null;
    }
}
