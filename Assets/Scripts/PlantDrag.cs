using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDrag : MonoBehaviour
{

    private Vector3 offset;
    private bool dragging = false;

    



    private void OnMouseDown()
    {
        Debug.Log("in mousedown");
        offset= transform.position -Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;

    }
    private void OnMouseDrag()
    {

        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }
        
    }
    private void OnMouseUp()
    {
        dragging = false;
    }

   
    void Update()
    {
        
    }

    



}
