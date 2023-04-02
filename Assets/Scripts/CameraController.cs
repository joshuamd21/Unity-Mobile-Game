using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        moveCamera();
    }
    private void moveCamera()
    {
        Vector3 newPosition = new Vector3(0, 0, -10);
        newPosition.x = 10.0f / 23.5f * player.transform.position.x;
        newPosition.y = 17.5f / 23.5f * player.transform.position.y;
        transform.position = newPosition;
    }
}
