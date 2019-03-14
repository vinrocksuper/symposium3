using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool openable;
    public bool talks;

    public string message;

    public Animator anim;
    // Start is called before the first frame update
    // Update is called once per frame
    public void open()
    {
        anim.SetBool("open", true);
    }
    public void Talk()
    {
        Debug.Log(message);
    }
    
        
    
}
