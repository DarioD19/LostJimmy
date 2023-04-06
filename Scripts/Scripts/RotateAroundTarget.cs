using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    [SerializeField]
    private Vector3 _axis;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;

    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_target.position, _axis, _speed * Time.deltaTime);
    }
}
