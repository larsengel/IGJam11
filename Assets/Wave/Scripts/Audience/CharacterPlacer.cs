using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;


public class CharacterPlacer : MonoBehaviour
{

	
    public GameObject AudiencePrefab;
    public Transform Audience;

    [Space (20.0f)]
    public int NoOfRows;
    public int PeoplePerRow;

    [Space (20.0f)]
    public float CharacterWidth;
    public float CharacterHeight;


    [Header ("Extra Spacing")]

    [Tooltip ("every second row is offset between 0 and this")] 
    public float SecondRowSpacing;

    [Range (0.0f, 1.0f)]
    public float EmptySeatsFactor;


    //public float CharacterSpacing;

    [Header ("Scaling")]

    [Range (0.0f, 1.0f)]
    [Tooltip ("Minimum Individual Scale")]
    public float MinimumScale;
    [Range (1.0f, 2.0f)]
    [Tooltip ("Maximum Individual Scale")]
    public float MaximumScale;

    [Range (0.0f, 1.0f)]
    [Tooltip ("Maximum scale for depth")]
    public float MaxDepthScale;

    [Tooltip ("Scale Factor to Start with")]
    [Range (0.0f, 2.0f)]
    public float InitialScale;



    // the Rows and seats are iterated with IDs starting from -half_value to +half_value, so
    // that 0,0 is around the 0,0 point of the gameobject.
    // Also this gives us a row z-index for free
    int seatStartId { get { return (PeoplePerRow / 2); } }

    int seatMaxId { get { return (PeoplePerRow % 2 == 0) ? seatStartId : seatStartId + 1; } }

    int rowStartId { get { return (NoOfRows / 2); } }

    int rowMaxId { get { return (NoOfRows % 2 == 0) ? rowStartId : rowStartId + 1; } }


 
    void Start ()
    {
        RenderAudience ();
    }


    public void RenderAudience ()
    {
        for (int y = -rowStartId; y < rowMaxId; y++) {   
            for (int x = -seatStartId; x < seatMaxId; x++) {
                // Seat may stay empty
                if (Random.Range (0.0f, 1.0f) < EmptySeatsFactor) {
                    RenderActor (x, y);
                }
            }
        }
    }

    void RenderActor (int x, int y)
    {

        float row_id = y + rowStartId; // Have a row id counting up from 0

        float pos_x = x * CharacterWidth;
        float pos_y = y * CharacterHeight;

        // offset every second row
        if (y % 2 == 0) {
            pos_x += SecondRowSpacing;
        }
            
        Vector3 pos = new Vector3 (pos_x, pos_y, y);
        var new_char = Instantiate (AudiencePrefab, pos, Quaternion.identity, Audience);

        // guys in back are smaller than front ...
        float row_scale_factor = InitialScale - (row_id * MaxDepthScale / NoOfRows);
        // ... and have a indiviaual scale factor
        float scale = row_scale_factor * Random.Range (MinimumScale, MaximumScale);

        new_char.transform.localScale = new Vector3 (scale, scale, scale);

    }
}
