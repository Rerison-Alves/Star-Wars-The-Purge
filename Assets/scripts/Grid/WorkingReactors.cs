using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingReactors : MonoBehaviour
{
    public List<GameObject> reactors = new List<GameObject>();
    public GameObject cardPrefab;

    bool dropeed;

    // Update is called once per frame
    void Update()
    {
        if(reactors.Count == 0 && !dropeed)
        {
            Instantiate(cardPrefab, transform.position, transform.rotation);
            dropeed = true;
        }
    }

    public void RemoveReactor(GameObject reactor)
    {
        reactors.Remove(reactor);
    }
}
