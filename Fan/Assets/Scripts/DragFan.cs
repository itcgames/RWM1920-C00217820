using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFan : MonoBehaviour
{
    private float m_coordinates;
    private Vector3 m_Offset;
   

    void OnMouseDown()
    {
        m_coordinates = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + m_Offset;
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_coordinates;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}

