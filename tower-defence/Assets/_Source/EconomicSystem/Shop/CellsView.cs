using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EconomicSystem
{
    public class CellsView : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> cellsRenderers;
        [SerializeField] private LayerMask activeLayer;
        [SerializeField] private LayerMask placedLayer;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material baseMaterial;
        [SerializeField] private Material placedMaterial;
        public void HighlightCells()
        {
            for (int i = 0; i < cellsRenderers.Count; i++)
            {
                if ((activeLayer & 1 << cellsRenderers[i].gameObject.layer) == 1 << cellsRenderers[i].gameObject.layer)
                    cellsRenderers[i].material = activeMaterial;
                else if ((placedLayer & 1 << cellsRenderers[i].gameObject.layer) == 1 << cellsRenderers[i].gameObject.layer)
                    cellsRenderers[i].material = placedMaterial;
            }
        }
        public void UnHighlightCells()
        {
            for (int i = 0; i < cellsRenderers.Count; i++)
            {
                cellsRenderers[i].material = baseMaterial;
            }
        }
    }
}