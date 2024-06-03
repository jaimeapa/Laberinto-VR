using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public GameObject reticula;
    public Rigidbody playerRb;
    public bool isPlaying = false;
    public Button button;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        reticula = GameObject.Find("Reticula");
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            Vector3 direction = (reticula.transform.position - transform.position).normalized;
            float x = direction.x;
            float y = direction.y;
            playerRb.AddForce(new Vector3(x,y,0) * speed);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Finish Line"))
        {
            Destroy(gameObject);
            Debug.Log("You Win!");
        }
    }
    
    public void StartGame()
    {
        isPlaying = true;
        menu.gameObject.SetActive(false);
    }
}
