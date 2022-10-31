using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwipeDetection : MonoBehaviour
{
    public RubikGroup rubikGroup;

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


     public LayerMask layer;

    public RaycastHit hit;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, layer))
            {
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            //save began touch 2d point
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                rubikGroup.SetColliderPosition(true, hit.transform.position, hit.transform.forward,-90,CurrentSwipe.Up);
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                rubikGroup.SetColliderPosition(true, hit.transform.position, hit.transform.forward,90,CurrentSwipe.Down);
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
               // rubikGroup.SetColliderPosition(false, hit.transform.position, hit.transform.forward);
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
              //  rubikGroup.SetColliderPosition(false, hit.transform.position, hit.transform.forward);
            }
        }
    }

   
}

