using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameUI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI count;
    [SerializeField]TextMeshProUGUI score;
    [SerializeField] Image gameoverpannel;
    [SerializeField] Button restartbutton;
    [SerializeField] GameObject maincharcter;
    void Awake()
    {
        gameoverpannel.gameObject.SetActive(false);
    }

    private void Start()
    {
        restartbutton.onClick.AddListener(()=>{ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        });
    }
    void Update()
    {
       
        counter();
        gameover();
    }
    void counter()
    {
     count.text = string.Format("{000}:{1:00}", gamestart.gamestarts.minutes(), gamestart.gamestarts.second());
    score.text ="Score:"+ movement.instance.scores().ToString();
    }
    void gameover()
    {
        if (gamestart.gamestarts.gameover())
        {
            gameoverpannel.gameObject.SetActive(true);
        }
      else if (maincharcter.transform.position.y < 0)
        {
           
            gameoverpannel.gameObject.SetActive(true);
            Destroy(maincharcter);
        }
        else { 
            gameoverpannel.gameObject.SetActive(false);        
        
        }

    }
}
