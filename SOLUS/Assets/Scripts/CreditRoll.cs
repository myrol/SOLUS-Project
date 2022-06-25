using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditRoll : MonoBehaviour
{
    public GameObject credits, logo, by;
    public int slow;

    public void roll()
    {
        StartCoroutine(Begin());
    }

    private IEnumerator Begin()
    {
        //alles aus
        logo.SetActive(false);
        by.SetActive(false);
        //start
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeInOutImg(logo));
        yield return new WaitForSeconds(5.5f);
        StartCoroutine(FadeInOut(by));
        yield return new WaitForSeconds(8.5f);

        credits.SetActive(true);
        byte elapsed = 255;
        int counter = 0;
        while (elapsed != 0)
        {
            counter++;
            if(counter % slow == 0)
            elapsed--;
            credits.GetComponent<Image>().color = new Color32(255, 255, 255, elapsed);
            yield return null;
        }
        credits.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeInOut(GameObject objectUsing)
    {
        objectUsing.SetActive(true);
        byte elapsed = 1;
        bool direction = true;
        while (elapsed != 0)
        {
            if (direction)
                elapsed++;
            else
                elapsed--;
            objectUsing.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, elapsed);
            if (elapsed == 255)
            {
                direction = false;
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }
        objectUsing.SetActive(false);
        yield return null;
    }

    private IEnumerator FadeInOutImg(GameObject objectUsing)
    {
        objectUsing.SetActive(true);
        byte elapsed = 1;
        bool direction = true;
        while (elapsed != 0)
        {
            if (direction && elapsed != 255)
                elapsed++;
            else
                elapsed--;
            objectUsing.GetComponent<Image>().color = new Color32(255, 255, 255, elapsed);
            if (elapsed == 255)
            {
                direction = false;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
        objectUsing.SetActive(false);
        yield return null;
    }
}