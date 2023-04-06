using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField, Range(0.0f,100.0f)]
    private float _amplitude = 5.0f;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Color _color;

    private Vector3 _startPosition;
    private void Start()
    {
        _startPosition = transform.position;
    }
    private void Update()
    {
        transform.position = _startPosition + _direction * Mathf.Sin(Time.timeSinceLevelLoad) * _amplitude;
    }
    private void OnDrawGizmos()
    {
        Vector3 originPosition;
        if (Application.isPlaying)
        {
            originPosition = _startPosition;
        }
        else
        {
            originPosition = transform.position;
        }
        Vector3 aPosition = originPosition + _direction * _amplitude;
        Vector3 bPosition = originPosition - _direction * _amplitude;
        Gizmos.color = _color;
        Gizmos.DrawSphere(aPosition, 0.3f);
        Gizmos.DrawSphere(bPosition, 0.3f);
        Gizmos.DrawLine(aPosition, bPosition);
        
    }
   
}
