using UnityEngine;

public class Plant : MonoBehaviour
{

    public PlantData data;

    


    //public LightType requiredLight;
    public LightType currentZone = LightType.None;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentZone == LightType.None)
        {
            sr.color = Color.gray;
            //Debug.Log("current zone is" + currentZone + "requiredlight is" + requiredLight);
        }
        else if (currentZone == data.requiredLight)
        {

            sr.color = Color.green;

        }

        else
        {
            sr.color = Color.red;
        }



    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LowLight"))
        {
            currentZone = LightType.Low;
        }
        else if (other.CompareTag("MediumLight"))
        {
            currentZone = LightType.Medium;
        }

        else if (other.CompareTag("HighLight"))
        {
            currentZone = LightType.High;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LowLight") || other.CompareTag("MediumLight") || other.CompareTag("HighLight"))
        {

            currentZone = LightType.None;
        }
        
    }

}
