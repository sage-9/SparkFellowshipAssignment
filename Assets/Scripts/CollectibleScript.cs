using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    // animate the game object from -1 to +1 and back
    public float hoverRange = 1.0f;
    public float rotationSpeed = 90.0f;
    public float hoverSpeed = 1.0f;

    private float minimum;
    private float maximum;

    // starting value for the Lerp
    private float t = 0.0f;

    void Start()
    {
        float pos = transform.position.y;
        minimum = pos - hoverRange;
        maximum = pos + hoverRange;
    }

    // Update is called once per frame
    void Update()
    {
        Hover();
        Rotate();
    }

    void Hover()
    {
        // animate the position of the game object...
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t), transform.position.z);

        // .. and increase the t interpolater
        t += hoverSpeed * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

    void Rotate()
    {
        // rotate the game object around its Y axis at the specified speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
