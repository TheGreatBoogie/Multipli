using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        // Adjust the rotation speed if needed
        RenderSettings.skybox.SetFloat("_Rotation", Mathf.Repeat(RenderSettings.skybox.GetFloat("_Rotation") + rotationSpeed * Time.deltaTime, 360f));
    }
}
