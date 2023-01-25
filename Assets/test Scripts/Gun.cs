using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 100f;
    public ParticleSystem muzzleFlash;

    float timer = 0.1f;
    private Animator animator;
    private Interactable interactable;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volumeScale = 1.5f;
    public bool autoFire;
    public float fireRate = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;


            if (autoFire)
            {
                if (fireAction[source].state)
                {
                    AutoFire();
                }
            }
            else
            {
                if (fireAction[source].stateDown)
                {
                    Fire();
                }
            } 
        }
    }

    void Fire()
    {
        Rigidbody bulletrb = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Rigidbody>();
        bulletrb.velocity = barrelPivot.forward * shootingSpeed;
        muzzleFlash.Play();
        audioSource.PlayOneShot(audioClip, volumeScale);
    }

    void AutoFire()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Rigidbody bulletrb = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Rigidbody>();
            bulletrb.velocity = barrelPivot.forward * shootingSpeed;
            muzzleFlash.Play();
            audioSource.PlayOneShot(audioClip, volumeScale);
            timer = 0;
        }
    }
}
