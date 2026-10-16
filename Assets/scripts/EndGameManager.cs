using System;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private PointerInputManager pim;
    
    private void Start()
    {
        TrashVacuum.OnLastFoodDestroyed += TrashVacuumOnLastFoodDestroyed;
    }

    private void TrashVacuumOnLastFoodDestroyed(object sender, EventArgs e)
    {
        print("You are full!");
        pim.enabled = false;
        TrashVacuum.OnLastFoodDestroyed -= TrashVacuumOnLastFoodDestroyed;
    }

    private void OnDestroy()
    {
        TrashVacuum.OnLastFoodDestroyed -= TrashVacuumOnLastFoodDestroyed;
    }

}
