using UnityEngine;
using System.Collections;
using XboxControllerControls;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour {
    MyCharacterActions joystickListener;
    public HealthBarScript health1;
    public HealthBarScript health2;
    private float restart_delay = 23.334f;
    private float restart_timer;
    private float slowmo_timer;
    private bool start_timer;
    private bool start_slowmo;
    private bool music_changed;

    public GameObject restarttext;
    public GameObject p1wins;
    public GameObject p2wins;

    public AudioSource musicPlayer;
    public AudioClip victoryMusic;

    // Use this for initialization
    void Start () {
        joystickListener = MyCharacterActions.CreateDefaultBindings();
        restart_timer = restart_delay;
        start_timer = false;
        slowmo_timer = 3;
        music_changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || joystickListener.Back.WasPressed || restart_timer <= 0 || (start_timer && joystickListener.Start.WasPressed))
        {
            Application.LoadLevel(0); //or whatever number your scene is
        }

        if(health1.curr_health <= 0)
        {
            p2wins.SetActive(true);
            
            start_timer = true;
        }

        if(health2.curr_health <= 0)
        {
            p1wins.SetActive(true);
            
            start_timer = true;
        }

        if (start_timer == true)
        {
            restarttext.SetActive(true);
            restart_timer -= Time.deltaTime;
        }
        if(start_timer == true && music_changed == false)
        {
            musicPlayer.clip = victoryMusic;
            musicPlayer.volume = .5f;
            musicPlayer.PlayDelayed(.4f);
            musicPlayer.loop = true;
            music_changed = true;
        }
    }
    
}
