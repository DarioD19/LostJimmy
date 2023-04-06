using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLearn : MonoBehaviour
{
    public Vector3 currentRotation;
    public Vector3 anglesToRotate;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation = new Vector3(currentRotation.x % 360, currentRotation.y % 360, currentRotation.z % 360);
        currentRotation = currentRotation + anglesToRotate * Time.deltaTime;
        this.transform.eulerAngles = currentRotation;
       
    }
}
