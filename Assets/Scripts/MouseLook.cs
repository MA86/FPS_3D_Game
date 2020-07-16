using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Publics
    public float MouseSensitivity = 6;
    public RotationAxis Axis;

    // Privates
    private float xAxisRotationMax = 60f;
    private float xAxisRotationMin = -60f;
    private float angle = 0;

    // Enum needed to allow selection of axis of rotation
    public enum RotationAxis { AxisX = 1, AxisY = 2 }


    void Update()
    {
        // *** Rotate object around its Y-axis in response to horizontal mouse move ***
        if (this.Axis.Equals(RotationAxis.AxisY))
        {
            // Get mouse's delta x (direction of mouse move, i.e., left or right)
            float mouseDelta = Input.GetAxis("Mouse X");

            // Multiply it by sensitivity
            this.angle = mouseDelta * this.MouseSensitivity;

            // Rotate object by this angle
            this.transform.Rotate(0f, this.angle, 0f, Space.Self);
        }

        // *** Rotate object around its X-axis in response to vertical mouse move ***
        if (this.Axis.Equals(RotationAxis.AxisX))
        {
            // Get mouse's delta y, increment it to angle
            float mouseDelta = Input.GetAxis("Mouse Y");
            this.angle += (mouseDelta * this.MouseSensitivity) * (-1);

            // Make sure the angle is within min and max
            this.angle = Mathf.Clamp(this.angle, this.xAxisRotationMin, this.xAxisRotationMax);

            // localEulerAngle variable below takes an angle in the form of a vector                
            this.transform.localEulerAngles = new Vector3(this.angle, 0f, 0f);
        }
    }
}
