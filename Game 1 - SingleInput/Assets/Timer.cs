using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeleft = 10;
    public Text CountDownText;
    public Text StartText;
    public bool StartCount;
    public BalloonControl Controller;
	// Use this for initialization
	void Start () {
        StartText.enabled = false;
        CountDownText.enabled = false;
        StartCount = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("space") && StartCount == true)
        {
            StartText.enabled = true;
            StartCoroutine("SpawnText");
            StartCoroutine("LoseTime");
            StartCount = false;
        }

        CountDownText.text = (" " + timeleft + " ");

        if(timeleft <= 0)
        {
            StopAllCoroutines();
            CountDownText.text = "GO!";
            Controller.TimesUp = true;
        }
	}
    IEnumerator SpawnText()
    {
        
        yield return new WaitForSeconds(.5f);
        StartText.enabled = false;
        CountDownText.enabled = true;
        StartCoroutine("LoseTime");
        yield return new WaitForSeconds(.5f);
        StopCoroutine("SpawnTime");

    }
    IEnumerator LoseTime()
    {
        while (true)
        {

            yield return new WaitForSeconds(2);
            timeleft--;
        }
    }
}
