using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton containing a list of all the listeners that might want to hear about any message
/// </summary>
public class EventSystemMessages : MonoBehaviour
{
    private static EventSystemMessages _main;
    public List<GameObject> listeners = new List<GameObject>();

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Awake ()
    {
        // Check only one instance of EventSystemMessages exists
        if (_main == null)
        {
            _main = this;
        }
        else
        {
            Debug.LogWarning ("EventSystemListeners re-creation attempted, destroying the new one");
            Destroy (gameObject);
        }
    }

    /// <summary>
    /// Add Listener for Event System Messages
    /// </summary>
    public void AddListener(GameObject listener)
    {
        if (listeners.Contains(listener))
        {
            return;
        }
        
        listeners.Add(listener);
    }
}
