using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    // Start is called before the first frame update

    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        //Changing body type of duck from dynamic to static
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    //Called with event in Death Animation
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
