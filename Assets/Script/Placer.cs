using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Script
{
    public class Placer : MonoBehaviour
    {
        public PlayerController player;
        public PlacerBigOREnd ChunkPrefabs;
        public PlacerBigOREnd FirstChunk;

        public List<PlacerBigOREnd> spawnedChunks = new List<PlacerBigOREnd>();
        void Start()
        {
            spawnedChunks.Add(FirstChunk);
        }

        void Update()
        {
            if (player.transform.position.x > spawnedChunks[spawnedChunks.Count - 1].End.position.x - 15)
            {
                player.monets += 5;
                SpawnedChunks();
            }
        }

        private void SpawnedChunks()
        {
            PlacerBigOREnd newChunk = Instantiate(ChunkPrefabs);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            spawnedChunks.Add(newChunk);

            if (spawnedChunks.Count > 2)
            {
                Destroy(spawnedChunks[0].gameObject);
                spawnedChunks.RemoveAt(0);
            }

        }

        public void SetActive( bool active)
        {
            for(int i=0;i< spawnedChunks.Count;i++)
            {
                spawnedChunks[i].gameObject.SetActive(active);
            }

        }
    }

}