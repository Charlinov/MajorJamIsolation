using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPickUpItem : MonoBehaviour
{
    public Transform pickUpLocation;
    public float radius;

    private Transform objectInHands;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            if (objectInHands)
            {
                objectInHands.GetComponent<BoxCollider>().enabled = true;
                objectInHands = null;
            }
            else
            {
                objectInHands = CheckItemIsAvailable();
            }
        }
        if (objectInHands)
        {
            Debug.Log("Item in hands");
            objectInHands.GetComponent<BoxCollider>().enabled = false;
            objectInHands.transform.position = pickUpLocation.position;
        }
    }

    Transform CheckItemIsAvailable()
    {
        RaycastHit[] objectsAtHands = Physics.SphereCastAll(pickUpLocation.position, radius, Vector3.forward);
        Debug.Log(objectsAtHands.Length + " items found.");
        foreach(RaycastHit rayCastHit in objectsAtHands)
        {
            if(rayCastHit.transform.CompareTag("Trash"))
            {
                Debug.Log("Trash found!");
                return rayCastHit.transform;
            }
        }
        return null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(pickUpLocation.position, radius);
    }
}
