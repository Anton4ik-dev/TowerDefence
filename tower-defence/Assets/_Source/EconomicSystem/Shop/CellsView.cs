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
        public void HighlightCells()
        {
            for (int i = 0; i < cellRenderers.Count; i++)
            {
                if ((activeLayer & 1 << cellRenderers[i].gameObject.layer) == 1 << cellRenderers[i].gameObject.layer)
                    cellRenderers[i].material = activeMaterial;
                else if ((placedLayer & 1 << cellRenderers[i].gameObject.layer) == 1 << cellRenderers[i].gameObject.layer)
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