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
}
