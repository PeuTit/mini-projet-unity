using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchBehaviour : MonoBehaviour
{
    public List<GameObject> Ligths;
    public bool isLightOn;
    private bool playerInZone;
    private Animator animator;
    public GameObject textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            isLightOn = !isLightOn;
            animator.SetBool("isLightOn", isLightOn);
            gameObject.GetComponent<AudioSource>().Play();
            foreach (GameObject light in Ligths)
            {
                light.SetActive(!light.activeSelf);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            textToDisplay.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textToDisplay.SetActive(false);
            playerInZone = false;
        }
    }

}
