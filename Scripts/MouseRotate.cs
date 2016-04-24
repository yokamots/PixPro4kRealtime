// Copyright (c) 2016 Yasuhide Okamoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php
using UnityEngine;

/// <summary>
/// The class to rotate a GameObject by mouse motions. 
/// </summary>
public class MouseRotate : MonoBehaviour
{
    /// <summary>
    /// The maximum pitch angle. 
    /// </summary>
    [SerializeField]
    float maxPitchAngle = 80;
    /// <summary>
    /// The sensitivity of the rotation for mouse motions in x and y directions. 
    /// </summary>
    [SerializeField]
    Vector2 mouseSensitivity = new Vector2(5, 5);

    Vector3 currentRotation = Vector3.zero;

    void Update()
    {
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");

        currentRotation.y = transform.localEulerAngles.y + mousex * mouseSensitivity.x;

        currentRotation.x += mousey * mouseSensitivity.y;
        currentRotation.x = -Mathf.Clamp(-currentRotation.x, -maxPitchAngle, maxPitchAngle);

        transform.localEulerAngles = currentRotation;
    }
}
