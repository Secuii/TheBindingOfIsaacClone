using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    private Transform nextRoom;

    void Update()
    {
        if(nextRoom != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(nextRoom.transform.position.x,
                                                                                nextRoom.transform.position.y, -10f), 0.5f);
        }
    }

    public void NextRoom(Transform nextRoom)
    {
        this.nextRoom = nextRoom;
    }
}
