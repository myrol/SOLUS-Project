using UnityEngine;

public class SteampunkStoryHolder : MonoBehaviour
{
    public int progress; //0 = begin, 1 = valve,

    public void addProgress()
    {
        progress += 1;
    }
    public int getProgress()
    {
        return progress;
    }
}