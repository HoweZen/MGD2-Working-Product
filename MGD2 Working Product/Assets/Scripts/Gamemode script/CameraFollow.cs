using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    Vector3 offset;

    private void Start()
    {
        //make camera follow player
        offset = transform.position - player.position;
    }

    private void Update()
    {
        //make camera lock in place or position
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
