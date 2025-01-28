using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLerp : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 1.0f;
    public AnimationCurve easeCurve;
    private float t = 0f;
    private bool movingForward = true;

    void Update()
    {
        t += Time.deltaTime * speed * (movingForward ? 1 : -1);
        float easedT = easeCurve.Evaluate(t);
        transform.position = Vector3.Lerp(pointA, pointB, easedT);

        if (t >= 1f || t <= 0f)
        {
            movingForward = !movingForward;
        }
    }
}