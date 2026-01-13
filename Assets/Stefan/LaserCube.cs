using UnityEngine;

public class LaserCube : MonoBehaviour
{
    public int id;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EyeLaser.laserHit += CubeReaction;
    }

    void OnDestroy()
    {
        EyeLaser.laserHit -= CubeReaction;
    }

    void CubeReaction(string name)
    {
        Debug.Log(name + "sayed by " + id);
    }
}
