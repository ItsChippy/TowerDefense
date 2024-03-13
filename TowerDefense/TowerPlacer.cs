using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class TowerPlacer
    {
        List<BaseTower> towers;
        static BaseTower newTower;

        static bool selectingTower;
        
        public TowerPlacer()
        {
            towers = new List<BaseTower>();
            newTower = null;
        }

        public void Update(BaseEnemy[] enemies)
        {
            UpdateTowers(enemies);
            UpdateTowerPlacer();
        }

        public static void SelectGunTower()
        {
            selectingTower = true;
            newTower = new GunTower(MouseInputManager.MousePosition); 
        }

        public static void SelectSlowTower()
        {
            selectingTower = true;
            newTower = new SlowTower(MouseInputManager.MousePosition); 
        }

        public void UpdateTowerPlacer()
        {
            if (selectingTower)
            {
                RemoveSelectedTower();
                MoveSelectedTower();
                PlaceSelectedTower();
            }
        }

        public void UpdateTowers(BaseEnemy[] enemies)
        {
            foreach(BaseTower tower in towers) 
            {
                tower.Update(enemies);
            }
        }

        private void MoveSelectedTower()
        {
            if(newTower != null)
            {
                newTower.UpdatePosition(new Vector2(MouseInputManager.MousePosition.X - 20, MouseInputManager.MousePosition.Y - 20));
            }
        }

        private void PlaceSelectedTower()
        {
            if (newTower != null && BaseTower.CanPlace(newTower) && MouseInputManager.HasClicked)
            {
                if (newTower is GunTower)
                {
                    Resources.RemoveGold(50);
                }
                if (newTower is SlowTower)
                {
                    Resources.RemoveGold(30);
                }
                towers.Add(newTower);
                newTower = null;
                selectingTower = false;
            }
        }

        private void RemoveSelectedTower()
        {
            if (newTower != null && MouseInputManager.HasRightClicked())
            {
                newTower = null;
                selectingTower = false;
            }
        }

        public void DrawSelectedTower()
        {
            if (newTower != null)
            {
                newTower.Draw();
            }
        }

        public void DrawPlacedTowers()
        {
            foreach (var tower in towers) 
            {
                tower.Draw();
            }
        }
    }
}
