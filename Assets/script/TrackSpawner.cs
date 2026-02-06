using UnityEngine;
using System.Collections.Generic;
using Benjathemaker;

public class TrackSpawner : MonoBehaviour
{
    public GameObject trackPrefab;
    public GameObject obstaclePrefab;
    public GameObject CoinPrefab;

    public int initialPieces = 5;
    public float pieceLength = 2f;
    public float speed = 2f;
    public float obstacleChance = 0.5f;
    public float coinChance = 0.7f;

    private Queue<GameObject> trackQueue = new Queue<GameObject>();
    private float spawnZ = 0;

    void Start()
    {
        for (int i = 0; i < initialPieces; i++)
        {
            SpawnPiece();
        }
        //spawnZ = initialPieces * pieceLength;
    }

    void Update()
    {
        foreach (GameObject piece in trackQueue)
        {
            piece.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (trackQueue.Peek().transform.position.z < -pieceLength)
        {
            RemovePiece();
            SpawnPiece();
        }
    }

    void SpawnPiece()
    {
        GameObject piece = Instantiate(trackPrefab);
        piece.transform.position = new Vector3(0, -0.3f, spawnZ);

        if(trackQueue.Count > 3)
        {
            // Posible obstáculo
            if (Random.value < obstacleChance)
            {
                SpawnObstacle(piece.transform);
            }
        }

        // Posible moneda
        if (Random.value < coinChance)
        {
            SpawnCoin(piece.transform);
        }

        if (spawnZ < ((initialPieces * pieceLength)-pieceLength))
        {
            spawnZ += pieceLength;
        }
        //spawnZ += spawnZ;
        trackQueue.Enqueue(piece);
        
    }

    void SpawnObstacle(Transform parent)
    {
        float[] lanes = { -0.25f, 0f, 0.25f };
        float x = lanes[Random.Range(0, lanes.Length)];

        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.SetParent(parent);
        obstacle.transform.localPosition = new Vector3(x, 3.3f, 0);
    }

    void SpawnCoin(Transform parent)
    {
        float[] lanes = { -0.25f, 0f, 0.25f };
        float x = lanes[Random.Range(0, lanes.Length)];

        GameObject obstacle = Instantiate(CoinPrefab);
        obstacle.transform.SetParent(parent);
        obstacle.transform.localPosition = new Vector3(x, 3.3f, 0);
        
    }

    void RemovePiece()
    {
        GameObject oldPiece = trackQueue.Dequeue();
        Destroy(oldPiece);
    }
}
