using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class CameraMovement : MonoBehaviour
{
    public Transform targetTransform;

    float rotation_Value = 0;
    Vector3 velocity = Vector3.zero;

    readonly float horizontalRotationSpeed = 220;
    readonly float verticalRotationSpeed = 300;

    readonly float mouseVerticalThreshold = 0.2f;
    readonly float verticalRotationLimit =92;

    float deltaRotaion = 2;


    // Update is called once per frame

    void Update()
    {
        // For Rotation
        if (Input.GetMouseButton(1))
        {
            //For Left Right Rotation 
           targetTransform.localEulerAngles = Vector3.SmoothDamp(this.transform.localEulerAngles,
                new Vector3(this.transform.localEulerAngles.x,targetTransform.localEulerAngles.y +
                Input.GetAxis("Mouse X") * horizontalRotationSpeed,targetTransform.localEulerAngles.z), ref velocity, 0.1f);

            if (Input.GetAxis("Mouse Y") > mouseVerticalThreshold)
            {
                //Up
                if (rotation_Value > -verticalRotationLimit)
                {
                    rotation_Value -= deltaRotaion;
                   targetTransform.Rotate(verticalRotationSpeed * Time.deltaTime, 0, 0,Space.World);

                }

            }


            if (Input.GetAxis("Mouse Y") < -mouseVerticalThreshold)
            {
                //Down
                if (rotation_Value < verticalRotationLimit)
                {
                   targetTransform.Rotate(-verticalRotationSpeed * Time.deltaTime, 0, 0,Space.World);
                    rotation_Value += deltaRotaion;
                }
            }

        }
    }

}
