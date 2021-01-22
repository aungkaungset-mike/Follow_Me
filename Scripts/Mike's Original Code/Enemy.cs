using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int dmg;
    public GameObject Selfexplode;
    public GameObject Playexplode;
    //public GameObject pop;
    public AudioClip popAudio;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Instantiate(pop, transform.position, Quaternion.identity);
            AudioManager.instance.PlayAudio(popAudio, true);
            Instantiate(Selfexplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            //Instantiate(pop, transform.position, Quaternion.identity);
            AudioManager.instance.PlayAudio(popAudio, true);
            Instantiate(Playexplode, transform.position, Quaternion.identity);
            //other.GetComponent<PlayerCon>().currentHp -= dmg;
            //HpBar.hp -= 10f;
            if (other.GetComponent<PlayerCon>() != null)
                other.GetComponent<PlayerCon>().TakeDamage(dmg);

            Destroy(gameObject);
        }

    }

}
