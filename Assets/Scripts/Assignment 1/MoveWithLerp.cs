using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLerp : MonoBehaviour
{
    public Vector3 centerPosition;
    public Vector3 outwardPosition;
    public float speed = 1.0f;
    public AnimationCurve easeCurve;
    private float t = 0f;
    private bool movingOutward = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movingOutward = true;
        }
        else
        {
            movingOutward = false;
        }

        t += Time.deltaTime * speed * (movingOutward ? 1 : -1);
        t = Mathf.Clamp01(t);
        float easedT = easeCurve.Evaluate(t);
        transform.position = Vector3.Lerp(centerPosition, outwardPosition, easedT);
    }
}