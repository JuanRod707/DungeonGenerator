using System.Collections;
using UnityEngine;

namespace LevelGen
{
    public class Corridor : MonoBehaviour
    {
        public Transform[] Exits;
        public Collider Bounds;

        private Level levelContainer;
        private float waitTime = 0.2f;

        public void Initialize(Level level)
        {
            levelContainer = level;
            transform.SetParent(levelContainer.transform);
            levelContainer.RegisterNewSection(Bounds);
            
            if (levelContainer.LevelSize > 0)
                GenerateAnnexes();
        }

        void GenerateAnnexes()
        {
            foreach (var e in Exits)
            {
                StartCoroutine(WaitAndGenerate(e));
            }
        }
        
        void GenerateChamber(Transform exit)
        {
            var candidate = Instantiate(levelContainer.Chambers.PickOne(), exit).GetComponent<Chamber>();
            if (levelContainer.IsSectionValid(candidate.Bounds, Bounds))
            {
                candidate.Initialize(levelContainer);
            }
            else
            {
                Destroy(candidate.gameObject);   
            }
        }
        
        IEnumerator WaitAndGenerate(Transform t)
        {
            yield return new WaitForSeconds(waitTime);
            GenerateChamber(t);
        }
    }
}