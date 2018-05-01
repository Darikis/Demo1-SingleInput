using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBalloon : MonoBehaviour {
    public Transform Target;
    public float TargetY;
    public Transform Camera;
    public float CameraY;
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
        CameraY = Camera.position.y;
        TargetY = Target.position.y;
        Speed = ((TargetY - CameraY)*2) * Time.deltaTime;
        newYPos = new Vector3(0, TargetY, -10);
        
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
