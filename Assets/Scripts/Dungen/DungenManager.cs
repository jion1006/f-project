using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class DungenManager : MonoBehaviour
{
    public GameObject playerSpawn;

    [SerializeField]
    private List<MapManager> mapList;
    [SerializeField]
    private CameraManager theCamera;

    private int currentMap=0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.transform.position = playerSpawn.transform.position;
        for (int i = 1; i < mapList.Count; ++i)
        {
            mapList[i].gameObject.SetActive(false);
        }
        theCamera.SetBound(mapList[0].bound);
    }

    

    public void MoveToMap(int nextMap)
    {
        currentMap = nextMap;
        mapList[currentMap].gameObject.SetActive(true);
        theCamera.SetBound(mapList[currentMap].bound);
    }
}
