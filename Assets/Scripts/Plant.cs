using UnityEngine;

public class Plant : MonoBehaviour
{

    public PlantData data;


    // Current light zone the plant is in
    public LightType currentZone = LightType.None;

    // Current water level and rate at which it decreases over time
    public float currentWater = 50f;
    public float drainRate =5f;


    // Reference to the SpriteRenderer
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Gradually reduce water over time
        currentWater -= drainRate * Time.deltaTime;

        // Ensure water stays within 0-100
        currentWater = Mathf.Clamp(currentWater, 0f, 100f);

        // Determine if the plant is in a healthy water range
        bool waterOk = IsWaterHealthy();

        // Determine if the plant is in the correct light zone
        bool lightOk =currentZone== data.requiredLight;


        // Update plant color based on health
        if (waterOk && lightOk)
        {
            // Healthy plant
            sr.color = Color.green;

        }

        else
        {
            // Orange for unhealthy
            sr.color = new Color(1f, 0.65f, 0f);
        }
        



    }

    // Function to modify water
    public void SetWater(float value)
    {
        currentWater = currentWater + value;
    }


    // Detect when plant enters a light zone
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

    // Detect when plant exits a light zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LowLight") || other.CompareTag("MediumLight") || other.CompareTag("HighLight"))
        {

            currentZone = LightType.None;
        }
        
    }

    // Returns true if water level is within acceptable range
    bool IsWaterHealthy()
    {

        float min = data.idealWater - data.tolerance;
        float max = data.idealWater + data.tolerance;
        return currentWater >= min && currentWater <= max;

        

    }

}
