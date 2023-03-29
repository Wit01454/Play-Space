using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlaySpace
{
    public class PlayerInteractable : MonoBehaviour
    {
        public float maxDistance = 1f;
        public float sphereRadius = 1f;

        PlayerManager playerManager;

        [SerializeField]
        private TextMeshPro InteractableText;
        [SerializeField]
        private Image ButtomInteractableImage;

        private void Start()
        {
            playerManager = GetComponent<PlayerManager>();
        }

        public void CheckForInteractableOpject()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)
                || Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, maxDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                if (hit.collider.tag == "Interactable")
                {
                    Interactable interactableOpject = hit.collider.GetComponent<Interactable>();

                    if (interactableOpject != null)
                    {
                        string interatableText = interactableOpject.interactbleText;
                        openInteractableText(interatableText);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.collider.GetComponent<Interactable>().Interact(playerManager);
                        }
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.blue);
                closeInteractableText();
            }
        }

        void OnDrawGizmos()
        {
            RaycastHit hit;

            bool isHit = Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit,
                maxDistance);
            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.transform.forward * hit.distance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, sphereRadius);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }
        }

        public void openInteractableText(string interatableText)
        {
            InteractableText.text = interatableText;
            
            InteractableText.enabled = true;

            ButtomInteractableImage.enabled = true;
        }

        public void closeInteractableText()
        {
            InteractableText.text = "InteractableText";

            ButtomInteractableImage.enabled = false;

            InteractableText.enabled = false;
        }
    }
}
