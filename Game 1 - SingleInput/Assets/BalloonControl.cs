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
    public float rotationSpeed;
    public float movementSpeed;
    public float rotationTime;
    public bool Launch;
    public bool NewRotation;
    public bool Test = false;


    // Use this for initialization
    void Start()
    {
        //Rigid = gameObject.GetComponent<Rigidbody2D>();
        //Invoke("ChangeRotation", rotationTime);
        Launch = false;
        NewRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position += transform.up * movementSpeed * Time.deltaTime;

        Vector3 Size = new Vector3(Width, Height, 1f);
        transform.localScale = Size;
        if (Input.GetKeyDown("g"))
        {

            Thrust = Thrust + ForceRate;
            Width = Width + ScaleRate;
            Height = Height + ScaleRate;

        }
        if (Input.GetKeyDown("h"))
        {
            Rigid.AddForce(transform.up * Thrust, ForceMode2D.Impulse);
            Launch = true;
        }
        if (Launch == true)
        {


            if (Test == true)
            {
                StartCoroutine(Fly(Balloon));
            }
                
        }


    }
        void ChangeRotation()
        {
            
            if (Random.value > 0.5f)
            {
                
            }
            Invoke("ChangeRotation", rotationTime);
        }


        IEnumerator Fly (Transform Balloon)
        {
        rotationSpeed = Random.Range(-360f, 360f);
        transform.Rotate(new Vector3(0, 0, rotationTime * Time.deltaTime));
        yield return new WaitForSeconds(1f);
        rotationSpeed = -rotationSpeed;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fly(Balloon));
        }
    
}