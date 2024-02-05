using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public string direction;
    Vector3 _direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        direction = direction.ToUpper();

        switch (direction)
        {
            case "X": _direction = Vector3.right; break;
            case "Y": _direction = Vector3.up; break;
            case "Z": _direction = Vector3.forward; break;
                default: _direction = Vector3.up; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
        transform.Rotate(_direction, rotationSpeed * Time.deltaTime);
    }
}