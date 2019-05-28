using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Script : MonoBehaviour
{
    public DigitalClock c;
    public float runSpeed = 300f;

    float horizontalMove = 0f;

    public Collider2D z;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(c.hours == 7 && !c.am)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, z);
        }
    }
}
