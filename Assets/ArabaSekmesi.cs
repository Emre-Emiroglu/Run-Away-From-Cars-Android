using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabaSekmesi : MonoBehaviour
{
    Rigidbody rb;
    public float minx, maxx;
    public float  maxy;
    public float minz, maxz;
    AudioSource seskaynağı;
    public AudioClip[] crashseleri;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        seskaynağı = GetComponent<AudioSource>();
       // BaşlangıçEtkisi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BaşlangıçEtkisi()
    {
        float rngx = Random.Range(minx, maxx);
        float rngy = Random.Range(maxy / 4, maxy);
        float rngz = Random.Range(minz, maxz);
        rb.AddForce(new Vector3(rngx, rngy, rngz), ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="yol")
        {
            int rng = Random.Range(0, crashseleri.Length);
            seskaynağı.PlayOneShot(crashseleri[rng]);
            float rngx = Random.Range(minx, maxx);
            float rngy = Random.Range(maxy/2, maxy);
            float rngz = Random.Range(minz, maxz);
            rb.AddForce(new Vector3(rngx, rngy, rngz),ForceMode.Force);
        }
        if (collision.gameObject.tag=="arka")
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
