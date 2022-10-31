using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationInput : MonoBehaviour
{
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Transform target;

    float speed = 200;

    bool isLock = false;

    // Update is called once per frame
    void Update()
    {

        Swipe();

        if (transform.rotation != target.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        }

    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {

            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //save began touch 2d point

        }
        if (Input.GetMouseButtonUp(1))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }

            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }

            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90 , Space.World);
            }

            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
            }

            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }

    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0;
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0;
    }

    /*       //swipe left
        if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {

                    rubikCube.SetRotation(RubikRotation.Left);
                }
                //swipe right
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    rubikCube.SetRotation(RubikRotation.Right);
                }

                //swipe upLeft

            else if (currentSwipe.y > 0 && currentSwipe.x < 0)
            {
                    Debug.Log("LeftUp");
               // rubikCube.SetRotation(RubikRotation.LeftUp);
            }

            //swipe upRight

              else if (currentSwipe.y > 0 && currentSwipe.x > 0)
                {
                    Debug.Log("RightUp");
                   // rubikCube.SetRotation(RubikRotation.RightUp);
                }
                
                //swipe DownLeft

               else if (currentSwipe.y < 0 && currentSwipe.x < 0)
                {
                    Debug.Log("LeftDown");
                    //rubikCube.SetRotation(RubikRotation.LeftDown);
                }

                //swipe DownRight

               else if (currentSwipe.y < 0 && currentSwipe.x > 0)
                {
                    Debug.Log("RightDown");
                    //rubikCube.SetRotation(RubikRotation.RightDown);
                }

           // Invoke("ReleaseLock", 0.6f);
        }
        
    }*/

    void ReleaseLock()
    {
        isLock = false;
    }

}
