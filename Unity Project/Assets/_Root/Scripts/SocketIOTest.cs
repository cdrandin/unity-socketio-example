using UnityEngine;
using System.Collections;
using SocketIO;

public class SocketIOTest : MonoBehaviour 
{
	private SocketIOComponent socket;
	
	public void Awake() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
	}

	public void Start(){
		socket.On("connection", ConnectionCallback);
		socket.On("boop", (SocketIOEvent e) => {
			Debug.Log(string.Format("[name: {0}, data: \'{1}\']", e.name, e.data));
		});
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			socket.Emit("beep");
		}
	}

	public void ConnectionCallback(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}

	public void ChatMessageCallback(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
}
