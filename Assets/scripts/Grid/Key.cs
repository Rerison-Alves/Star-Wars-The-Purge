using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Room1, 
        Room2, 
        Room3
    }

    public KeyType GetKeyType() 
    { 
        return keyType; 
    }
}
