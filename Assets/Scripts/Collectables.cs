using UnityEngine;

public class Collectables : MonoBehaviour
{
    private int starPoints = 0;
    private int gemPoints = 0;

    public int StarPoints
    {
        get => starPoints;
        set => starPoints = value;
    }

    public int GemPoints
    {
        get => gemPoints;
        set => gemPoints = value;
    }
}