using UnityEngine;
using System.Collections;
using InControl;

namespace XboxControllerControls
{

    public class MyCharacterActions : PlayerActionSet
    {
        public PlayerAction Left;
        public PlayerAction Right;
        public PlayerAction AimLeft;
        public PlayerAction AimRight;
        public PlayerAction Fire;
		public PlayerAction LeftTrigger;
        //public PlayerAction BButton;
        public PlayerAction YButton;
        public PlayerAction AButton;
        public PlayerAction XButton;
        public PlayerAction Start;
        public PlayerAction Back;
        public PlayerOneAxisAction Move;
        public PlayerOneAxisAction MoveAim;
		//public PlayerOneAxisAction MoveAim2;

        public MyCharacterActions()
        {
            Left = CreatePlayerAction("Move Left");
            Right = CreatePlayerAction("Move Right");
            AimLeft = CreatePlayerAction("Aim Left");
            AimRight = CreatePlayerAction("Aim Right");
			LeftTrigger = CreatePlayerAction("Left Trigger");
			Fire = CreatePlayerAction("Right Trigger");
			//BButton = CreatePlayerAction("B Button");
			YButton = CreatePlayerAction("Y Button");
            AButton = CreatePlayerAction("A Button");
            XButton = CreatePlayerAction("X Button");
            Start = CreatePlayerAction("Start");
            Back = CreatePlayerAction("Back");
            Move = CreateOneAxisPlayerAction(Left, Right);
            MoveAim = CreateOneAxisPlayerAction(AimLeft, AimRight);
        }


        // Use this for initialization
        public static MyCharacterActions CreateDefaultBindings()
        {
            MyCharacterActions characterActions = new MyCharacterActions();

            characterActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
            characterActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
            characterActions.AimLeft.AddDefaultBinding(InputControlType.RightStickLeft);
            characterActions.AimRight.AddDefaultBinding(InputControlType.RightStickRight);
			characterActions.Fire.AddDefaultBinding(InputControlType.RightTrigger);
			characterActions.LeftTrigger.AddDefaultBinding(InputControlType.LeftTrigger);
			//characterActions.BButton.AddDefaultBinding(InputControlType.Action2);
			characterActions.YButton.AddDefaultBinding(InputControlType.Action4);
			characterActions.AButton.AddDefaultBinding(InputControlType.Action1);
            characterActions.XButton.AddDefaultBinding(InputControlType.Action3);
            characterActions.Start.AddDefaultBinding(InputControlType.Start);
            characterActions.Back.AddDefaultBinding(InputControlType.Back);

            return characterActions;
        }

        public static MyCharacterActions CreateAltBindings()
        {
            MyCharacterActions characterActions = new MyCharacterActions();

            characterActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
            characterActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
            characterActions.AimLeft.AddDefaultBinding(InputControlType.LeftTrigger);
            characterActions.AimRight.AddDefaultBinding(InputControlType.RightTrigger);
            characterActions.Fire.AddDefaultBinding(InputControlType.Action2);
            characterActions.LeftTrigger.AddDefaultBinding(InputControlType.LeftTrigger);
            //characterActions.BButton.AddDefaultBinding(InputControlType.Action2);
            characterActions.YButton.AddDefaultBinding(InputControlType.Action4);
            characterActions.AButton.AddDefaultBinding(InputControlType.Action1);
            characterActions.XButton.AddDefaultBinding(InputControlType.Action3);
            characterActions.Start.AddDefaultBinding(InputControlType.Start);
            characterActions.Back.AddDefaultBinding(InputControlType.Back);

            return characterActions;
        }
    }
}
