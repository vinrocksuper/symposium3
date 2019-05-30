using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Script : MonoBehaviour
{
    public DigitalClock c;
    public float runSpeed = 1/60000000;
    public int friendship = 0;
    public int friendshipelevel = 0;
    float horizontalMove = 0f;
    public bool hasBeenTalkedTo = false;
    public Collider2D trigger;
    public Collider2D circle;
    private bool m_FacingRight = true;
    private InterObject io;
    private string[] Genericmessages = { "Good Morning.", "Howdy Partner! Pick up them seeds and start plantin!","It ain't much but its honest work" };
    private string[] NightMessages = { "Good Night Pardner!", "Imma hit the hay, See ya tomorrow!", "See ya!","It's gettin late, you should head home soon too" };
    
    // Start is called before the first frame update
    private void Start()
    {
        io = this.GetComponent<InterObject>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(c.hours >= 7 && !c.am || c.hours < 6 && c.am || c.hours == 12 && c.am)
        {
            io.message = NightMessages[(int)(Random.Range(0, NightMessages.Length))];
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
                changeFriendshipLevel();
                trigger.enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            io.message = Genericmessages[(int)(Random.Range(0, Genericmessages.Length))];
            if (!GetComponent<SpriteRenderer>().enabled)
            {
                trigger.enabled = true;
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
            Physics2D.IgnoreCollision(collision.collider, circle);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            io.Talk();
            hasBeenTalkedTo = true;
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

    private void changeDialogue()
    {

    }

    private void changeFriendshipLevel()
    {
        if(hasBeenTalkedTo)
        {
            friendship += 10;
            hasBeenTalkedTo = false;
        }
        else
        {
            friendship -= 5;
        }
    }
    /**
     * add gifting 
     * add shop
     * more dialogue? / seasonal dialogue
     * 
     * 
     * */
}
