using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDrag : MonoBehaviour
{

    private Vector3 offset;
    private bool dragging = false;

    public string currentZone = "None";
    public string lightRequirement = "Medium";



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
        if (currentZone == lightRequirement)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LowLight"))
        {
            currentZone = "Low";
        }
        else if (other.CompareTag("MediumLight"))
        {
            currentZone = "Medium";
        }

        else if (other.CompareTag("HighLight"))
        {
            currentZone = "High";
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LowLight") || other.CompareTag("MediumLight") || other.CompareTag("HighLight"))
        {
            currentZone = "None";
        } 

    }



}
