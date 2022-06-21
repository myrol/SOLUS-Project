using UnityEngine;

public class StoryHolder : MonoBehaviour
{
    [SerializeField] public int steampunk; //0 = begin, 1 = valve, 2 = turbine
    [SerializeField] public int steampunk_furnace; //0 = begin, 1 = solved
    [SerializeField] public int steampunk_valve; //0 = begin, 1 = turned
    [SerializeField] public int steampunk_lever; //0 = begin, 1&2 = gears, 3 = electric

    public void resetSteampunk() { steampunk = 0; steampunk_furnace = 0; steampunk_valve = 0; steampunk_lever = 0; }
    public void addSteampunk() { steampunk += 1; }
    public void addSteampunkFurnace() { steampunk_furnace += 1; }
    public void addSteampunkValve() { steampunk_valve += 1; }
    public void addSteampunkLever() { steampunk_lever += 1; }
    public int getSteampunk() { return steampunk; }
    public int getSteampunkFurnace() { return steampunk_furnace; }
    public int getSteampunkValve() { return steampunk_valve; }
    public int getSteampunkLever() { return steampunk_lever; }
}