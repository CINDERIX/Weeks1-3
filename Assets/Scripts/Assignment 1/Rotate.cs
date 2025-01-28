using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnInput : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool invertRotation = false; // Toggle to invert rotation direction
    private SpriteRenderer spriteRenderer;
    private float rotationAmount = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }

        // Apply inversion if enabled
        if (invertRotation)
        {
            rotation = -rotation;
        }

        transform.Rotate(Vector3.forward, rotation);
        rotationAmount += Mathf.Abs(rotation);

        // Change color after a full rotation (360 degrees)
        if (rotationAmount >= 360f)
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
            rotationAmount = 0f;
        }
    }
}