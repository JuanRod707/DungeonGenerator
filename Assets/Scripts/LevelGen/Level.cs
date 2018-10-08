using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelGen
{
    public class Level : MonoBehaviour
    {
        public int MaxLevelSize;
        public GameObject[] Chambers;
        public GameObject[] Corridors;

        private List<Collider> registeredColliders = new List<Collider>();

        public int LevelSize { get; private set; }

        void Start()
        {
            LevelSize = MaxLevelSize;
            CreateInitialChamber();
        }

        private void CreateInitialChamber()
        {
            var initialChamber = Instantiate(Chambers.PickOne(), transform).GetComponent<Chamber>();
            RegisterNewSection(initialChamber.Bounds);
        }

        public bool IsSectionValid(Collider newSection, Collider sectionToIgnore)
        {
            return !registeredColliders.Except(new[] {sectionToIgnore})
                .Any(c => c.bounds.Intersects(newSection.bounds));
        }

        public void RegisterNewSection(Collider newSection)
        {
            registeredColliders.Add(newSection);
            LevelSize--;
        }
    }
}