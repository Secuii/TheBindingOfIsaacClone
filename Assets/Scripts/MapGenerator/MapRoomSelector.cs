using UnityEngine;

public class MapRoomSelector : MonoBehaviour
{

	public GameObject roomU, roomD, roomR, roomL,
			roomUD, roomRL, roomUR, roomUL, roomDR, roomDL,
			roomULD, roomRUL, roomDRU, roomLDR, roomUDRL;
	public bool up, down, left, right;
	void Start()
	{
		PickRoom();
	}
	void PickRoom()
	{ //picks correct roomrite based on the four door bools
		if (up)
		{
			if (down)
			{
				if (right)
				{
					if (left)
					{
						Instantiate(roomUDRL, transform.position, Quaternion.identity,transform);
					}
					else
					{
						Instantiate(roomDRU, transform.position, Quaternion.identity, transform);
					}
				}
				else if (left)
				{
					Instantiate(roomULD, transform.position, Quaternion.identity, transform);
				}
				else
				{
					Instantiate(roomUD, transform.position, Quaternion.identity, transform);
				}
			}
			else
			{
				if (right)
				{
					if (left)
					{
						Instantiate(roomRUL, transform.position, Quaternion.identity, transform);
					}
					else
					{
						Instantiate(roomUR, transform.position, Quaternion.identity, transform);
					}
				}
				else if (left)
				{
					Instantiate(roomUL, transform.position, Quaternion.identity, transform);
				}
				else
				{
					Instantiate(roomU, transform.position, Quaternion.identity, transform);
				}
			}
			return;
		}
		if (down)
		{
			if (right)
			{
				if (left)
				{
					Instantiate(roomLDR, transform.position, Quaternion.identity, transform);
				}
				else
				{
					Instantiate(roomDR, transform.position, Quaternion.identity, transform);
				}
			}
			else if (left)
			{
				Instantiate(roomDL, transform.position, Quaternion.identity, transform);
			}
			else
			{
				Instantiate(roomD, transform.position, Quaternion.identity, transform);
			}
			return;
		}
		if (right)
		{
			if (left)
			{
				Instantiate(roomRL, transform.position, Quaternion.identity, transform);
			}
			else
			{
				Instantiate(roomR, transform.position, Quaternion.identity, transform);
			}
		}
		else
		{
			Instantiate(roomL, transform.position, Quaternion.identity, transform);
		}
	}
}