using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] int Speed;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,Speed));
    }
}
