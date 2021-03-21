using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayTrigger : MonoBehaviour
{
    public GameObject Destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.transform.position = Destination.transform.position;
    }
}
