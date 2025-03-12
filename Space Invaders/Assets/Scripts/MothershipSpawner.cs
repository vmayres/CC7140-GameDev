using UnityEngine;

public class MothershipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mothershipPrefab;  // O prefab da Mothership a ser instanciado
    private float spawnMinTime = 20f;  // Tempo m�nimo de espera para spawn (20 segundos)
    private float spawnMaxTime = 30f;  // Tempo m�ximo de espera para spawn (30 segundos)
    private float timeToNextSpawn;  // Vari�vel que controla o tempo at� o pr�ximo spawn

    void Start()
    {
        // Inicializa o tempo at� o pr�ximo spawn com um valor aleat�rio
        timeToNextSpawn = Random.Range(spawnMinTime, spawnMaxTime);
    }

    void Update()
    {
        // Chama a fun��o TrySpawn a cada frame
        TrySpawn();
    }

    void TrySpawn()
    {
        // Diminui o tempo at� o pr�ximo spawn
        timeToNextSpawn -= Time.deltaTime;

        // Se o tempo chegou a zero ou abaixo, realiza o spawn
        if (timeToNextSpawn <= 0f)
        {
            // Instancia a Mothership na posi��o do spawner
            Instantiate(mothershipPrefab, transform.position, Quaternion.identity);

            // Reseta o tempo at� o pr�ximo spawn com um novo valor aleat�rio
            timeToNextSpawn = Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
