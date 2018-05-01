using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public float Current01;
    public float Current02;
    public float Total;
    public float StoredFloat;
    public Transform Actor;
    public Text Score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Current01 = Actor.position.y;
        Score.text = (" " + Total + " ");
        StartCoroutine("Points");
        Current01 = Current02;
        if (StoredFloat < Current01)
        {
            Current01 = Total;   
            Debug.Log("Yup");
        }
        
    }

    IEnumerator Points ()
    {
        
        Current02 = StoredFloat;
        yield return new WaitForSeconds(1f);
        StopCoroutine("Points");
        
    }
}
