using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DynamicPrograming
{
    public class PathFinder
    {
        
        private int currentRow = 0, currentCol = 0;
        public int[,] matrix =
        {
            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 1, 0, 0, 1 },
            { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
        };
        private List<PathFinderModel> AllMove = new List<PathFinderModel>();
        public PathFinderModel CurrentMove { get; set; }
        public PathFinderModel? PreviousMove 
        {
            get
            {
                if (AllMove.Count > 1)
                return AllMove[AllMove.Count - 1];
                return null;
            }
        }
   
        public bool MoveUp()
        {
            if (!CanMoveUp()) return false;
            currentRow--;
            CurrentMove = new PathFinderModel(currentRow, currentCol, true);
            AllMove.Add(CurrentMove);
            return true;

        }
        public bool MoveRight()
        {
            if (!CanMoveRight()) return false;
            currentCol++;
            CurrentMove = new PathFinderModel(currentRow, currentCol, false,false,false,true);
            AllMove.Add(CurrentMove);

            return true;
        }
        private bool CanMoveRight()
        {
            if (currentCol == matrix.GetLength(1)) return false;
            if (matrix[currentRow, currentCol + 1] != 0) return false;
           
            return true;
        }
        public bool MoveLeft()
        {
            if (!CanMoveLeft()) return false;
            currentCol--;
            CurrentMove = new PathFinderModel(currentRow, currentCol, false, true);
            AllMove.Add(CurrentMove);
            return true;
        }
        private bool CanMoveLeft()
        {
            if (currentCol == 0) return false;
            if (matrix[currentRow, currentCol - 1] != 0) return false;
            
            return true;
        }
        public bool MoveDown()
        {
            if (!CanMoveDown()) return false;
            currentRow++;
            CurrentMove = new PathFinderModel(currentRow, currentCol, false, false, true);
            AllMove.Add(CurrentMove);

            return true;
        }
        private bool CanMoveDown()
        {
            if (currentRow == matrix.GetLength(0)) return false;
            if (matrix[currentRow + 1, currentCol] != 0) return false;
            return true;
        }
        private bool CanMoveUp()
        {
            
            if (currentRow == matrix.GetLowerBound(0)) return false;
            if (matrix[currentRow -1, currentCol] != 0) return false;

            return true;
        }

        public void StartMove()
        {
            while (true)
            {
                Move();
            }
        }
        private void Move()
        {


            Console.WriteLine("matrix[{0},{1}]-{2}", CurrentMove.X, CurrentMove.Y,CurrentMove.ShowDirection());
            Console.ReadKey();

            if (MoveRight()) Move();

            if (MoveDown()) Move();

            if (MoveLeft()) Move();

            if (MoveUp()) Move();


        }
        

    }
}
