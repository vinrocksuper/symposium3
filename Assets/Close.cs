using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    private void Start()
    {
        UI2.GetComponent<CanvasGroup>().alpha = 0f;
        UI2.GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    private void OnTriggerExit2D()
    {
        UI.SetActive(false);
        UI2.SetActive(false);

    }
}
