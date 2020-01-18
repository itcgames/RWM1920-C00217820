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
    protected Rigidbody2D rb;

    public AudioSource m_MyAudioSource;
    private float m_MySliderValue;
    private void Start()
    {
             m_MySliderValue = strength/100;
            m_MyAudioSource = GetComponent<AudioSource>();
            m_MyAudioSource.volume = m_MySliderValue;
            m_MyAudioSource.Play();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localScale = new Vector3(size.x * strength, size.y, size.z);

        if (inFanArea)
        {
            moveObject(rb,direction,strength);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Rigidbody2D>() == true)
        {
            rb = coll.gameObject.GetComponent<Rigidbody2D>();
            inFanArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        inFanArea = false;
    }


    public static void moveObject(Rigidbody2D t_rb, Vector3 t_direction, float t_strength)
    {
        t_rb.AddForce(t_direction * t_strength);
    }

}

