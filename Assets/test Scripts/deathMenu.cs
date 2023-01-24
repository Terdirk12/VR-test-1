using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    public void toggleDeathMenuOn()
    {
        gameObject.SetActive(true);
    }
    public void toggleDeathMenuOff()
    {
        gameObject.SetActive(false);
    }
}
