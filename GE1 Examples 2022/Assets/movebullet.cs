using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed ;
    }
}
