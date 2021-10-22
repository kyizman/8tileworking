using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8tile
{
    class astar
    { 
   public List<Node> astarsearch(Node initial)
    {
        //node paths and lists
        List<Node> Path = new List<Node>();
        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();
        int count = 0;
        //add initial node
        open.Add(initial);
            int current =0;

            bool goal = false;
            count = initial.getfcost();
        while (open.Count > 0)
        {

                for(int x = 0; x< open.Count;x++)
                {

                    if(open[x].getfcost() <count)
                    {
                        current = x;

                        count = open[x].getfcost();


                    }



                }



                Node next = open[current];


            //expand child
          
            closed.Add(next);
            open.RemoveAt(0);


            next.expand();



            //get new child and check if it is goal
            for (int i = 0; i < next.childs.Count; i++)
            {
               
                Node newcurrent = next.childs[i];
                if (goalcheck(newcurrent.data) )
                {

                       

                        

                    goal = true;
                    winingpath(Path, newcurrent);

                        for(int w =0; w< open.Count;w++)
                        {
                            if(open[w].fcost< newcurrent.fcost && open[w].distance >= newcurrent.distance )//&& goalcheck(open[w].data))
                            {
                                goal = false;
                            }


                            
                        }
                        for (int w = 0; w < closed.Count; w++)
                        {
                            if (closed[w].fcost < newcurrent.fcost && closed[w].distance >= newcurrent.distance && goalcheck(closed[w].data))
                            {
                                goal = false;

                                open.Add(closed[w]);
                            }



                        }

                        if(goal==true)
                        {
                            return Path;
                        }

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
    public void winingpath(List<Node> path, Node x)
    {
        Node current = x;
        path.Add(current);
        while (current.parent != null)
        {
            current = current.parent;
            path.Add(current);
        }



    }

    //check if it contains it in the selected list
    public static bool contains(List<Node> list, Node x)
    {
        bool contain = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].same(x.data))
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

