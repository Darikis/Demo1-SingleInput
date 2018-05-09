using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawning : MonoBehaviour {

    public bool Spawn;
    public bool Despawn;
    public Transform Wall;
    public float CurrentX;
    public GameObject Victim;
    

	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        CurrentX = Wall.position.x;
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Spawn == true)
        {
            Debug.Log("Spawn");
            Instantiate(Wall, new Vector3((CurrentX + 20), 0, 0.5f), Quaternion.identity);
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
