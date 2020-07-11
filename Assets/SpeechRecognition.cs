using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

/// <summary>
/// see here https://lightbuzz.com/speech-recognition-unity/
/// </summary>
public class SpeechRecognition : MonoBehaviour
{
    public List<string> availableKeywords;

    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    public Text results;

    protected PhraseRecognizer recognizer;
    protected string word = "";

    private string[] keywords = new string[6];

    private void Start()
    {
        if (availableKeywords.Count < 5)
            throw new System.Exception("need at least 5 keywords");

        // Random word choice from the available keywords
        List<int> buffer = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int idx = Random.Range(0, availableKeywords.Count);

            while (buffer.Contains(idx))
                idx = Random.Range(0, availableKeywords.Count);

            keywords[i] = availableKeywords[idx];
            buffer.Add(idx);
        }

        keywords[5] = "no";


        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log(recognizer.IsRunning);
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        playerMovement movement = (GetComponent<playerMovement>() as playerMovement);

        if (word == keywords[0])
            movement.GoLeft();
        else if (word == keywords[1])
            movement.GoRight();
        else if (word == keywords[2])
            movement.GoUp();
        else if (word == keywords[3])
            movement.GoDown();
        else if (word == keywords[4])
            movement.Stop();
        else if (word == keywords[5])
            movement.Revert();
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
