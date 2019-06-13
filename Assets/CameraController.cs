using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Barley Chrown");
        }
        offset = transform.position - player.transform.position;
    }
    private void Awake()
    {
        if(player==null)
        {
            player = GameObject.Find("Barley Chrown");
        }
        offset = transform.position - player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Barley Chrown");
        }
        transform.position = player.transform.position + offset;
    }
}
