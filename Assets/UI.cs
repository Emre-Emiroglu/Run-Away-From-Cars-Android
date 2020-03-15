using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class UI : MonoBehaviour
{
    public TextMeshProUGUI introtext, puantext, gameoverpuantext, winpuantext;
    araçfırlat araçfırlatcs;
    float gerisayım;
    public float puan;
    bool puanbaşlat;
    Karakter karaktercs;
    PostProcessVolume volume;
    DepthOfField blur=null;
    public float atışsüresi1, atışsüresi2, atışsüresi3, atışsüresi4;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out blur);
        blur.active=false;
        puan = 0;
        araçfırlatcs = GetComponent<araçfırlat>();
        gerisayım = araçfırlatcs.başlangıçzamanı;
        puanbaşlat = false;
        karaktercs = GameObject.Find("Karakter2").GetComponent<Karakter>();
    }

    // Update is called once per frame
    void Update()
    {
        gerisayım -= Time.deltaTime;
        introtext.text = ((int)gerisayım).ToString();
        if (gerisayım<=0)
        {
            gerisayım = 0;
            puanbaşlat = true;
            introtext.text = "Run !!!";
            StartCoroutine(İntroİşlemi());
        }
        PuanHesaplama(puanbaşlat);
        if (karaktercs.gameover==true || karaktercs.win == true)
        {
            gameoverpuantext.text = ((int)puan).ToString();
            winpuantext.text= ((int)puan).ToString();
            if (puan>PlayerPrefs.GetFloat("bestscore",0))
            {
                PlayerPrefs.SetFloat("bestscore", puan);
                PlayerPrefs.Save();
            }
            if (Time.timeScale==0)
            {
                blur.active = true;
            }

        }
    }
    IEnumerator İntroİşlemi()
    {
     yield return new WaitForSeconds(2.0f);
     introtext.enabled = false;
    }
    void PuanHesaplama(bool başlat)
    {
        if (başlat==true && karaktercs.gameover== false && karaktercs.win == false)
        {
            puan += Time.deltaTime;
            puantext.text = ((int)puan).ToString();
            if (araçfırlatcs.fırlatılanarabasayısı < 5)
            {
                araçfırlatcs.atışsüresi = atışsüresi1;
                puan += araçfırlatcs.fırlatılanarabasayısı * (0.2f);
            }
            if (araçfırlatcs.fırlatılanarabasayısı < 10)
            {
                araçfırlatcs.atışsüresi = atışsüresi2;
                puan += araçfırlatcs.fırlatılanarabasayısı * (0.3f);
            }
            if (araçfırlatcs.fırlatılanarabasayısı < 20)
            {
                araçfırlatcs.atışsüresi = atışsüresi3;
                puan += araçfırlatcs.fırlatılanarabasayısı * (0.4f);
            }
            if (araçfırlatcs.fırlatılanarabasayısı < 30)
            {
                araçfırlatcs.atışsüresi = atışsüresi4;
                puan += araçfırlatcs.fırlatılanarabasayısı * (0.5f);
            }
        }
    }
    public void Restart()
    {
        string sahne = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sahne);
        Time.timeScale = 1.0f;

    }
    public void Anamenu()
    {
        SceneManager.LoadScene("Sahne1");
    }
}
