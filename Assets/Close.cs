using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;

    private void OnTriggerExit2D()
    {
        UI.SetActive(false);
        UI2.SetActive(false);
    }
}
