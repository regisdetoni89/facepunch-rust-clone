using System;
using TMPro;
using UnityEngine;

public class ServerItem : MonoBehaviour
{

    private String serverName = "";
    private String ip = "";
    private String map = "";
    private String wipeAgo = "";
    private int currentPlayers = 0;
    private int maxPlayers = 0;


    public TextMeshProUGUI serverNameText;
    public TextMeshProUGUI serverDescriptionText;
    public TextMeshProUGUI serverPlayersText;
    public TextMeshProUGUI serverPingText;

    public void AddServer(string serverName, string serverIP, string map, int currentPlayers, int maxPlayers, string wipeAgo)
    {
        this.serverName = serverName;
        this.ip = serverIP;
        this.map = map;
        this.currentPlayers = currentPlayers;
        this.maxPlayers = maxPlayers;
        this.wipeAgo = wipeAgo;

        serverNameText.text = serverName;
        serverDescriptionText.text = map + " / " + wipeAgo;
        serverPlayersText.text = currentPlayers + "/" + maxPlayers;
    }
}
