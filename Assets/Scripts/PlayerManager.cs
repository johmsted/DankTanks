using System;
using UnityEngine;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;


namespace XboxControllerControls
{
    // This example iterates on the basic multiplayer example by using action sets with
    // bindings to support both joystick and keyboard players. It would be a good idea
    // to understand the basic multiplayer example first before looking a this one.
    //
    public class PlayerManager : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;

        public GameObject p1_entered;
        public GameObject p2_entered;

		public AudioSource musicPlayer;
		public AudioClip mainMusic;
		public AudioClip desertMusic;
        public AudioClip snowMusic;
        public AudioClip forestMusic;

		public ParticleSystem sandParticle;
        
        public SpawnLevel musicDecider;

        const int maxPlayers = 2;
        
        List<Player> players = new List<Player>(maxPlayers);

        MyCharacterActions joystickListener;

		void Start()
		{
			sandParticle.Stop ();
		}

        void OnEnable()
        {
            InputManager.OnDeviceDetached += OnDeviceDetached;
            joystickListener = MyCharacterActions.CreateDefaultBindings();
        }


        void OnDisable()
        {
            InputManager.OnDeviceDetached -= OnDeviceDetached;
            joystickListener.Destroy();
        }


        void Update()
        {
            if (JoinButtonWasPressedOnListener(joystickListener))
            {
                var inputDevice = InputManager.ActiveDevice;

                if (ThereIsNoPlayerUsingJoystick(inputDevice))
                {
                    CreatePlayer(inputDevice);
                }
            }
            if(players.Count == 2)
            {
                if (joystickListener.Start.WasPressed)
                {
                    p1_entered.SetActive(false);
                    p2_entered.SetActive(false);
                    
                    GameObject.Find("IntroImage").GetComponent<Image>().enabled = false;
                    GameObject.Find("JoinText").GetComponent<Text>().enabled = false;
                    if (musicDecider.levelNum == 0)
                    {
                        musicPlayer.clip = desertMusic;
                    }
                    else if(musicDecider.levelNum == 1)
                    {
                        musicPlayer.clip = snowMusic;
                    }else if(musicDecider.levelNum == 2)
                    {
                        musicPlayer.clip = forestMusic;
                    }
					musicPlayer.Play ();
					musicPlayer.loop = true;
					sandParticle.Play ();
                }
            }

        }


        bool JoinButtonWasPressedOnListener(MyCharacterActions actions)
        {
            return actions.AButton.WasPressed;
        }


        Player FindPlayerUsingJoystick(InputDevice inputDevice)
        {
            var playerCount = players.Count;
            for (int i = 0; i < playerCount; i++)
            {
                var player = players[i];
                if (player.Actions.Device == inputDevice)
                {
                    return player;
                }
            }

            return null;
        }


        bool ThereIsNoPlayerUsingJoystick(InputDevice inputDevice)
        {
            return FindPlayerUsingJoystick(inputDevice) == null;
        }


        void OnDeviceDetached(InputDevice inputDevice)
        {
            var player = FindPlayerUsingJoystick(inputDevice);
            if (player != null)
            {
                RemovePlayer(player);
            }
        }


        Player CreatePlayer(InputDevice inputDevice)
        {
            if (players.Count == 0)
            {
                // Pop a position off the list. We'll add it back if the player is removed.

                // Create a new instance and specifically set it to listen to the
                // given input device (joystick).
                var actions = MyCharacterActions.CreateDefaultBindings();
                actions.Device = inputDevice;

                player1.GetComponent<Player>().Actions = actions;

                players.Add(player1.GetComponent<Player>());
                p1_entered.SetActive(true);

                return player1.GetComponent<Player>();
            }else if(players.Count == 1){
                var actions = MyCharacterActions.CreateDefaultBindings();
                actions.Device = inputDevice;

                player2.GetComponent<Player>().Actions = actions;

                players.Add(player2.GetComponent<Player>());
                p2_entered.SetActive(true);


                return player2.GetComponent<Player>();
            }
            return null;
        }


        void RemovePlayer(Player player)
        {
            players.Remove(player);
            player.Actions = null;
            Destroy(player.gameObject);
        }

    }

}