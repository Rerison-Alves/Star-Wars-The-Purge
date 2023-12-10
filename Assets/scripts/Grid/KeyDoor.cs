using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Key.KeyType keyType;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public Key.KeyType GetKeyType() { 
        return keyType;
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
}
