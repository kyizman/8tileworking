using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8tile
{
    class UtilityCommands
    {

        int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };




        //main command for best first search

        public List<int[,]> BestFirst(int[,] x)
        {
            //initilizers
            int[,] tempdown = new int[3, 3];
            int[,] tempright = new int[3, 3];
            int[,] templeft = new int[3, 3];
            int[,] tempup = new int[3, 3];
            int[,] temparray = x;

            int downcost = 0;
            int rightcost = 0;
            int upcost = 0;
            int leftcost = 0;

            string lastlocation = "start";

            //the best rout list
            List<int[,]> best = new();

            best.Add(x);
            bool finished = false;
            int cost = 0;

            //this will check the location of 0 or empty and attempt check it 
            while (!finished)
            {

                //these are to make sure it ends
                if (best.Contains(goal) || best.First() == goal)
                {
                    Console.Write(best.ToString());
                    return best;
                }

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

                        }
                    }
                }

                if (whywontyouquit)
                {
                    Console.Write(best.ToString());
                    return best;

                }
                temparray = x;

                //get location
                string location = LocateEmpty(x);




                //each of these are the same 
                //the location of the empty is found
                //then the huristic of ammount of misplaced  nodes
                //checks each viable direction from the empty for the cheepest and sets it as the new node
                if (location == "TOPLEFT")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");

                    x = temparray;
                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    downcost = BadPostion(tempdown);
                    rightcost = BadPostion(tempright);
                    if (downcost >= rightcost)//&& reversecheck(lastlocation)!=2 && reversecheck(lastlocation)<20 )
                    {
                        best.Add(tempright);
                        x = tempright;
                    }
                    else
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }






                }

                else if (location == "TOPCENTER")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");
                    x = temparray;
                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    templeft = swithempty(x, "LEFT");
                    x = temparray;
                    downcost = BadPostion(tempdown);
                    rightcost = BadPostion(tempright);
                    leftcost = BadPostion(templeft);
                    if (downcost >= rightcost && downcost >= rightcost)// &&)// reversecheck(lastlocation) != 2 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempright);
                        x = tempright;
                    }
                    else if (rightcost >= downcost && leftcost >= downcost)// &&)// reversecheck(lastlocation) != 4 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }
                    else
                    {
                        best.Add(templeft);
                        x = templeft;
                    }





                }


                else if (location == "TOPRIGHT")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");
                    x = temparray;
                    templeft = swithempty(x, "LEFT");
                    x = temparray;
                    downcost = BadPostion(tempdown);

                    leftcost = BadPostion(templeft);

                    if (leftcost >= downcost)// && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }
                    else
                    {
                        best.Add(templeft);
                        x = templeft;
                    }





                }

                else if (location == "CENTERLEFT")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");
                    x = temparray;
                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    tempup = swithempty(x, "UP");
                    x = temparray;
                    downcost = BadPostion(tempdown);
                    rightcost = BadPostion(tempright);
                    upcost = BadPostion(tempup);
                    if (downcost >= rightcost && upcost >= downcost)//&& reversecheck(lastlocation) != 4 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempright);
                        x = tempright;
                    }
                    else if (rightcost >= downcost && upcost >= downcost)//&& reversecheck(lastlocation) != 6 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }
                    else
                    {
                        best.Add(tempup);
                        x = tempup;
                    }





                }

                else if (location == "CENTER")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");
                    x = temparray;
                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    templeft = swithempty(x, "LEFT");
                    x = temparray;
                    tempup = swithempty(x, "UP");
                    x = temparray;
                    downcost = BadPostion(tempdown);
                    rightcost = BadPostion(tempright);
                    upcost = BadPostion(tempup);
                    leftcost = BadPostion(templeft);
                    if (downcost >= rightcost && downcost >= rightcost && leftcost >= rightcost && upcost > rightcost)// && reversecheck(lastlocation) != 5 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempright);
                        x = tempright;
                    }
                    else if (downcost <= rightcost && leftcost >= downcost && upcost >= downcost)//&& reversecheck(lastlocation) != 7 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }
                    else if (rightcost >= leftcost && upcost >= leftcost && downcost >= leftcost)// && reversecheck(lastlocation) != 3 && reversecheck(lastlocation) < 20)
                    {
                        best.Add(templeft);
                        x = templeft;
                    }
                    else
                    {
                        best.Add(tempup);
                        x = tempup;
                    }





                }

                else if (location == "CENTERRIGHT")
                {
                    cost++;

                    tempdown = swithempty(x, "DOWN");
                    x = temparray;
                    templeft = swithempty(x, "LEFT");
                    x = temparray;
                    tempup = swithempty(x, "UP");
                    x = temparray;
                    downcost = BadPostion(tempdown);
                    upcost = BadPostion(tempup);
                    leftcost = BadPostion(templeft);
                    if (downcost >= upcost && leftcost > upcost)
                    {
                        best.Add(tempup);
                        x = tempup;
                    }
                    else if (rightcost >= downcost && leftcost > downcost)
                    {
                        best.Add(tempdown);
                        x = tempdown;
                    }
                    else
                    {
                        best.Add(templeft);
                        x = templeft;
                    }






                }

                else if (location == "BOTTOMLEFT")
                {
                    cost++;

                    tempup = swithempty(x, "UP");
                    x = temparray;
                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    upcost = BadPostion(tempup);

                    leftcost = BadPostion(tempright);
                    if (upcost >= leftcost)
                    {
                        best.Add(tempright);
                        x = tempright;
                    }

                    else
                    {
                        best.Add(tempup);
                        x = tempup;
                    }




                }

                else if (location == "BOTTOMCENTER")
                {
                    cost++;

                    tempup = swithempty(x, "UP");
                    x = temparray;

                    templeft = swithempty(x, "LEFT");
                    x = temparray;

                    tempright = swithempty(x, "RIGHT");
                    x = temparray;
                    upcost = BadPostion(tempup);
                    rightcost = BadPostion(tempright);
                    leftcost = BadPostion(templeft);
                    if (upcost >= leftcost && rightcost >= leftcost)
                    {
                        best.Add(templeft);
                        x = templeft;
                    }

                    else if (leftcost >= upcost && rightcost >= upcost)
                    {
                        best.Add(tempup);
                        x = tempup;
                    }
                    else
                    {
                        best.Add(tempup);
                        x = tempup;
                    }


                }


                else if (location == "BOTTOMRIGHT")
                {
                    cost++;

                    tempup = swithempty(x, "UP");
                    x = temparray;

                    templeft = swithempty(x, "LEFT");
                    x = temparray;


                    upcost = BadPostion(tempup);

                    leftcost = BadPostion(templeft);
                    if (upcost >= leftcost)
                    {
                        best.Add(templeft);
                        x = templeft;
                    }


                    else
                    {
                        best.Add(tempup);
                        x = tempup;
                    }



                }






            }
            return best;

        }

        public int reversecheck(string loc)
        {
            switch (loc)
            {
                case "TOPLEFT":
                    {
                        return 0;
                    }

                case "TOPCENTER":
                    return 1;
                case "TOPRIGHT":
                    return 2;
                case "CENTERLEFT":
                    return 3;
                case "CENTER":
                    return 4;
                case "CENTERRIGHT":
                    return 5;
                case "BOTTOMLEFT":
                    return 6;
                case "BOTTOMCENTER":
                    return 7;
                case "BOTTOMRIGHT":
                    return 8;
                default: return 100;


            }

        }

        public int manhatanhelper(int x)
        {
            int temp = 0;
            int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (goal[i, j] == temp)
                    {
                        temp = i;
                    }
                }
            }
            return temp;
        }

        public int manhatanhelper2(int x)
        {
            int temp = 0;
            int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    if (goal[i, j] == temp)
                    {
                        temp = j;
                    }
                }
            }
            return temp;
        }

        public int BadPostion(int[,] x)
        {   
            int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            int result = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int p = 0; p < 3; p++)
                {
                    int temp = x[i, p];
                    result += Math.Abs(i - manhatanhelper(temp)) + Math.Abs(p - manhatanhelper2(temp));

                }
            }
            return result;
        }

        public int BadPostion2(int[,] x)
        {
            int[,] goal = { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            int result = 0;
            int[,] temparr = x;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (goal[i, j] != x[i, j])
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }


        //move the empty
        public int[,] swithempty(int[,] x, string direction)
        {
            int LOCx = 0;
            int LOCy = 0;
            int temp = 0;
            int[,] temparr = new int[3, 3];

            for (int q = 0; q < 3; q++)
                for (int w = 0; w < 3; w++)
                {
                    temparr[q, w] = x[q, w];
                } 
        


                    for (int i = 0; i < 3; i++)
                for (int p = 0; p<3; p++)
                {
                    if (x[i, p] == 0)
                    {
                        LOCx = i;
                        LOCy = p;
                    }
                }

            switch (direction)
            {
                case "UP":

                    temp = temparr[LOCx-1,LOCy];

                    temparr[LOCx-1, LOCy ] = 0;

                    temparr[LOCx, LOCy]=temp;
                    return temparr;

                case "DOWN":
                     temp = temparr[LOCx+1, LOCy];

                    temparr[LOCx+1, LOCy ] = 0;

                    temparr[LOCx, LOCy] = temp;
                    return temparr;


                case "LEFT":
                    temp = temparr[LOCx, LOCy-1];

                    temparr[LOCx, LOCy-1] = 0;

                    temparr[LOCx, LOCy] = temp;
                    return temparr;


                case "RIGHT":
                    temp = temparr[LOCx  , LOCy+1];

                    temparr[LOCx, LOCy+1] = 0;

                    temparr[LOCx, LOCy] = temp;
                    return temparr;

            }

            return null;
        }


        

        //locate the empty for work
       public string LocateEmpty(int[,] x)
        {
            
            string location="";
            for(int i = 0; i<3;i++)
                for(int p= 0; p<3;p++)
                {
                    if(x[i,p] ==0)
                    {
                        location = i + "," + p;
                    }
                }
            

            switch(location)

            {
                case "0,0":
                        return "TOPLEFT";



                case "0,1":
                    return "TOPCENTER";

                case "0,2":
                    return "TOPRIGHT";
                case "1,0":
                    return "CENTERLEFT";
                case "1,1":
                    return "CENTER";
                case "1,2":
                    return "CENTERRIGHT";

                case "2,0":
                    return "BOTTOMLEFT";
                case "2,1":
                    return "BOTTOMCENTER";
                case "2,2":
                    return "BOTTOMRIGHT";

                default:
                    return null;
                 

            }


        }
    }
}
