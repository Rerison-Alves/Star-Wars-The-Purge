using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealth : MonoBehaviour
{
    public int health = 4;

    public Transform healthBar;
    public GameObject healthBarObject;

    Vector3 healthBarScale;
    public float healthPercent;

    public GameObject Blood;
    private bool damageBlock = false;
    private float delayDamage = 0.3f;

    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x/health;
    }

    void UpdateHealthBar()
    {
        healthBarScale.x = healthPercent * health;
        healthBar.localScale = healthBarScale;
    }

    public void Damage(int damage)
    {
        if(!damageBlock)
        {
            damageBlock = true;
            health -= damage;
            UpdateHealthBar();

            GameObject newblood = Instantiate(Blood, transform.position, Quaternion.identity);
            StartCoroutine(DestroyBlood(newblood));

            if (health <= 0)
            {
                Destroy(gameObject);
                if(cardPrefab!=null) { DropCard(); }
            }
        }
        
    }

    public IEnumerator DestroyBlood(GameObject blood)
    {
        yield return new WaitForSeconds(delayDamage);
        Destroy(blood);
        damageBlock = false;
    }

    private void DropCard()
    {
        Instantiate(cardPrefab, transform.position, transform.rotation);
    }

}
