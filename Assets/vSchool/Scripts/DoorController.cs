using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<string> TagsActivation;
    private Animator animator;
    private bool isOpened;
    private AudioSource Trapdoor_sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Trapdoor_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (TagsActivation.Contains(other.tag))
        {
            isOpened = true;
            Trapdoor_sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TagsActivation.Contains(other.tag))
        {
            isOpened = false;
            Trapdoor_sound.Play();
        }
    }

}
