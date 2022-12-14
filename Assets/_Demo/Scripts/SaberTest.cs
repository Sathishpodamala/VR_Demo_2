using Alpha.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberTest : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    void Update()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        //{
        //    if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
        //    {
        //        EventHandler.BroadCast(EventId.EVENT_ON_HIT_CUBE);
        //        Destroy(hit.transform.gameObject);
        //    }
        //}
        previousPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Cube"))
        {
            if (Vector3.Angle(transform.position - previousPos, collision.transform.up) > 130)
            {
                EventHandler.BroadCast(EventId.EVENT_ON_HIT_CUBE);
                Destroy(collision.gameObject);
            }
        }
    }

}
