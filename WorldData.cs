using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Class to store world chunks that have been created at run time.
Dictionary of chunks stores with key=Vector2Int position and value=chunk class.
Methods allow for the addition and retrieval of chunk data from the dictionary.
*/

public class WorldData
{
    Dictionary<Vector2Int, ChunkData> chunkDictionary = new Dictionary<Vector2Int, ChunkData>();
    

    public void AddChunkToDictionary(Vector2Int chunkPos, ChunkData newChunk)
    {
        chunkDictionary.Add(chunkPos, newChunk);
    }

    public ChunkData GetChunkAtPosition(Vector2Int chunkPos)
    {
        return chunkDictionary[chunkPos];
    }
}
