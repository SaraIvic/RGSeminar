using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coinCounter = 0;
    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    //Collecting coins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coinCounter++;
            coinsText.text = "Coins:" + coinCounter;
        }
    }
}
