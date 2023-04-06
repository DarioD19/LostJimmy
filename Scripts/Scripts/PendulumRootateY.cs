using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumRootateY : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _limitMovment;
    private float _random = 0f;


    // Update is called once per frame
    void Update()
    {
        float angle = _limitMovment * Mathf.Sin(Time.time + _random * _speed);
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }
}
