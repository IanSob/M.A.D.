using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutScript : MonoBehaviour
{
    private float randomRotationZ;
    public float delay = 0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        randomRotationZ = Random.Range(1, 360);
        transform.Rotate(0, 0, randomRotationZ);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
