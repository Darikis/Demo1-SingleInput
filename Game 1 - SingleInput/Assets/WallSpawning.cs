using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawning : MonoBehaviour {

    public bool Spawn;
    public bool Despawn;
    public Transform Wall;
    public float CurrentY;
    public GameObject Victim;
    

	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        CurrentY = Wall.position.y;
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Spawn == true)
        {
            Debug.Log("Spawn");
            Instantiate(Wall, new Vector3(0, (CurrentY + 20), 0), Quaternion.identity);
            /*for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                   
                }
            }*/
            Spawn = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Despawn == true && other.gameObject.tag == "LastWall")
        {
            Debug.Log("Boom");
            Destroy(Victim);
            Spawn = true;
        }
    }
}
