using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Grid Layout Group Cell Size Fitter")]

    public sealed class GridLayoutGroupCellSizeFitter : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private GridLayoutGroup gridLayoutGroup;

        [AddIndent]

        [GetComponentInParentOnly]

        [Essential]

        [PropertyField]

        [Margin]

        [Button(nameof(Fit))]

        [UsingCustomProperty]

        [SerializeField]

        private RectTransform container;

        public void Fit()
        {
            Vector2 cellSize = new
            (
                container.rect.width - gridLayoutGroup.padding.horizontal,

                container.rect.height - gridLayoutGroup.padding.vertical
            );

            if (gridLayoutGroup.constraint != GridLayoutGroup.Constraint.Flexible &&
                
                gridLayoutGroup.constraintCount > 1)
            {
                cellSize -= gridLayoutGroup.spacing * (gridLayoutGroup.constraintCount - 1);

                cellSize /= gridLayoutGroup.constraintCount;
            }

            if (gridLayoutGroup.cellSize != cellSize)
            {
                FixedUndo.RecordObject(gridLayoutGroup, "Fit Grid Layout Group Cell Size");

                gridLayoutGroup.cellSize = cellSize;

                FixedEditorUtility.SetDirty(gridLayoutGroup);
            }
        }
    }
}