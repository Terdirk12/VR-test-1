using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public int playerHealth = 3;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volumeScale = 1.5f, timeoutTime = 3f, cooldownTimer;
    public deathMenu deathMenu;
    public WinMenu winMenu;
    public Player player;
    public SteamVR_Action_Boolean buttonAPress;
    public bool playerWon, playerDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            deathMenu.toggleDeathMenuOn();
            playerDead = true;
        }

        if (playerDead || playerWon)
        {
            cooldownTimer = Time.deltaTime;
            if (cooldownTimer >= timeoutTime)
            {
                if (SteamVR_Actions.default_GrabPinch.GetState(SteamVR_Input_Sources.Any))
                {
                    winMenu.toggleWinMenuOff();
                    deathMenu.toggleDeathMenuOff();
                    playerHealth = 3;
                    cooldownTimer = 0f;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    Destroy(player.gameObject);
                }
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            playerHealth--;
            audioSource.PlayOneShot(audioClip, volumeScale);
        }
    }
}
