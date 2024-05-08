using UnityEngine;
using UnityEngine.Events;

public class CameraContoller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        // Setting camera on player
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}