using System.Diagnostics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    public Vector3 offset;
    void Update()
    {
        //UnityEngine.Debug.Log(player.position);
        transform.position = player.position + offset;
    }
}
