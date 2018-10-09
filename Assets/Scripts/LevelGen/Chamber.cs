using System.Collections;
using UnityEngine;

namespace LevelGen
{
    public class Chamber : MonoBehaviour
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
        
        void GenerateCorridor(Transform exit)
        {
            var candidate = Instantiate(levelContainer.Corridors.PickOne(), exit).GetComponent<Corridor>();
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
            GenerateCorridor(t);
        }
    }
}