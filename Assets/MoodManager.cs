using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer MoodLabel;

    private void OnTriggerEnter(Collider other)
    {
        print("collided");
        if (other.tag == "Player")
        {
            print("With player");
            MoodLabel.gameObject.SetActive(true);

            AudioManager.Instance.RandomizePitch("Zombie", 1.8f, 2.1f);
            AudioManager.Instance.PlayRandom("Zombie");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MoodLabel.gameObject.SetActive(false);
        }
    }
}