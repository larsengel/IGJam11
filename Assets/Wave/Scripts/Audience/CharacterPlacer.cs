using UnityEngine;

public class CharacterPlacer : MonoBehaviour
{
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
    public int seatStartId { get { return (PeoplePerRow / 2); } }

    public int seatMaxId { get { return (PeoplePerRow % 2 == 0) ? seatStartId : seatStartId + 1; } }

    public int rowStartId { get { return (NoOfRows / 2); } }

    public int rowMaxId { get { return (NoOfRows % 2 == 0) ? rowStartId : rowStartId + 1; } }

}
