﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8tile
{
    class Node
    {
        //initilizers
        public List<Node> childs = new List<Node>();
        public Node parent;
        public int[,] data = new int[3,3];
        public int x=0;

        //node construct
        public Node(int[,] x)
        {
            setdata(x);

      
        }

        //attempt to expand
        public void expand()
        {
            UtilityCommands utility = new UtilityCommands();
            string location = utility.LocateEmpty(data);



            //each will expand in cardinal directeons away from the empty

            if (location == "TOPLEFT")
            {

                nodemovedown(data);
                nodemoveRight(data);



            }

            else if (location == "TOPCENTER")
            {
                nodemovedown(data);
                nodemoveRight(data);
                nodemoveleft(data);

            }


            else if (location == "TOPRIGHT")
            {

                nodemovedown(data);
              
                nodemoveleft(data);


            }

            else if (location == "CENTERLEFT")
            {

                nodemovedown(data);
                nodemoveRight(data);
              
                
                nodemoveUp(data);

            }

            else if (location == "CENTER")
            {

                nodemovedown(data);
                nodemoveRight(data);
                nodemoveleft(data);

                nodemoveUp(data);
            }

            else if (location == "CENTERRIGHT")
            {



                nodemovedown(data);
               
                nodemoveleft(data);

                nodemoveUp(data);




            }

            else if (location == "BOTTOMLEFT")
            {

               
                nodemoveRight(data);
                
                nodemoveUp(data);



            }

            else if (location == "BOTTOMCENTER")
            {

              
                nodemoveRight(data);
                nodemoveleft(data);

                nodemoveUp(data);

            }


            else if (location == "BOTTOMRIGHT")
            {


              
                nodemoveleft(data);

                nodemoveUp(data);


            }
        }

        //set array
            public void setdata(int[,]x)
        {
            data = x;


        


        }

        //will move the item in the array right and sawp with item there
        public void nodemoveRight(int[,] x)
        {
            
            int LOCx = 0;
            int LOCy = 0;
            int temp = 0;
            int[,] temparr = new int[3, 3];
            copy(temparr, x);
            for (int i = 0; i < 3; i++)
                for (int p = 0; p < 3; p++)
                {
                    if (x[i, p] == 0)
                    {
                        LOCx = i;
                        LOCy = p;
                    }
                }

        
                temp = temparr[LOCx, LOCy + 1];

                temparr[LOCx, LOCy + 1] = 0;

                temparr[LOCx, LOCy] = temp;

                Node child = new Node(temparr);
                childs.Add(child);
                child.parent = this;
            
            

            
        }
        //will move empty down and swap
        public void nodemovedown(int[,]x)
        {
            int LOCx = 0;
            int LOCy = 0;
            int temp = 0;
            int[,] temparr = new int[3, 3];
            copy(temparr, x);
            for (int i = 0; i < 3; i++)
                for (int p = 0; p < 3; p++)
                {
                    if (x[i, p] == 0)
                    {
                        LOCx = i;
                        LOCy = p;
                    }
                }
          
                temp = temparr[LOCx + 1, LOCy];

                temparr[LOCx + 1, LOCy] = 0;

                temparr[LOCx, LOCy] = temp;
                Node child = new Node(temparr);
                childs.Add(child);
                child.parent = this;
            

        }
        //move empty up and swap
        public void nodemoveUp(int[,]x)
        {
            int LOCx = 0;
            int LOCy = 0;
            int temp = 0;
            int[,] temparr = new int[3, 3];
            copy(temparr, x);
            for (int i = 0; i < 3; i++)
                for (int p = 0; p < 3; p++)
                {
                    if (x[i, p] == 0)
                    {
                        LOCx = i;
                        LOCy = p;
                    }
                }
         
                temp = temparr[LOCx - 1, LOCy];

                temparr[LOCx - 1, LOCy] = 0;

                temparr[LOCx, LOCy] = temp;
                temparr[LOCx, LOCy] = temp;
                Node child = new Node(temparr);
                childs.Add(child);
                child.parent = this;
            
        }
        //move empty left and swap
        public void nodemoveleft(int[,]x)
        {
            int LOCx = 0;
            int LOCy = 0;
            int temp = 0;
            int[,] temparr = new int[3, 3];
            copy(temparr, x);
            for (int i = 0; i < 3; i++)
                for (int p = 0; p < 3; p++)
                {
                    if (x[i, p] == 0)
                    {
                        LOCx = i;
                        LOCy = p;
                    }
                }
           
                temp = temparr[LOCx, LOCy - 1];

                temparr[LOCx, LOCy - 1] = 0;

                temparr[LOCx, LOCy] = temp;
                Node child = new Node(temparr);
                childs.Add(child);
                child.parent = this;
            

        }
        //copy array
        public void copy(int[,] x, int[,] y)
        {
            for (int i = 0; i < 3; i++)
                for (int p = 0; p < 3; p++)
                {
                    x[i, p] = y[i, p];
                }
        }

        //check if arrays are the same for selected node
      public bool same(int[,]x)
        {
            bool check = true;


            for (int i = 0; i < 3; i++)
            {
                for (int p = 0; p < 3; p++)
                {
                   if (data[i,p]!=x[i,p])
                    {
                        check = false;
                    }
                }
            }
            return check;
}           

    }
}
