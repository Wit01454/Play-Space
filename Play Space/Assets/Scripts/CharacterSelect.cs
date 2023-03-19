using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlaySpace
{
    public class CharacterSelect : NetworkBehaviour
    {
        [SerializeField] private GameObject characterSelectDisplay = default;
        [SerializeField] private Transform characterPreviewParent = default;
        [SerializeField] private TMP_Text characterNameText = default;
        [SerializeField] private float turnSpeeed = 90f;
        [SerializeField] private Character[] characters = default;

        private int currentChacterIndex = 0;
        private List<GameObject> characterInstances = new List<GameObject>();

        public override void OnStartClient()
        {
            base.OnStartClient();
            
            foreach (var character in characters)
            {
                GameObject characterInstance = Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);

                characterInstance.SetActive(false);

                characterInstances.Add(characterInstance);
            }

            characterInstances[currentChacterIndex].SetActive(true);
            characterNameText.text = characters[currentChacterIndex].CharacterName;

            characterSelectDisplay.SetActive(true);
        }
        

        public void Right()
        {
            characterInstances[currentChacterIndex].SetActive(false);

            currentChacterIndex = (currentChacterIndex + 1) % characterInstances.Count;

            characterInstances[currentChacterIndex].SetActive(true);
            characterNameText.text = characters[currentChacterIndex].CharacterName;
        }

        public void Left()
        {
            characterInstances[currentChacterIndex].SetActive(false);

            currentChacterIndex--;
            if(currentChacterIndex < 0)
            {
                currentChacterIndex += characterInstances.Count;
            }
            

            characterInstances[currentChacterIndex].SetActive(true);
            characterNameText.text = characters[currentChacterIndex].CharacterName;
        }
    }
}
