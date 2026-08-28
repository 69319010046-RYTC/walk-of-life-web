using UnityEngine;

namespace WalkOfLife.Map
{
    public enum BuildingType
    {
        Home,
        Restaurant,
        OfficeTower,
        University,
        Gym,
        FurnitureStore
    }

    public class MapNode : MonoBehaviour
    {
        public string nodeName = "Building Location";
        public BuildingType buildingType;
        public Vector2 mapCoordinates;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}
