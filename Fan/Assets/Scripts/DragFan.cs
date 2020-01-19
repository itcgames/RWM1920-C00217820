using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFan : MonoBehaviour
{

    private Vector3 m_Offset;
    private float m_coordinates;

    void OnMouseDown()
    {
        m_coordinates = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_coordinates;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + m_Offset;
    }
}

