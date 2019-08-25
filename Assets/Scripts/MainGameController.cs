using UnityEngine;

public class MainGameController : MonoBehaviour, IPlayerEvents
{
    [SerializeField] private EventSystemMessages eventSystemMessages;
    
    // Use this for initialization
    private void Awake()
    {
        eventSystemMessages.AddListener(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerHurt(int newHealth)
    {
        Debug.Log("OnPlayerHurt!");
    }

    public void OnPlayerPowerUp(float energy)
    {
        Debug.Log("OnPlayerPowerUp!");
    }

    public void OnPlayerReachedExit(GameObject exit)
    {
        Debug.Log("OnPlayerReachedExit!");
    }
}
