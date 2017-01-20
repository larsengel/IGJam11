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
    public Sprite[] Heads;

    void Start()
    {
        

        Random rnd = new Random();
        for (int i = 0; i < People; i++)
        {
            createCharacter(rnd);
        }
    }

    void createCharacter(Random rnd)
    {
        // Decide Gender
        var gender = rnd.Next(1, 3);

        if (gender == 1)
        {
            Debug.Log("male");
        }
        else
        {
            Debug.Log("female");
        }
    }
}
