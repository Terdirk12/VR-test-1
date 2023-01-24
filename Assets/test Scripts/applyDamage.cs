using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
    }
}
