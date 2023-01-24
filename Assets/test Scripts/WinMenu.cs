using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void toggleWinMenuOn()
    {
        gameObject.SetActive(true);
    }
    public void toggleWinMenuOff()
    {
        gameObject.SetActive(false);
    }
}
