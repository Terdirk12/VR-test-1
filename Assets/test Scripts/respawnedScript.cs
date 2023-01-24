using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnedScript : MonoBehaviour
{
    int respawned;
    // Start is called before the first frame update
    void Start()
    {
        respawned = PlayerPrefs.GetInt("Respawned");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
