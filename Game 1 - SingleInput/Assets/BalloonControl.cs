using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonControl : MonoBehaviour {
    public float Width;
    public float Height;
    public float ScaleRate;
    public float ForceRate;
    public Vector3 Size;
    public float Thrust;
    public Rigidbody2D Rigid;
    public Transform Balloon;
    public float RotateValue;
    //public float rotationSpeed;
    //public float movementSpeed;
    //public float rotationTime;
    public bool Launch;
    public int Direction;
    public bool ValueNeeded;
    public bool GameOver;
    public bool CanSpin;
    public bool TimesUp;


    // Use this for initialization
    void Start()
    {
        //Rigid = gameObject.GetComponent<Rigidbody2D>();
        //Invoke("ChangeRotation", rotationTime);
        Launch = false;
        TimesUp = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position += transform.up * movementSpeed * Time.deltaTime;

        Vector3 Size = new Vector3(Width, Height, 1f);
        transform.localScale = Size;
        if (Input.GetKeyDown("space") && Launch == false && GameOver == false)
        {

            Thrust = Thrust + ForceRate;
            Width = Width + ScaleRate;
            Height = Height + ScaleRate;

        }
        if (Input.GetKeyDown("h"))
        {
            Rigid.AddRelativeForce(transform.up * Thrust);
            Launch = true;
            StartCoroutine(Fly(Balloon));
            CanSpin = true;
        }
        if (TimesUp == true && GameOver == false)
        {
            Rigid.AddRelativeForce(transform.up * Thrust);
            Launch = true;
            StartCoroutine(Fly(Balloon));
            CanSpin = true;
        }

        if (Input.GetKeyDown("space") && Launch == true && GameOver == false)
        {
            StopAllCoroutines();
            Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            Rigid.AddForce(transform.up * Thrust * 5);
            Thrust = Thrust - 2f;
            ValueNeeded = true;
            CanSpin = false;
            Width = Width - 0.04f;
            Height = Height - 0.04f;
        }
        if (Input.GetKeyUp("space") && Launch == true && GameOver == false)
        {
            Rigid.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Fly(Balloon));
            CanSpin = true;
        }
    }
    private void FixedUpdate()
    {
        if (Launch == true && Thrust > 1 && GameOver == false)
        {
            Rigid.AddRelativeForce(transform.up * Thrust);
            //Thrust = Thrust - .05f;
            StartCoroutine(Fly(Balloon));
            Width = Width - 0.01f;
            Height = Height - 0.01f;
            Thrust = Thrust - 1f;

        }
        if (Launch == true && Thrust < .5 && GameOver == false)
        {
            Thrust = 0;
            Rigid.gravityScale = 1;
            StopAllCoroutines();
            Launch = false;
            GameOver = true;
        }
    }
        IEnumerator Fly (Transform Balloon)
        {
        if (CanSpin == true && GameOver == false)
        {

            if (ValueNeeded == true)
            {
                //MyY = transform.rotation.y;
                Direction = UnityEngine.Random.Range(0, 2) * 2 - 1;
                RotateValue = Convert.ToInt32((UnityEngine.Random.Range(-360f, 360f)) * Direction);
                //MyY = RotateValue + MyY;
                ValueNeeded = false;
            }

            transform.Rotate(new Vector3(0, 0, RotateValue * Time.deltaTime));
            yield return new WaitForSeconds(3f);
            ValueNeeded = true;
            StartCoroutine(Fly(Balloon));
        }
        /*rotationSpeed = UnityEngine.Random.Range(-360f, 360f);
        transform.Rotate(new Vector3(0, 0, rotationTime * Time.deltaTime));
        yield return new WaitForSeconds(1f);
        rotationSpeed = rotationSpeed * -1;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fly(Balloon));*/
        }
    
}