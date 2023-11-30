using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public Image healhtBar;
    public List<Sprite> choices;

    private Animator animator;
    private PlayerMoviment playerMoviment;

    private float delayDamage = 0.3f;
    public float delayDeath = 3f;

    public AudioSource damagePlayer;

    public GameObject menuMorte;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerMoviment = GetComponent<PlayerMoviment>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0) 
        { 
            healhtBar.sprite = choices[health];
        }
        else
        {
            healhtBar.sprite = choices[0];
        }
        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Damage");
        playerMoviment.speed = 0;
        playerMoviment.activeMoveSpeed = 0;
        damagePlayer.Play();
        playerMoviment.attackblock = true;
        StartCoroutine(playerMoviment.DelayStop(delayDamage));
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(delayDamage);
        playerMoviment.speed = 0;
        playerMoviment.activeMoveSpeed = 0;
        playerMoviment.attackblock = true;
        playerMoviment.animator.SetTrigger("Death");
        StartCoroutine(DeathMenu());
    }

    public IEnumerator DeathMenu()
    {
        yield return new WaitForSeconds(delayDeath);
        menuMorte.SetActive(true);
    }
}
