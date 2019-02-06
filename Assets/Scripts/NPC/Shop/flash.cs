using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flash : MonoBehaviour
{

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    public GameObject selectedFlash;
    // Use this for initialization
    void Start()
    {
        
        StartCoroutine(SelectedItemEffectCoroutine());

    }

    IEnumerator SelectedItemEffectCoroutine()
    {
        
        while (UIMgr.instance.storeUiOn)
        {
            Color color = selectedFlash.GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedFlash.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedFlash.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}



