using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerRecycle : MonoBehaviour
{
    private RobotPickUpItem itemPickUp;
    public Transform player;

    [Header("Recycling Variables")]
    public float RecycleRadius;
    public Transform poopPosition;
    public GameObject recycledMaterial;

    void Start()
    {
        itemPickUp = player.GetComponent<RobotPickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, player.position) < RecycleRadius && itemPickUp.HasItem())
            {
                itemPickUp.RecycleItem();
                Instantiate(recycledMaterial, poopPosition.position, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, RecycleRadius);
    }
}
