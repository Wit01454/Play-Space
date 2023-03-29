using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;


namespace PlaySpace
{
    public class  PlayerManager : NetworkBehaviour
    {
        [SerializeField]
        private GameObject _camera;

        Animator anim;
        PlayerMovement playerMovement;
        PlayerInteractable playerInteractable;

        public AnimatorHandler animatorHandler;



        void Start()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            animatorHandler.Initialize();
            
            anim = GetComponentInChildren<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
            playerInteractable = GetComponent<PlayerInteractable>();
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (base.IsOwner)
                _camera.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            playerMovement.HandleMovement();
            playerInteractable.CheckForInteractableOpject();
        }

        //#region Interactable
        //public float maxDistance = 1f;
        //public float sphereRadius = 1f;

        //public void CheckForInteractableOpject()
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)
        //        || Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, maxDistance))
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        //        if (hit.collider.tag == "Interactable")
        //        {
        //            Interactable interactableOpject = hit.collider.GetComponent<Interactable>();
                   

        //            if (interactableOpject != null)
        //            {
                        
        //                string interatableText = interactableOpject.interactbleText;

        //                if (Input.GetKeyDown(KeyCode.E))
        //                {
        //                    hit.collider.GetComponent<Interactable>().Interact(this);
        //                }

        //            }

        //        }
        //    }
        //    else
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.blue);
        //    }
        //}

        //void OnDrawGizmos()
        //{
        //    RaycastHit hit;

        //    bool isHit = Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit,
        //        maxDistance);
        //    if (isHit)
        //    {
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawRay(transform.position, transform.transform.forward * hit.distance);
        //        Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, sphereRadius);
        //    }
        //    else
        //    {
        //        Gizmos.color = Color.green;
        //        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        //    }
        //}
        //#endregion
    }
}
