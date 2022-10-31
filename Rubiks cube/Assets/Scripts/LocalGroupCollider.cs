using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGroupCollider : MonoBehaviour
{
    public RubikGroup rubikGroupScript;
    public Transform old_Parent;

    private List<Transform> currentGroup =new List<Transform>();
   
    private Transform currentMiddle_Cube;

    Vector3 originalPosition;
    Quaternion originalRotation;

    private void Start()
    {
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("middle cube"))
        {
            currentMiddle_Cube = other.gameObject.transform;
        }
        else
            currentGroup.Add(other.gameObject.transform);

    }

    public void SetLocalGroup()
    {
        ChangeParent();
        SetOriginalPosition();
        SetMiddleCube();
        Invoke("ClearMiddleCube", 0.4f);

    }


    void ChangeParent()
    {
        foreach (Transform trans in currentGroup)
        {
            trans.parent = currentMiddle_Cube;

        }     
    }

    void SetMiddleCube()
    {
        rubikGroupScript.SetCurrentMiddleCube(currentMiddle_Cube);
    }

    void ClearMiddleCube()
    {
        for (int i = 0; i < currentGroup.Count; i++)
        {
            currentGroup[i].parent = old_Parent;
        }
        currentGroup.Clear();

        currentMiddle_Cube = null;
    }

    void SetOriginalPosition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}