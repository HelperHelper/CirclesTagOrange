using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private GameManager gameManager;
    public GameObject TagIndicator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameObject.tag == "Corona")
        {
            TagIndicator.gameObject.SetActive(true);
           // Debug.Log("El jugador tiene el tag de: " + gameObject.tag);
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            TagIndicator.transform.position = transform.position + new Vector3(0, -0.08f, 0);
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
      

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

      //  Debug.Log("que nombre tiene este enemigo de tag: " + gameObject.tag);

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NoCorona") && gameObject.tag == "Corona")
        {
            gameObject.tag = "NoCorona";
            TagIndicator.gameObject.SetActive(false);
            player.tag = "Corona";
            PlayerController.Instance.TagIndicator.SetActive(true);
           
        } else
        if (collision.gameObject.CompareTag("Corona") && gameObject.tag == "NoCorona")
        {
            gameObject.tag = "Corona";
            TagIndicator.gameObject.SetActive(true);
            player.tag = "NoCorona";
            PlayerController.Instance.TagIndicator.SetActive(false);
            
        }

    }
}
