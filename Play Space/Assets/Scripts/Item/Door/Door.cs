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

        public float timeCloseAuto = 5;

        private void Start()
        {
            animator_Door = GetComponentInChildren<Animator>();
        }

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);
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
                StartCoroutine(WaitDoorClose());
            }
            else
            {
                isOn = false;
                animator_Door.SetBool("isOn", isOn);
            }
        }

        IEnumerator WaitDoorClose()
        {
            yield return new WaitForSeconds(timeCloseAuto);
            isOn = false;
            animator_Door.SetBool("isOn", isOn);
        }
    }
}
