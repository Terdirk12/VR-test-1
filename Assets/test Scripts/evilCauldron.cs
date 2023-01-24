using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilCauldron : MonoBehaviour
{
    public WinMenu winMenu;

    public void Start()
    {
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
