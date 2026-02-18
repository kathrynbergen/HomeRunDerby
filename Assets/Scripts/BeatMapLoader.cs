using System.Collections.Generic;
using UnityEngine;

public class BeatMapLoader : MonoBehaviour
{
    public List<BeatEvent> beatEvents = new List<BeatEvent>();

    public TextAsset beatmapFile;

    void Start()
    {
        if (beatmapFile != null)
        {
            LoadBeatMapFromTextAsset(beatmapFile);
        }
        else
        {
            Debug.LogError("No beatmap file assigned!");
        }
    }
    void Update()
    {
        // this method is used to test - prints to terminal when the beat passes (when the user is supposed to press the button)
        // REMOVE THIS LATER - it changes "triggered" to true which would break future code - remove when ur done testing
        double currentBeat = Conductor.SongPositionInBeats;

        foreach (BeatEvent beatEvent in beatEvents)
        {
            // If this beat hasn't triggered yet
            // and the song has reached (or passed) its beat time
            if (!beatEvent.triggered && currentBeat >= beatEvent.beatTime)
            {
                beatEvent.triggered = true;
                Debug.Log("BEAT HIT at: " + beatEvent.beatTime + 
                          " | Song Position: " + currentBeat);
            }
        }
    }

    void LoadBeatMapFromTextAsset(TextAsset file)
    {
        string[] lines = file.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries); // reads beatmap file and splits into array where each index is a beat

        beatEvents.Clear();

        foreach (string line in lines)
        {
            if (double.TryParse(line.Trim(), out double beat))
            {
                beatEvents.Add(new BeatEvent(beat)); // stores beats as a BeatEvent - BeatEvent tracks the beatTime (int) and if it was triggered (boolean)
            }
            else // error catch
            {
                Debug.LogWarning("Invalid beat line: " + line);
            }
        }

        //Debug.Log("Loaded " + beatEvents.Count + " beats.");
        /*
        foreach (BeatEvent beatEvent in beatEvents)
        {
            Debug.Log("Beat Loaded: " + beatEvent.beatTime);
        }
        */
    }
}