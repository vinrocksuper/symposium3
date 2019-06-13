using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
    public Sprite dry;
    public Sprite watered;
    public Sprite growing;
    public Sprite grown;
    public seed sd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sd.daysToGrow ==0)
        {
            this.GetComponent<SpriteRenderer>().sprite = grown;
        }
        else if(sd.daysToGrow <3)
        {
            this.GetComponent<SpriteRenderer>().sprite = growing;
        }
        
    }
    public void water()
    {
        this.GetComponent<SpriteRenderer>().sprite = watered;
    }
    public void Dry()
    {
        this.GetComponent<SpriteRenderer>().sprite = dry;
    }
}
