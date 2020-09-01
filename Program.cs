using System;

namespace Cesar
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] pt= fillPlainText();
            string[] ec= fillEncodeText();    
            
            ManagerCesar managerCesar= new ManagerCesar();
            managerCesar.ec=ec;
            managerCesar.pt=pt;


            Console.WriteLine("Ingrese 1 para cifrar y 2 para decifrar");
            int opt= Convert.ToInt32(Console.ReadLine()); 
            
            string word="";
            if(opt==1)
            {
                Console.WriteLine("Ingrese palabra a cifrar. ");
                word=Console.ReadLine(); //Guatemala
                word=word.ToLower();  //minisculas para compatiblidad con el arreglo.
            }else{
                Console.WriteLine("Ingrese palabra a decifrar. ");
                word=Console.ReadLine(); //Guatemala
            }
            

            string result ="";

            
            foreach(char p in word)
            {
                switch (opt)
                {
                    case 1: 
                        result=result+managerCesar.getEncode(p);
                        break;
                    case 2:
                        result=result+managerCesar.getDecode(p);
                        break;
                }
            }
            Console.WriteLine($"Su resultado es: {result}");
            Console.ReadKey();
        }
        
        private static string[] fillPlainText()
        {            
            string abc="a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            char[] delimiters = new char[] {','};
            return abc.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
        }
        private static string[] fillEncodeText()
        {            
            string abc="D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,A,B,C";
            char[] delimiters = new char[] {','};
            return abc.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
        }
    }
    public class ManagerCesar
    {
        public string[] pt {get;set;}
        public string[] ec {get;set;}

        public string getEncode(char c)
        { 
            int p=Array.IndexOf(pt,c.ToString());
            return ec[p];
        }
        public string getDecode(char c)
        {
             int p=Array.IndexOf(ec,c.ToString());
             return pt[p];
        }
    }
}
