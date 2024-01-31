using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(_target.transform.position);
    }
}
