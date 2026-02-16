using UnityEngine;

public class Conductor : MonoBehaviour
{
    public AudioSource SongAudioSource; // needed to play any audio in unity
    public float SongBpm; // can be adjusted based on the song we choose
    public static double SongPositionInBeats; // global clock
    
    private double songStartDspTime; // exact DSP tme when the song begins
    private double secondsPerBeat; // converts BPM to usable timing

    void Start()
    {
        secondsPerBeat = 60f / SongBpm; // converts BPM to seconds per beat
        songStartDspTime = AudioSettings.dspTime; // stores song start time
        SongAudioSource.Play(); //starts song
    }

    void Update()
    {
        // calculates how many seconds passed since the song started
        double songPosition = AudioSettings.dspTime - songStartDspTime;
        // used to find current place in song
        SongPositionInBeats = songPosition / secondsPerBeat;
        
        Debug.Log("Current Beat: " + SongPositionInBeats);
    }
}