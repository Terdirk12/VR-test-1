using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    public bool leverFlicked;
    public Door door;

    // Update is called once per frame
    void Update()
    {
        if (leverFlicked) door.OpenDoor();
    }
}
