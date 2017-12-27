using UnityEngine;
using System.Collections;

public class SpawnLevel : MonoBehaviour {
    public GameObject desert;
    public GameObject desertBG;

    public GameObject snow;
    public GameObject snowBG;

    public GameObject forest;
    public GameObject forestBG;

    public int levelNum;
	// Use this for initialization
	void Start () {
        levelNum = Random.Range(0, 3);
        if(levelNum == 0)
        {
            desert.SetActive(true);
            desertBG.SetActive(true);
        }else if(levelNum == 1)
        {
            snow.SetActive(true);
            snowBG.SetActive(true);
        }else if(levelNum == 2)
        {
            forest.SetActive(true);
            forestBG.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
