using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel.Design.Serialization;

public class CharacterPlacer : MonoBehaviour
{

	
    public GameObject AudiencePrefab;
    public Transform Audience;

    public int NoOfRows;
    public int PeoplePerRow;

    public float CharacterWidth;
    public float CharacterHeight;

    [Tooltip ("every second row is offset between 0 and this")] 
    public float SecondRowSpacing;

    [Range (0.0f, 1.0f)]
    public float MinimumScale;
    [Range (1.0f, 2.0f)]
    public float MaximumScale;

    public float CharacterSpacing;


   
    List<float> rowOffsets;

    void Awake ()
    {
        
    }

    void Start ()
    {
        for (int y = -(NoOfRows / 2); y < (NoOfRows / 2); y++) {
            for (int x = -(PeoplePerRow / 2); x < (PeoplePerRow / 2); x++) {
                CreateCharakter (x, y);
            }
        }

    }

    void CreateCharakter (int x, int y)
    {
        float pos_x = x * CharacterWidth;
        float pos_y = y * CharacterHeight;

        // offset every second row
        if (y % 2 == 0) {
            pos_x += SecondRowSpacing;
        }

        Vector3 pos = new Vector3 (pos_x, pos_y, y);
        var new_char = Instantiate (AudiencePrefab, pos, Quaternion.identity, Audience);

        float scale = Random.Range (0.8f, 1.2f);
        new_char.transform.localScale = new Vector3 (scale, scale, scale);

    }
}
