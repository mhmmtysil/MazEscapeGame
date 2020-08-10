using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    bool b = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !b)
        {
            SoundConfiguration.Instance.PlaySpeedSound();
            Destroy(gameObject);
            other.GetComponent<FpsController>().walkSpeed += 1;
            b = true;
        }
    }
}
