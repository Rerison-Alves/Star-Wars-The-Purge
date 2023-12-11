using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorHealth : MonoBehaviour
{
    Animator animator;
    public int health = 20;

    public AudioSource machineSound;
    public AudioSource explosionSound;

    public GameObject effectExplosion;
    public float delayeffect = 1.0f;

    public WorkingReactors WorkingReactors;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        if (health <= 0) return;

        health -= damage;

        if (health <= 0) DestroyReactor();
    }

    private void DestroyReactor()
    {
        animator.SetTrigger("Destroy");
        explosionSound.Play();
        machineSound.Stop();
        WorkingReactors.RemoveReactor(gameObject);
        GameObject effect = Instantiate(effectExplosion, transform.position, transform.rotation);
        StartCoroutine(DestroyEffect(effect));
    }

    IEnumerator DestroyEffect(GameObject effect)
    {
        yield return new WaitForSeconds(delayeffect);
        Destroy(effect);
    }
}
