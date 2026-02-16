public class BeatEvent
{
    public double beatTime;
    public bool triggered;

    public BeatEvent(double beat)
    {
        beatTime = beat;
        triggered = false;
    }
}