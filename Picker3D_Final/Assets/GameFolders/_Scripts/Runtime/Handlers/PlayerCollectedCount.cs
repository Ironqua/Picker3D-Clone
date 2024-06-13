using UnityEngine;

public class PlayerCollectedCount : MonoBehaviour
{
    public static PlayerCollectedCount Instance;

public short PlayerCollectedBall=0;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }



}
