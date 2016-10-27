using System;
using UnityEngine;
using InControl;


namespace XboxControllerControls
{
    // This is just a simple "player" script that rotates and colors a cube
    // based on input read from the actions field.
    //
    // See comments in PlayerManager.cs for more details.
    //
    public class Player : MonoBehaviour
    {
        public MyCharacterActions Actions { get; set; }

        Renderer cachedRenderer;


        void OnDisable()
        {
            if (Actions != null)
            {
                Actions.Destroy();
            }
        }
    }
}

