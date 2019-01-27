using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice : MonoBehaviour {
    public string[] keywords;
    KeywordRecognizer recognizer;
    HashSet<string> unspoken;

	// Use this for initialization
	void Start () {
        recognizer = new KeywordRecognizer(keywords);
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        unspoken = new HashSet<string>();        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void StartRecognizing()
    {
        unspoken.Clear();
        for(int i = 0; i < keywords.Length; ++i)
        {
            unspoken.Add(keywords[i]);
        }
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        if (unspoken.Contains(args.text))
        {
            unspoken.Remove(args.text);
        }

        if (unspoken.Count == 0)
        {
            GameObject.FindWithTag("Player").SendMessage("Spoken");
            recognizer.Stop();
        }        
    }
}
