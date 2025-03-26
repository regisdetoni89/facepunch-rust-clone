using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ServerList : MonoBehaviour
{
    
    public GameObject serverPrefab;
    public GameObject serverListContent;

    public void AddServer(string serverName, string serverIP, string serverMap, int currentPlayers, int maxPlayers, string wipeAgo)
    {
        double y = serverListContent.transform.childCount * 90 - 135;
        GameObject server = Instantiate(serverPrefab, serverListContent.transform);
        ServerItem serverItem = server.GetComponent<ServerItem>();
        serverItem.AddServer(serverName, serverIP, serverMap, currentPlayers, maxPlayers, wipeAgo);
        serverListContent.GetComponent<RectTransform>().sizeDelta = new Vector2(-20, (float) (serverListContent.transform.childCount * 90));
        server.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (float) -y);

    }

    void Start()
    {
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
        AddServer("Facepunch", "127.0.0.1", "Procedural Map", 10, 100, "1 day ago");
    }

}
