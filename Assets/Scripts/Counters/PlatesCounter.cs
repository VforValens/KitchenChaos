using System;
using UnityEngine;

public class PlatesCounter : BaseCounter
{

    public event EventHandler OnPlatesSpawned;
    public event EventHandler OnPlatesCleared;
    
    
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;
    
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;

        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if (GameManager.Instance.IsGamePlaying() && platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount++;

                OnPlatesSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is empty-handed
            if (platesSpawnedAmount > 0)
            {
                // There is at least one plate here
                platesSpawnedAmount--;
                
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                
                OnPlatesCleared?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    
    
}
