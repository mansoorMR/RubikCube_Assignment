using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCube : MonoBehaviour
{

    public Transform target;

    private float speed =300;

    bool follow = false;

    public void Update()
    {
        if (transform.rotation != target.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
           
        }
    }

    public void RotateCube(Vector3 rotation)
    {
        this.enabled = true;
        target.Rotate(rotation, Space.World);
        Invoke("DisableScript", 0.4f);
    }

    void DisableScript()
    {
        this.enabled = false;
    }
}
