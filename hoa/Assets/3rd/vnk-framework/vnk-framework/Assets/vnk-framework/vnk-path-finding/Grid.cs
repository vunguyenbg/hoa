using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class Grid : MonoBehaviour
    {
        public static Grid Instance;
        public Pathfinding pathfinding;

        public LayerMask WallMask;//This is the mask that the program will look for when trying to find obstructions to the path.
        public Vector2 vGridWorldSize;//A vector2 to store the width and height of the graph in world units.
        public float fNodeRadius;//This stores how big each square on the graph will be
        public float fDistanceBetweenNodes;//The distance that the squares will spawn from eachother.

        Node[,] NodeArray;//The array of nodes that the A Star algorithm uses.
        public List<Node> FinalPath;//The completed path that the red line will be drawn along


        float fNodeDiameter;//Twice the amount of the radius (Set in the start function)
        int iGridSizeX, iGridSizeY;//Size of the Grid in Array units.


        private void Awake()
        {
            Instance = this;
           // pathfinding = GetComponent<Pathfinding>();
        }

        public void Init()//Ran once the program starts
        {
            fNodeDiameter = fNodeRadius * 2;//Double the radius to get diameter
            iGridSizeX = Mathf.RoundToInt(vGridWorldSize.x / fNodeDiameter);//Divide the grids world co-ordinates by the diameter to get the size of the graph in array units.
            iGridSizeY = Mathf.RoundToInt(vGridWorldSize.y / fNodeDiameter);//Divide the grids world co-ordinates by the diameter to get the size of the graph in array units.
            CreateGrid();//Draw the grid
        }

        internal void RefreshWall()
        {
            Vector2 bottomLeft = new Vector2(transform.position.x, transform.position.y) - new Vector2((iGridSizeX / 2) * fNodeDiameter, (iGridSizeY / 2) * fNodeDiameter);
            Node node;
            for (int y = 0; y < iGridSizeY; y++)
            {
                for (int x = 0; x < iGridSizeX; x++)
                {
                    node = NodeArray[x, y];
                    Vector2 position = bottomLeft + Vector2.right * (x * fNodeDiameter + fNodeRadius) + Vector2.up * (y * fNodeDiameter + fNodeRadius);
                    if (!Physics2D.OverlapBox(position, new Vector2(fNodeDiameter, fNodeDiameter), 0, WallMask))
                    {
                        node.bIsWall = false;
                    }
                    else
                    {
                        node.bIsWall = true;
                    }
                }

            }
        }

        void CreateGrid()
        {
            NodeArray = new Node[iGridSizeX, iGridSizeY];//Declare the array of nodes.
            Vector2 worldPoint = new Vector2(transform.position.x, transform.position.y) - new Vector2((iGridSizeX / 2) * fNodeDiameter, (iGridSizeY / 2) * fNodeDiameter);
            Node node;
            for (int y = 0; y < iGridSizeY; y++)
            {
                for (int x = 0; x < iGridSizeX; x++)
                {
                    node = NodeArray[x, y];
                    Vector2 position = worldPoint + Vector2.right * (x * fNodeDiameter + fNodeRadius) + Vector2.up * (y * fNodeDiameter + fNodeRadius);
                    bool Wall = false;//Make the node a wall
                    if (Physics2D.OverlapBox(position, new Vector2(fNodeDiameter, fNodeDiameter), 0, WallMask))
                    {
                        Wall = true;
                    }
                    NodeArray[x, y] = new Node(Wall, position, x, y);//Create a new node in the array.
                }

            }
        }

        //Function that gets the neighboring nodes of the given node.
        public List<Node> GetNeighboringNodes(Node a_NeighborNode)
        {
            List<Node> NeighborList = new List<Node>();//Make a new list of all available neighbors.
            int icheckX;//Variable to check if the XPosition is within range of the node array to avoid out of range errors.
            int icheckY;//Variable to check if the YPosition is within range of the node array to avoid out of range errors.

            //Check the right side of the current node.
            icheckX = a_NeighborNode.iGridX + 1;
            icheckY = a_NeighborNode.iGridY;
            if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            {
                if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
                {
                    NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
                }
            }
            //Check the Left side of the current node.
            icheckX = a_NeighborNode.iGridX - 1;
            icheckY = a_NeighborNode.iGridY;
            if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            {
                if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
                {
                    NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
                }
            }
            //Check the Top side of the current node.
            icheckX = a_NeighborNode.iGridX;
            icheckY = a_NeighborNode.iGridY + 1;
            if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            {
                if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
                {
                    NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
                }
            }
            //Check the Bottom side of the current node.
            icheckX = a_NeighborNode.iGridX;
            icheckY = a_NeighborNode.iGridY - 1;
            if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            {
                if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
                {
                    NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
                }
            }

            ////Top Right
            //icheckX = a_NeighborNode.iGridX + 1;
            //icheckY = a_NeighborNode.iGridY + 1;
            //if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            //{
            //    if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
            //    {
            //        NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
            //    }
            //}
            ////Down Right
            //icheckX = a_NeighborNode.iGridX + 1;
            //icheckY = a_NeighborNode.iGridY - 1;
            //if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            //{
            //    if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
            //    {
            //        NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
            //    }
            //}
            ////Down Left
            //icheckX = a_NeighborNode.iGridX - 1;
            //icheckY = a_NeighborNode.iGridY - 1;
            //if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            //{
            //    if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
            //    {
            //        NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
            //    }
            //}
            ////Up Left
            //icheckX = a_NeighborNode.iGridX - 1;
            //icheckY = a_NeighborNode.iGridY + 1;
            //if (icheckX >= 0 && icheckX < iGridSizeX)//If the XPosition is in range of the array
            //{
            //    if (icheckY >= 0 && icheckY < iGridSizeY)//If the YPosition is in range of the array
            //    {
            //        NeighborList.Add(NodeArray[icheckX, icheckY]);//Add the grid to the available neighbors list
            //    }
            //}

            return NeighborList;//Return the neighbors list.
        }

        //Gets the closest node to the given world position.
        public Node NodeFromWorldPoint(Vector2 a_vWorldPos)
        {
            float ixPos = ((a_vWorldPos.x + vGridWorldSize.x / 2) / vGridWorldSize.x);
            float iyPos = ((a_vWorldPos.y + vGridWorldSize.y / 2) / vGridWorldSize.y);

            ixPos = Mathf.Clamp01(ixPos);
            iyPos = Mathf.Clamp01(iyPos);

            int ix = Mathf.RoundToInt((iGridSizeX - 1) * ixPos);
            int iy = Mathf.RoundToInt((iGridSizeY - 1) * iyPos);

            return NodeArray[ix, iy];
        }


        //Function that draws the wireframe
        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (NodeArray != null)
            {
                for (int x = 0; x < iGridSizeX; x++)
                {
                    for (int y = 0; y < iGridSizeY; y++)
                    {
                        if (NodeArray[x, y].bIsWall)
                        {
                            Gizmos.color = Color.red;
                        }
                        else
                        {
                            Gizmos.color = Color.yellow;
                            Gizmos.DrawWireCube(NodeArray[x, y].vPosition, new Vector2(fNodeDiameter, fNodeDiameter));
                        }
                        if (FinalPath != null)//If the final path is not empty
                        {
                            if (FinalPath.Contains(NodeArray[x, y]))//If the current node is in the final path
                            {
                                Gizmos.color = Color.red;//Set the color of that node
                                Gizmos.DrawCube(NodeArray[x, y].vPosition, new Vector2(fNodeDiameter, fNodeDiameter));
                            }

                        }
                    }
                }
            }
#endif
        }
    }
}
