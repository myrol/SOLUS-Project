using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    /*
     * Tutorial: https://youtu.be/1NW0BYn5KfE
     */

    //Subtitle Variables
    private const float _RATE = 44100.0f;

    private AudioClip dialogueAudio;
    private AudioSource audio;

    private string displaySubtitle;

    private string[] fileLines;
    private List<string> subtitleLines;         // Die einzelnen Lines in der .txt Datei
    private List<string> subtitleTimingStrings; // Geparste Strings
    private List<float> subtitleTimings;        // Interpretierte floats

    private List<string> subtitleText;           // Der eigentliche Text

    private int nextSubtitle = 0;

    private GUIStyle subtitleStyle = new GUIStyle();

    public static DialogueManager Instance { get; private set; }

    public void Awake()
    {
        // Singleton (Es gibt nur eine Instanz von dieser Klasse)
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;

        // Fuer den Reverb
        gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<AudioReverbZone>();

        AudioReverbZone arz = gameObject.GetComponent<AudioReverbZone>();
        arz.reverbPreset = AudioReverbPreset.Room;
        arz.minDistance = 45f;
        arz.maxDistance = 45f;
    }

    public void BeginDialogue(AudioClip passedClip)
    {
        nextSubtitle = 0;
        dialogueAudio = passedClip;

        // Reset all lists
        subtitleLines = new List<string>();
        subtitleTimingStrings = new List<string>();
        subtitleTimings = new List<float>();
        subtitleText = new List<string>();

        // Get everything from the .txt file
        string subtitlesPath = "Audio/Dialogue/Subtitles/de/" + dialogueAudio.name;
        TextAsset temp = Resources.Load(subtitlesPath) as TextAsset;
        fileLines = temp.text.Split('\n');

        // Split subtitle related lines into different lists
        foreach(string line in fileLines)
        {
            subtitleLines.Add(line);
        }

        // Split out our timings and text
        for (int i = 0; i < subtitleLines.Count; i++)
        {
            string[] splitTemp = subtitleLines[i].Split('|');           // Split at Pipe: [0] = timing, [1] = text
            subtitleTimingStrings.Add(splitTemp[0]);                    // Add to plain Text timings
            // Convert into float and store in timings
            // System.Global...InvariantCulture ist fuer die Formatunterscheidung zwischen 3.1415 und 3,1415
            subtitleTimings.Add(float.Parse(subtitleTimingStrings[i], System.Globalization.CultureInfo.InvariantCulture)); 
            subtitleText.Add(splitTemp[1]);
        }

        // Set initial subtitle text
        if (subtitleText[0] != null)
        {
            displaySubtitle = subtitleText[0];
        }

        // Play the Audio
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = dialogueAudio;
        audio.Play();
    }

    private void OnGUI()
    {
        // make sure that we are using a proper dialogueAudio file
        if (dialogueAudio != null && audio.clip.name == dialogueAudio.name)
        {
            if (nextSubtitle > 0 && !subtitleText[nextSubtitle - 1].Contains("<break/>"))
            {
                GUI.depth = -1001;
                subtitleStyle.fixedWidth = Screen.width / 1.5f;
                subtitleStyle.wordWrap = true; // Falls es zu lang ist, soll es eine newLine machen
                subtitleStyle.alignment = TextAnchor.MiddleCenter;
                subtitleStyle.normal.textColor = Color.white;
                subtitleStyle.fontSize = Mathf.FloorToInt(Screen.height * 0.0225f);

                //Style
                Vector2 size = subtitleStyle.CalcSize(new GUIContent());
                // Drop Shadow
                GUI.contentColor = Color.black;
                GUI.Label(new Rect(Screen.width / 2 - size.x / 2 + 1, Screen.height/1.25f - size.y + 1, size.x, size.y), displaySubtitle, subtitleStyle);
                // Text
                GUI.contentColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - size.x / 2, Screen.height / 1.25f - size.y, size.x, size.y), displaySubtitle, subtitleStyle);
            }

            // Subtitle �ndern, basierend darauf, wo wir uns in der Audio befinden
            if (nextSubtitle < subtitleText.Count)
            {
                // timeSamples / _RATE ist eine Methode, um herauszufinden, wo man sich in der Audio befindet.
                if (audio.timeSamples/_RATE > subtitleTimings[nextSubtitle])
                {
                    displaySubtitle = subtitleText[nextSubtitle];
                    nextSubtitle++;
                }
            }

            if (!audio.isPlaying)
            {
                displaySubtitle = "";
            }
        }
    }
}
