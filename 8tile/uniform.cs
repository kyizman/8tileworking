using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8tile
{
    class uniform
    {

        public List<Node> uniformsearch(Node initial)
        {
            //node paths and lists
            List<Node> Path = new List<Node>();
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();
            int count = 0;
            //add initial node
            open.Add(initial);


            bool goal = false;

            while (open.Count > 0 && goal == false)
            {
                //expand child
                Node current = open[0];
                closed.Add(current);
                open.RemoveAt(0);


                current.expand();

                

                //get new child and check if it is goal
                for (int i = 0; i < current.childs.Count; i++)
                {
                    count++;
                    Node newcurrent = current.childs[i];
                    if (goalcheck(newcurrent.data))
                    {
                        goal = true;
                        winingpath(Path, newcurrent);
                    }

                    if (!contains(open, newcurrent) && !contains(closed, newcurrent))
                    {
                        open.Add(newcurrent);
                    }
                }
            }

            return Path;
        }
        //best path
        public void winingpath(List<Node> path,Node x)
        {
            Node current = x;
            path.Add(current);
            while(current.parent!=null)
            {
                current = current.parent;
                path.Add(current);
            }



        }

        //check if it contains it in the selected list
        public static bool contains(List<Node> list, Node x)
        {
            bool contain = false;
            for(int i =0;i<list.Count;i++)
            {
                if(list[i].same(x.data))
                {
                    contain = true;
                }

               
            }
            return contain;
        }
        //goal check
        public static bool goalcheck(int[,] x)
        {
            int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };


            bool whywontyouquit = true;
            for (int s = 0; s < 3; s++)
            {
                for (int e = 0; e < 3; e++)
                {
                    if (x[s, e] == goal[s, e] && whywontyouquit != false)
                    {
                        whywontyouquit = true;
                    }
                    else
                    {
                        whywontyouquit = false;
                        break;
                    }
                }
            }
            return whywontyouquit;
        }

    }
}
