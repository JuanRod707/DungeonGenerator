using UnityEngine;

namespace LevelGen
{
    public class Corridor : MonoBehaviour
    {
        public Transform[] Exits;
        public Collider Bounds;

        private Level levelContainer;

        void Start()
        {
            levelContainer = GetComponentInParent<Level>();
            
            if (levelContainer.LevelSize > 0)
                GenerateAnnexes();
        }

        void GenerateAnnexes()
        {
            foreach (var e in Exits)
            {
                GenerateChamber(e);
            }
        }
        
        void GenerateChamber(Transform exit)
        {
            var candidate = Instantiate(levelContainer.Chambers.PickOne(), exit).GetComponent<Chamber>();
            if (levelContainer.IsSectionValid(candidate.Bounds, Bounds))
            {
                candidate.transform.SetParent(levelContainer.transform);
                levelContainer.RegisterNewSection(candidate.Bounds);
            }
            else
            {
                Destroy(candidate.gameObject);   
            }
        }
    }
}