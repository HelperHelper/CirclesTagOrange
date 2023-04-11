using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTagIndicator : MonoBehaviour
{

    public string[] tagsArray = new string[2];
    string newtag;
    // Start is called before the first frame update
    void Awake()
    {
       int  randomIndex = Random.Range(0, 2);
        string randomTag = tagsArray[randomIndex];
        if (randomIndex == 0)
        {
           newtag = gameObject.tag = "Corona";
        } 
        if(randomIndex == 1)
        {
            newtag = gameObject.tag = "NoCorona";
        }

    }
}
