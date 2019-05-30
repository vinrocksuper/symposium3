using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Script : MonoBehaviour
{
    public DigitalClock c;
    public float runSpeed = 1/60000000;

    float horizontalMove = 0f;

    public Collider2D z;
    private bool m_FacingRight = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        if(c.hours >= 7 && !c.am || c.hours < 6 && c.am || c.hours == 12 && c.am)
        {
            if (transform.position.x < 23.13108)
            {
                transform.position += new Vector3(runSpeed * Time.deltaTime, 0, 0);
                if(m_FacingRight)
                {
                    Flip();
                }
                
            }
            if (GetComponent<SpriteRenderer>().enabled && !(transform.position.x < 23.13108))
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            if (!GetComponent<SpriteRenderer>().enabled)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (transform.position.x > 14.53)
            {
                transform.position += new Vector3(-runSpeed * Time.deltaTime, 0, 0);
                if (!m_FacingRight)
                {
                    Flip();
                }

            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, z);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
