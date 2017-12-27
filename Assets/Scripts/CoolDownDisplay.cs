using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoolDownDisplay : MonoBehaviour {
    // Use this for initialization
    public float cooldown;
	void Start () {
        GetComponent<Image>().fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().fillAmount -= 1.0f / cooldown * Time.deltaTime;
    }
}
