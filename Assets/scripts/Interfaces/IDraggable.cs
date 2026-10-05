using UnityEngine;

namespace Interfaces
{
    public interface IDraggable
    {
        /*public void dragged();
        public void unDragged();*/

        public void Dragged(Vector2 position);

    }
}