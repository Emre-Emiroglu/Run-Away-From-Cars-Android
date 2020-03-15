using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Anamenu : MonoBehaviour
{
    public Toggle settings, sesaçkapa;
    public Slider sesvolume;
    public GameObject settingspaneli;
    public TextMeshProUGUI bestscoretext;
    // Start is called before the first frame update
    void Start()
    {
        settingspaneli.SetActive(false);
        bestscoretext.text = "Best Score: " + ((int)PlayerPrefs.GetFloat("bestscore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (settings.isOn==true)
        {
            settingspaneli.SetActive(true);
            settingspaneli.GetComponent<Animator>().SetBool("kapat", false);
        }
        else
        {
            settingspaneli.GetComponent<Animator>().SetBool("kapat", true);
          
        }
        if (sesaçkapa.isOn==true)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = sesvolume.value;
        }
    }
   
}
