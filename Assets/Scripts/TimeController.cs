using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI time, winText;

    private float remaining;
    private bool inProgress;
    private GameManager gameManager;
    [SerializeField] Button restartButton;


    private void Awake()
    {

        remaining = (min * 60) + seg;
    }

    private void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            remaining -= Time.deltaTime;
            if(remaining < 1)
            {
                gameManager.isGameActive = false;
                if (PlayerController.Instance.tag == "Corona")
                {
                    winText.gameObject.SetActive(true);
                    restartButton.gameObject.SetActive(true);
                }
                else
                {
                    gameManager.GameOver();
                }
            }
            int tempMin = Mathf.FloorToInt(remaining / 60);
            int tempSeg = Mathf.FloorToInt(remaining % 60);
            time.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);

        }
    }
}
