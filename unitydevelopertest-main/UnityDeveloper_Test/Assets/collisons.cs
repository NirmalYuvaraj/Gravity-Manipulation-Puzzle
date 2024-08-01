using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] Image gameoverpannel;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "gameover")
        {
            gameoverpannel.gameObject.SetActive(true); 
        }
    }
}
