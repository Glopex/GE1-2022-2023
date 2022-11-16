using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatplayer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform lookat;
    bool playerIsVisible;
    [SerializeField] GameObject player;
    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    bool hasshot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("asdasdasdasdasd");
            playerIsVisible = true;
        }
    }

    private void Update()
    {
        if(playerIsVisible == true)
        {
            Debug.Log("siuum");
            var rotation = Quaternion.LookRotation(player.transform.position - gameObject.transform.position);
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed * Time.deltaTime);

            if(hasshot == false)
            {
                hasshot = true;
                StartCoroutine(shoot());
            }
            
        
        }
    }
    
    IEnumerator shoot()
    {
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(2f);
        hasshot = false;
    }
}
