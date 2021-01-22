using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCon : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    //public GameObject res;
    public GameObject eat;
    public float scoreValue = 0;
    //public Text score;
    //public Text hscore;
    //public float hScoreValue = 0;
    //string hsc = "Highscore";
    private UIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //if(currentHp == 0)
        // {
        //     res.SetActive(true);
        //     Time.timeScale = 0;
        // }
        //else
        // {
        //     res.SetActive(false);

        // }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.7f, 4.1f), transform.position.z);
        //score.text = scoreValue + "";

        uIController.UpdateScoreText(scoreValue);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Eat")
        {
            scoreValue += 1;
        }
    }
    private void Awake()
    {
        //instance = this;

        Time.timeScale = 1;

        uIController = FindObjectOfType<UIController>();

        //score.text = scoreValue + "";

        //hScoreValue = PlayerPrefs.GetFloat(hsc, 0f);
    }

    /// <summary>
    /// Take damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        //HpBar.hp -= 10;//Not good practice though It can cause problems for larger games
        FindObjectOfType<HpBar>().hp -= 10f;
        if (currentHp <= 0)
        {
            Time.timeScale = 0;
            uIController.ShowGameOverUI(scoreValue);
            Destroy(gameObject);
        }
    }
    //private void OnDisable()
    //{
    //    if (scoreValue > hScoreValue)
    //    {
    //        PlayerPrefs.SetFloat(hsc, scoreValue);
    //    }
    //}

}


