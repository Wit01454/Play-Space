using FishNet.Connection;
using FishNet.Object;
using FishNet.Transporting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySpace
{
    public class Interactable : NetworkBehaviour
    {
  
        public string interactbleText;

        public virtual void Interact(PlayerMovement playerMovement)
        {
            Debug.Log("You  interacted with an object");
        }

    }

}
