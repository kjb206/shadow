using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        float x = PlayerPrefs.GetFloat("SpawnX", transform.position.x);
        float y = PlayerPrefs.GetFloat("SpawnY", transform.position.y);
        float z = PlayerPrefs.GetFloat("SpawnZ", transform.position.z);
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = new Vector3(x, y, z);
    }
}
