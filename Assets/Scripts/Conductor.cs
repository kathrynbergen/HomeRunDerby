using UnityEngine;

public class Conductor : MonoBehaviour
{
    public AudioSource SongAudioSource; // needed to play any audio in unity
    public float SongBpm; // can be adjusted based on the song we choose
    
    public static double SongPositionInBeats; // global clock
    
    private double songStartDspTime; // exact DSP tme when the song begins
    private double secondsPerBeat; // converts BPM to usable timing
    private bool songStarted = false;
    
    void Update()
    {
        if (!songStarted) return;

        double songPosition = AudioSettings.dspTime - songStartDspTime;
        SongPositionInBeats = songPosition / secondsPerBeat;
    }
    public void StartSong()
    {
        if (songStarted) return;
        
        secondsPerBeat = 60f / SongBpm; // calculates based on bpm
        
        double dspTime = AudioSettings.dspTime;

        // Small delay ensures stable scheduling
        double startDelay = 0.1f;

        songStartDspTime = dspTime + startDelay; 

        SongAudioSource.PlayScheduled(songStartDspTime); 

        songStarted = true;
    }
}