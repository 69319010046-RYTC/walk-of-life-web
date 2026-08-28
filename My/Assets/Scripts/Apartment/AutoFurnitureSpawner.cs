using System.Collections.Generic;
using UnityEngine;

namespace WalkOfLife.Apartment
{
    [System.Serializable]
    public class FurnitureSlot
    {
        public string slotId; // e.g. "TV_Slot", "Sofa_Slot", "Bed_Slot"
        public Transform slotTransform;
        public bool isOccupied = false;
    }

    public class AutoFurnitureSpawner : MonoBehaviour
    {
        public List<FurnitureSlot> apartmentSlots = new List<FurnitureSlot>();

        public bool SpawnFurnitureInSlot(string slotId, GameObject furniturePrefab, out GameObject spawnedObject)
        {
            spawnedObject = null;
            FurnitureSlot targetSlot = apartmentSlots.Find(s => s.slotId == slotId && !s.isOccupied);

            if (targetSlot != null && furniturePrefab != null)
            {
                spawnedObject = Instantiate(furniturePrefab, targetSlot.slotTransform.position, targetSlot.slotTransform.rotation, targetSlot.slotTransform);
                targetSlot.isOccupied = true;
                Debug.Log($"[APARTMENT] Spawned furniture in slot {slotId}!");
                return true;
            }

            return false;
        }
    }
}
