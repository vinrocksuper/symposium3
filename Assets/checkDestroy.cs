using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find(gameObject.name)
                && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }

    }
}
