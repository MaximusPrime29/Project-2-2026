using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDrag : MonoBehaviour
{

    //Offset between mouse position and plant position to avoid snapping
    private Vector3 offset;

    //flag to track whether the plant is currently being dragged
    private bool dragging = false;

    


    //called when the player clicks on the plant
    private void OnMouseDown()
    {
        Debug.Log("in mousedown");

        // Calculate the offset between the plant's position and the mouse position in world coordinates
        offset = transform.position -Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;

    }
    private void OnMouseDrag()
    {

        if (dragging)
        {

            // Get the current mouse position in world space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Move the plant to follow the mouse, with offset applied
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
