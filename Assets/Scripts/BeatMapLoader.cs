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

    void LoadBeatMapFromTextAsset(TextAsset file)
    {
        string[] lines = file.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        beatEvents.Clear();

        foreach (string line in lines)
        {
            if (double.TryParse(line.Trim(), out double beat))
            {
                beatEvents.Add(new BeatEvent(beat));
            }
            else
            {
                Debug.LogWarning("Invalid beat line: " + line);
            }
        }

        Debug.Log("Loaded " + beatEvents.Count + " beats.");

        foreach (BeatEvent beatEvent in beatEvents)
        {
            Debug.Log("Beat Loaded: " + beatEvent.beatTime);
        }
    }
}