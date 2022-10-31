using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentSwipe
{
    Up,
    Down,
    Left,
    Right
};

public class RubikGroup : MonoBehaviour
{
    public Transform verticalGroupCollider;

    public Transform horizontalGroupCollider;

    public LocalGroupCollider verticalColliderScript;


    public CurrentSwipe currentSwipe;

    public Transform cubeToRotate;

    public void SetColliderPosition(bool isVertical, Vector3 position,Vector3 roatationAngle,float moveAngle,CurrentSwipe swipe)
    {
        // According to the swipe Setting my Collider Rotation

        currentSwipe = swipe;

        if (isVertical)
        {
            verticalGroupCollider.transform.position = position;
            verticalGroupCollider.transform.eulerAngles = roatationAngle*90;
            Invoke("setCubeMovement", 0.4f);
        }

        else
        {
            horizontalGroupCollider.transform.position = position;
            verticalGroupCollider.transform.eulerAngles = roatationAngle*90;
        }
    }

    public void SetCurrentMiddleCube(Transform currentCube)
    {
        cubeToRotate = currentCube;
        RotateMiddleCube();
    }


    void setCubeMovement()
    {
        verticalColliderScript.SetLocalGroup();
    }

    void RotateMiddleCube()
    {
        switch (currentSwipe)
        {
            case CurrentSwipe.Up:
                cubeToRotate.GetComponent<MiddleCube>().RotateCube(new Vector3(90,0,0));
                break;
        }
        
    }
   

}
