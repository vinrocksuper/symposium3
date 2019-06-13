using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    
    public bool range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Interact") && range)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        range = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        range = false;
    }
}
