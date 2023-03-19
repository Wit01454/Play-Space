using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySpace
{
    [CreateAssetMenu (fileName = "New Character", menuName = "Character Selection/Character")]
    
    public class Character : ScriptableObject
    {
        [SerializeField] private string characterName = default;
        [SerializeField] private GameObject characterPreviewPrefab = default;
        [SerializeField] private GameObject gameplaycharacterPrefab = default;

        public string CharacterName => characterName;
        public GameObject CharacterPreviewPrefab => characterPreviewPrefab;
        public GameObject GameplaycharacterPrefab => gameplaycharacterPrefab;
    }
}
