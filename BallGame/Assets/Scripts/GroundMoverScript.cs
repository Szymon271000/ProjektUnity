using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoverScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Invoke("MoveGround", 0.5f);
    }

    public void MoveGround()
    {
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 63f);
    }
}
