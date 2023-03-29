using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySpace
{
    public class Chair : Interactable
    {
        [SerializeField]
        public GameObject character;
        public Transform SitPosition;
        
        private bool isSitting = false;

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);
        }

    }
}