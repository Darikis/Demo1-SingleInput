using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBalloon : MonoBehaviour {
    public Transform Target;
    public float CameraY;
    public GameObject Camera;
	// Use this for initialization
	void Start () {
        //Camera = gameObject.transform.position;
        CameraY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
        CameraY = Target.transform.position.y;
	}
}
