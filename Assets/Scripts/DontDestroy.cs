using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SharedBetweenScenes");

        DontDestroyOnLoad(this.gameObject);
    }
}
