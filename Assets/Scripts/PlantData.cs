using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantData : ScriptableObject
{
    public string plantName;

    public LightType requiredLight;

    public float idealWater;
    public float tolerance;

    public float minWater;
    public float maxWater;
    
}
