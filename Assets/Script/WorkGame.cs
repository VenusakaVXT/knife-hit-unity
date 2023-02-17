using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkGame : MonoBehaviour
{
    // Design the model and then the stats will be loaded in Unity
    [System.Serializable]
    private class RotationWood
    {
        public float speedRotation;
        public float timeRotation;
    }
    [SerializeField]
    private RotationWood[] patternWood;
    private WheelJoint2D wheelJoint;
    private JointMotor2D motorJoint;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motorJoint = new JointMotor2D();
        // Start accessing the interface PlayRotationPattern()
        StartCoroutine("PlayRotationPattern");
    }

    // Model interface for wooden panels
    private IEnumerator PlayRotationPattern()
    {
        int indexRotation = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            motorJoint.motorSpeed = patternWood[indexRotation].speedRotation;
            // default value : 10000
            motorJoint.maxMotorTorque = 10000;
            wheelJoint.motor = motorJoint;

            yield return new WaitForSecondsRealtime(patternWood[indexRotation].timeRotation);
            indexRotation++;
            indexRotation = indexRotation < patternWood.Length ? indexRotation : 0;
        }    
    }    
}
