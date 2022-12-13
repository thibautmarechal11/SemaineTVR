using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public float positionScrollSpeed = 2f;
    public float intensityScrollSpeed = 1f;
    public float intensityBase = 1f;
    public float positionJumpScale = 1f;
    public float intensityJumpScale = 0.1f;
    public float fadeInTime = 5f;
    public float fadeOutTime = 5f;
    public Vector2 delayFromTo = new Vector2(0f, 10f);

    public float fadeIn, fadeOut;
    public bool burning = false;
    Light myLight;
    Vector3 lightPos;

    private void Start()
    {
        myLight = GetComponent<Light>();
        lightPos = myLight.transform.localPosition;
        fadeIn = 0;
        fadeOut = 0;
    }
    private void Update()
    {
        if (burning)
        {
            if (fadeIn < 1f) fadeIn += Time.deltaTime / fadeInTime;
            if (fadeIn >= 1f) { fadeIn = 1f; fadeOut = 1f; }
            myLight.intensity = fadeIn * NewIntensity(intensityBase, intensityJumpScale, intensityScrollSpeed);
            transform.localPosition = lightPos + PositionDelta(positionScrollSpeed, positionJumpScale) * fadeIn;
        }
        else if (fadeOut > 0f)
        {
            fadeOut -= Time.deltaTime / fadeOutTime;
            if (fadeOut <= 0f) { fadeOut = 0f; fadeIn = 0f; }
            myLight.intensity = fadeOut * NewIntensity(intensityBase, intensityJumpScale, intensityScrollSpeed);
            transform.localPosition = lightPos + PositionDelta(positionScrollSpeed, positionJumpScale) * fadeOut;
        }
    }

    private Vector3 PositionDelta(float positionScrollSpeed, float scale)
    {
        float x = Mathf.PerlinNoise(Time.time * positionScrollSpeed, 1f + Time.time * positionScrollSpeed) - 0.5f;
        float y = Mathf.PerlinNoise(2f + Time.time * positionScrollSpeed, 3f + Time.time * positionScrollSpeed) - 0.5f;
        float z = Mathf.PerlinNoise(4f + Time.time * positionScrollSpeed, 5f + Time.time * positionScrollSpeed) - 0.5f;
        return new Vector3(x, y, z) * scale;
    }
    private float NewIntensity(float intensityBase, float intensityJumpScale, float intensityScrollSpeed)
    {
        return (intensityBase + (intensityJumpScale * Mathf.PerlinNoise(Time.time * intensityScrollSpeed, 1f + Time.time * intensityScrollSpeed)));
    }
}
