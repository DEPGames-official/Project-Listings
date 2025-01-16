using UnityEngine;
using Mirror;
using System.Collections.Generic;
using UnityEngine.Networking;
using Mirror.Examples.Basic;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class TurnOffRemotePlayers : NetworkBehaviour
{
    private void Start()
    {
        string id = string.Format("{0}", this.netId);
        Player scr = this.GetComponent<Player>();

        if (this.isLocalPlayer == true)
        {
            scr.enabled = true;
        }
        else
        {
            scr.enabled = false;
        }

    }




}
