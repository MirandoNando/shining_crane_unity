public class PrizeSpawner : MonoBehaviour
{
    public GameObject[] prizes;
    public Transform area;

    public int amount = 20;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = area.position + new Vector3(
                Random.Range(-2f, 2f),
                Random.Range(0f, 1f),
                Random.Range(-2f, 2f)
            );

            Instantiate(prizes[Random.Range(0, prizes.Length)], pos, Quaternion.identity);
        }
    }
}