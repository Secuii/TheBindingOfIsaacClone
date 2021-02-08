using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    private RoomController roomController = null;
    [SerializeField] private RoomsDirections roomsDirections;
    
    private void Start()
    {
        roomController = transform.parent.transform.parent.GetComponent<RoomController>();
    }

    public void Action()
    {
        roomController.ChangeRoom(roomsDirections, transform);
        GameObject[] activeProjectiles;
        activeProjectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in activeProjectiles)
        {
            Destroy(projectile);
        }
    }
}

public enum RoomsDirections
{
    Up, Down, Left, Right
}