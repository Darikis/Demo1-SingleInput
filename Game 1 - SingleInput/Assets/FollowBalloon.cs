using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBalloon : MonoBehaviour {
    public Transform Target;
    public float TargetX;
    public Transform Camera;
    public float CameraX;
    public float Speed;
    public Vector3 newYPos;
    public bool Follow;
    
	// Use this for initialization
	void Start () {
        //Camera = gameObject.transform.position;

        Follow = false;
	}
	
	// Update is called once per frame
	void Update () {
        CameraX = Camera.position.x;
        TargetX = Target.position.x;
        Speed = ((TargetX - CameraX)*2) * Time.deltaTime;
        newYPos = new Vector3(TargetX, 0, -10);
        
	}
    public void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Hit");

        Follow = true;
    }
    public void OnTriggerStay2D(Collider2D Other)
    {
        Debug.Log("Still Here");

        if (Follow == true)
        {
            Camera.transform.position = Vector3.MoveTowards(Camera.position, newYPos, Speed);
        }
    }
    public void OnTriggerExit2D(Collider2D Other)
    {
        Debug.Log("Hit");

        Follow = false;
    }
}
