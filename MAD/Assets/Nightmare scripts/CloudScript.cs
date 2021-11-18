using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float randomRotationZ;
    private float Speed = -1;
    // Start is called before the first frame update
    void OnEnable()
    {
        randomRotationZ = Random.Range(1, 360);
        transform.Rotate(0, 0, randomRotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }
}
