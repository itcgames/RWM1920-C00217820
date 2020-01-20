using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFanBlade : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject blade;


    void Update()
    {
        blade.transform.Rotate(rotationSpeed, 0, 0);
    }
}
