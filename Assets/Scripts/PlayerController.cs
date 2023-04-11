using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; protected set; }
    private Rigidbody playerRb;
    private GameManager gameManager;
    public float speed;
    public GameObject TagIndicator;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameObject.tag == "Corona")
        {
            TagIndicator.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive == true)
        {
            float forwardInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            TagIndicator.transform.position = transform.position + new Vector3(0, -0.08f, 0);

            if (forwardInput != 0 || horizontalInput != 0)
            {
                playerRb.AddForce(Vector3.forward * speed * forwardInput);
                playerRb.AddForce(Vector3.right * speed * horizontalInput);
            }
        }

        if (transform.position.y < -10)
        {
            gameManager.GameOver();
        }



    }

}
