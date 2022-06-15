using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class KeypadSteampunk : MonoBehaviour
{
    public UnityEvent onCorrectInput;
    public TextMeshPro display;

    private const string WRONG_ANSWER = "ERROR";
    private const string RIGHT_ANWSWER = "CORRECT";
    private const string EMPTY = "";

    private bool solved = false;
    private bool temporaryLock = false;

    [SerializeField]
    public string answer;
    private string userInput = EMPTY;


    private void Awake()
    {
        userInput = EMPTY;
    }

    public void input(string number)
    {
        if (solved || temporaryLock) return;

        if (number.Equals("#"))
        {
            userInput = EMPTY;
            display.text = EMPTY;
            return;
        }
        if (number.Equals("*"))
        {
            userInput = userInput.Substring(0, userInput.Length - 1);
            display.text = userInput;
            return;
        }

        userInput += number;

        /*
         * Falls die Laenge der Eingabe der Laenge der Antwort entspricht,
         * soll geprueft werden, ob die Eingabe stimmt.
         * 
         * Falls nicht, soll auf dem Display "FALSCH" o.A. kurz erscheinen.
         */
        if (userInput.Length >= answer.Length)
        {
            if (userInput.Equals(answer) && GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().getProgress() == 1) // KORREKTE ANTWORT
            {
                AudioSource audioSource = GameObject.Find("furnace").GetComponent<AudioSource>();
                audioSource.Play();
                StartCoroutine(rightAnswer());
                float currentTime = 0;
                while (currentTime < 2f)
                {
                    currentTime += Time.deltaTime;
                    audioSource.volume = Mathf.Lerp(0f, 0.628f, currentTime / 2f);
                }
                solved = true;
            }
            else // FALSCHE ANTWORT
            {
                StartCoroutine(wrongAnswer());
            }
        }

        display.text = userInput;
    }

    IEnumerator wrongAnswer()
    {
        temporaryLock = true;

        yield return new WaitForSeconds(1);

        Color originalColor = display.color;
        display.text = WRONG_ANSWER;
        display.color = new Color(255, 0, 0);

        yield return new WaitForSeconds(1);

        temporaryLock = false;
        userInput = EMPTY;
        display.text = EMPTY;
        display.color = originalColor;
    }

    IEnumerator rightAnswer()
    {
        yield return new WaitForSeconds(1);

        display.characterSpacing = 0;
        display.text = RIGHT_ANWSWER;
        onCorrectInput.Invoke();
    }
}
