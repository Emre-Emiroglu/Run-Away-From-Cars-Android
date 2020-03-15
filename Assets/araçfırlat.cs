using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araçfırlat : MonoBehaviour
{
    public GameObject[] araçlar;
    public float başlangıçzamanı, atışsüresi;
    public GameObject snap;
    public float arabafırlatmahızı;
    public int fırlatılanarabasayısı;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ArabaFırlat",başlangıçzamanı,atışsüresi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ArabaFırlat()
    {
        int rng = Random.Range(0, araçlar.Length);
        float rngx = Random.Range(-3.7f, 3.7f);
        Vector3 pos = new Vector3(snap.transform.position.x+rngx, snap.transform.position.y, snap.transform.position.z-5.0f);
        GameObject araçclone = Instantiate(araçlar[rng], pos, Quaternion.identity);
        Rigidbody rb = araçclone.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -1) * arabafırlatmahızı;
        fırlatılanarabasayısı++;
        Destroy(araçclone, 8.0f);
    }

}
