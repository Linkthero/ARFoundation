using UnityEngine;
using System.Collections.Generic;
using Benjathemaker;

public class TrackSpawner : MonoBehaviour
{
    public GameObject trackPrefab;
    public GameObject obstaclePrefab;
    public GameObject CoinPrefab;
    public GameObject vidaPrefab;

    public int initialPieces = 5;
    public float pieceLength = 2f;
    public float speed = 2f;
    public float obstacleChance = 0.4f;
    public float coinChance = 0.5f;
    public float vidaChance = 0.2f;

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

        if(Datos.instance.GetPuntos() > 15)     //aumentamos la probabilidad de q aparezcan barriles
        {
            obstacleChance = 0.65f;
        }
    }

    void SpawnPiece()
    {
        GameObject piece = Instantiate(trackPrefab);
        piece.transform.position = new Vector3(0, -0.3f, spawnZ);

        if (Datos.instance.cronometro >= 5)      //hasta que no pasen 5 seg no empiezan a salir objetos
        {
            if (trackQueue.Count > 3)
            {
                

                if (Random.value < obstacleChance) //posible obstáculo
                {
                    SpawnObstacle(piece.transform);
                }

                float prob = Random.value;
                if (prob <= vidaChance)   //posible vida
                {
                    SpawnVida(piece.transform);
                }
                else if (prob < coinChance)     //posible moneda
                {
                    SpawnCoin(piece.transform);
                }
            }
        }    





        if (spawnZ < ((initialPieces * pieceLength) - pieceLength))
        {
            spawnZ += pieceLength;
        }
        //spawnZ += pieceLength;
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

    void SpawnVida(Transform parent)
    {
        float[] lanes = { -0.25f, 0f, 0.25f };
        float x = lanes[Random.Range(0, lanes.Length)];

        GameObject obstacle = Instantiate(vidaPrefab);
        obstacle.transform.SetParent(parent);
        obstacle.transform.localPosition = new Vector3(x, 3.3f, 0);

    }

    void RemovePiece()
    {
        GameObject oldPiece = trackQueue.Dequeue();
        Destroy(oldPiece);
    }
}
