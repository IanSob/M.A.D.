using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private float randomRotationZ;
    private float Speed = 2;
    // Start is called before the first frame update
    void OnEnable()
    {
        randomRotationZ = Random.Range(1, 360);
        transform.Rotate(0, 0, randomRotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
}
