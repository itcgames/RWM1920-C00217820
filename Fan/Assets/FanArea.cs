using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanArea : MonoBehaviour
{
    public float strength;
    public Vector3 direction;
    public Vector3 size;

    private bool inFanArea = false;
    private GameObject AirFlow;
 

    private Rigidbody2D rb;

    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localScale =new Vector3(size.x* strength , size.y,size.z);

        if (inFanArea)
        {
            rb.AddForce(direction*strength);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {       
        if(coll.gameObject.GetComponent<Rigidbody2D>() == true)
        {
            rb = coll.GetComponent<Rigidbody2D>();
            inFanArea = true;
        }          
    }

    void OnTriggerExit2D(Collider2D coll)
    {
           inFanArea = false;
    }
}
