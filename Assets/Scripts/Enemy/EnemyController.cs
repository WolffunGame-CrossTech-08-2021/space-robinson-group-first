using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minimum = -3.0f;
    public float maximum = 3.0f;

    private static float t = 0.0f;

    private void FixedUpdate()
    {
        Vector2 newPos = transform.localPosition;
        newPos.x = Mathf.Lerp(minimum, maximum, t);

        transform.localPosition = newPos;

        t += 0.5f * Time.fixedDeltaTime;

        if (t > 3.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
