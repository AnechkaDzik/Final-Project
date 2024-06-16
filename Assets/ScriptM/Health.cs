using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        CurrentHealth = PlayerPrefs.GetFloat("health");
        if (CurrentHealth == 0)
        {
            CurrentHealth = startingHealth;
        }
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, startingHealth);
        PlayerPrefs.SetFloat("health", CurrentHealth);
        if (CurrentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<playermovement>().enabled = false;
                dead = true;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("danger"))
        {
            TakeDamage(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("danger"))
        {
            TakeDamage(1);
        }
    }
}