using System.Collections.Generic;
using UnityEngine;

namespace EconomicSystem
{
    public class CellsView : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> cellRenderers;
        [SerializeField] private LayerMask activeLayer;
        [SerializeField] private LayerMask placedLayer;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material baseMaterial;
        [SerializeField] private Material placedMaterial;

        private int _activeLayerNum;
        private int _placedLayerNum;

        private void Start()
        {
            _activeLayerNum = (int)Mathf.Log(activeLayer.value, 2);
            _placedLayerNum = (int)Mathf.Log(placedLayer.value, 2);
        }
        public void HighlightCells()
        {
            for (int i = 0; i < cellRenderers.Count; i++)
            {
                if (_activeLayerNum == cellRenderers[i].gameObject.layer)
                    cellRenderers[i].material = activeMaterial;
                else if (_placedLayerNum == cellRenderers[i].gameObject.layer)
                    cellRenderers[i].material = placedMaterial;
            }
        }
        public void UnHighlightCells()
        {
            for (int i = 0; i < cellRenderers.Count; i++)
            {
                cellRenderers[i].material = baseMaterial;
            }
        }
    }
}