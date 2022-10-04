using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

       
        float radius = 1.5f;
        for (float x = 1; x < 10; x++)
        {
            for (float i = 0; i < 360; i += 30/(x/2))
            {

                Vector2 spawnPosition;
                float angle = i * Mathf.Deg2Rad;

                spawnPosition.x = (x * Mathf.Cos(angle)) + gameObject.transform.position.x;
                spawnPosition.y = (x * Mathf.Sin(angle)) + gameObject.transform.position.x;

                Instantiate(prefab, spawnPosition, Quaternion.identity);

            }
        }


}


    // Update is called once per frame
    void Update()
    {

    }
}
