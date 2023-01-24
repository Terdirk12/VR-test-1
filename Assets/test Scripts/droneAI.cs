using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneAI : MonoBehaviour
{
    public GameObject Player;
    private bool playerInVision;
    private Vector3 targetPosition;
    [SerializeField] Transform shootPoint;
    public Rigidbody projectile , rigidbody;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float bulletSpeed = 45, bulletLife = 25, timer, attackTimer = 0.5f, lookSpeed = 3f, attackDistance = 14, checkForPlayerDistance = 15, volumeScale = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        //Gets Rigidbody of gameobject, if null, create and add new.
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - new Vector3(transform.position.x, transform.position.y, transform.position.z)), lookSpeed * Time.deltaTime);
    }

    public void DetectPlayer()
    {
        //Raycast from this enemy to the player position. Checks if there are objects in the way, also has a max vision distance.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, checkForPlayerDistance))
        {
            Color color = Color.white;
            //If there are no objects in the way and player is visible:
            if (hit.transform == Player.transform)
            {
                color = Color.green;
                playerInVision = true;
                targetPosition = Player.transform.position;
                Attacking();
            }
            //Else there are objects in the way and player is not visible
            else
            {
                playerInVision = false;
                color = Color.red;
            }

            //Draw a debug ray from this enemy to the player, color depends on if the player is visible or not
            Debug.DrawRay(transform.position, Player.transform.position - transform.position, color);
        }
    }
    public void Attacking()
    {
        
        float distanceToTarget = Vector3.Distance(Player.transform.position, transform.position);
        if (distanceToTarget <= attackDistance)
        {
            timer += Time.deltaTime;
            if (timer > attackTimer)
            {
                timer = 0;
                Rigidbody bullet = (Rigidbody)Instantiate(projectile, shootPoint.position, transform.rotation);
                bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
                audioSource.PlayOneShot(audioClip, volumeScale);

                Destroy(bullet.gameObject, bulletLife);
            }
        }


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }
}
