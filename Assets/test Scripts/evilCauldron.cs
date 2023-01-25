using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilCauldron : MonoBehaviour
{
    public WinMenu winMenu;
    public playerScript Player;

    void Start()
    {    
        Player.playerWon = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            winMenu.toggleWinMenuOn();
            Destroy(this.gameObject);
        }
    }
}
