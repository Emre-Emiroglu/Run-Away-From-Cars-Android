using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Karakter : MonoBehaviour
{
    public bool gameover, win;
    public GameObject kanefekti, winefekti, gameoverpaneli,üstpanel, butonlar, winpaneli;
    public TextMeshProUGUI introtext;
    Rigidbody rb;
    public float gameoverdelay, itmegücü;
    AudioSource seskaynağı;
    public AudioClip gameoversesi, winsesi;
    // Start is called before the first frame update
    void Start()
    {
        seskaynağı = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        kanefekti.SetActive(false);
        winefekti.SetActive(false);
        Cursor.visible = false;
        InvokeRepeating("GeriFırlatma", 5.0f, 5.0f);
        gameoverpaneli.SetActive(false);
        winpaneli.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   void GeriFırlatma()
    {
        rb.velocity = Vector3.forward * -itmegücü;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="araba")
        {
            gameover = true;
           StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        kanefekti.SetActive(true);
        rb.velocity = transform.up * (itmegücü*5);
        seskaynağı.PlayOneShot(gameoversesi);
        yield return new WaitForSeconds(gameoverdelay);
        gameoverpaneli.SetActive(true);
        üstpanel.SetActive(false);
        butonlar.SetActive(false);
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="win")
        {
            win = true;
            StartCoroutine(Winning());
        }
    }
    IEnumerator Winning()
    {
        rb.velocity = transform.up * (itmegücü * 3);
        seskaynağı.PlayOneShot(winsesi);
        winefekti.SetActive(true);
        yield return new WaitForSeconds(gameoverdelay);
        winpaneli.SetActive(true);
        üstpanel.SetActive(false);
        butonlar.SetActive(false);
        Time.timeScale = 0f;
    }
}
