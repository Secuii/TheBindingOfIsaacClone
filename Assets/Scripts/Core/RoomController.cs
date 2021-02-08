using System.Collections;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject UpRoom { get; set; } = null;
    public GameObject LeftRoom { get; set; } = null;
    public GameObject RightRoom { get; set; } = null;
    public GameObject DownRoom { get; set; } = null;

    private GameObject player = null;
    private new Camera camera = null;

    private Transform door = null;

    private void Start()
    {
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeRoom(RoomsDirections roomDirections, Transform door)
    {
        this.door = door;
        switch ((int)roomDirections)
        {
            case 0:
                ChangeRoomControllerSetup(UpRoom, 0f, 3f);
                break;
            case 1:
                ChangeRoomControllerSetup(DownRoom, 0f, -3f);
                break;
            case 2:
                ChangeRoomControllerSetup(LeftRoom, -4f, 0f);
                break;
            case 3:
                ChangeRoomControllerSetup(RightRoom, 4f, 0f);
                break;
            default:
                break;
        }
    }

    public void ChangeRoomControllerSetup(GameObject nextRoom, float distanceFromDoorX, float distanceFromDoorY)
    {
        camera.GetComponent<CameraController>().NextRoom(nextRoom.transform);
        player.transform.position = new Vector3(door.transform.position.x + distanceFromDoorX, door.transform.position.y + distanceFromDoorY, 0f);
    }


}