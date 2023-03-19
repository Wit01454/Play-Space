using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

namespace PlaySpace
{
    public class Door : Interactable
    { 
        public Animator animator_Door;

        bool isOn = false;

        private void Start()
        {
            animator_Door = GetComponentInChildren<Animator>();
        }

        public override void Interact(PlayerMovement playerMovement)
        {
            base.Interact(playerMovement);
            ServerPressSwitch();
        }

        [ServerRpc(RequireOwnership = false)]
        private void ServerPressSwitch()
        {
            PressSwitch();
        }

        private void PressSwitch()
        {
            if (!isOn)
            {
                isOn = true;
                animator_Door.SetBool("isOn", isOn);
            }
            else
            {
                isOn = false;
                animator_Door.SetBool("isOn", isOn);
            }
        }


    }
}
