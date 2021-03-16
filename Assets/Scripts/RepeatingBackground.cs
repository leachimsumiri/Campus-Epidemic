using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        RandomizeScene();
    }

    // Update is called once per frame
    void Update()
    {
        // Wenn die x-Pos kleiner als seine Länge "aus dem Sichtfeld"
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
            GameControl.instance.IncreaseScore(); // TODO: Ev bessere Stelle finden?
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 3, 0); // <- da 3 Drops verwendet
        transform.position   = (Vector2)transform.position + groundOffset;
        RandomizeScene();
    }

    ////////////////////////////
    
    private void RandomizeScene()
    {
        ////Random r = new Random();
        ////Random.seed = (int)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds%1000000;
        //Random.InitState((int)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds % 1000000);

        //GameObject.Find("bottom1").SetActive(Random.Range(0, 7) == 1);
        //GameObject.Find("bottom2").SetActive(Random.Range(0, 4) == 1);
        //GameObject.Find("bottom0").SetActive(Random.Range(0, 15) == 1);
        //GameObject.Find("bottom3").SetActive(Random.Range(0, 3) == 1);

        //GameObject.Find("DoorPlusExtras2").SetActive(Random.Range(0, 1) == 0); // ~ jedes 2te mal
        //// Jedes zwanzigste Mal
        //bool ersteTuer = (Random.Range(0, 5) == 0);
        //bool bildschirm = false;
        //if (ersteTuer && Random.Range(0, 100) == 0) // selten mal, Bildschirm zeigen
        //{
        //    bildschirm = true;
        //    ersteTuer = false;
        //}
        //GameObject.Find("DoorPlusExtras1").SetActive(ersteTuer);
        //GameObject.Find("Monitor").SetActive(bildschirm);
    }
}
