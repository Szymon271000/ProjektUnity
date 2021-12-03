using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    float offSet; // distance between ball and camera
    // Start is called before the first frame update
    void Start()
    {
        offSet = player.transform.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(0, gameObject.transform.position.y, player.gameObject.transform.position.z - offSet), Time.deltaTime * 100);
    }
}
