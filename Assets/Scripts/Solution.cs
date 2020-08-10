using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Solution : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 50f;
    public int index = 0;

    private void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
    bool b = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !b)
        {
                GameConfiguration.Instance.letters[index].SetActive(true);
                other.GetComponent<FpsController>().StageController();
                SoundConfiguration.Instance.PlayCollectSound();
                Debug.Log("Counter : ");
                Destroy(gameObject);
            b = true;
        }
    }
}
