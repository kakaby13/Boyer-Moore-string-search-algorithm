using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Rabbit
{
    class Program
    {
        static public void Main( string[] args )
        {
            int FirtIncludeSymbol = -1;

            string T = "";
            string P = "";

            //счітываніе в строки із файлов

            System.IO.StreamReader file = new System.IO.StreamReader( @"e:\T.txt" );
            while(!file.EndOfStream)
            {
                T += file.ReadLine();
            }
            file.Close();

            System.IO.StreamReader file1 = new System.IO.StreamReader( @"e:\P.txt" );
            while(!file1.EndOfStream)
            {
                P += file1.ReadLine();
            }
            file1.Close();

            Console.WriteLine( "t=" + T.Length + " p=" + P.Length );

            var stopwatch = System.Diagnostics.Stopwatch.StartNew(); // timer.start

            int[] Suff = new int[P.Length]; 
            int[] ValueShift = new int[255];

            //заполненіе массіва суффіксов

            for(int i = 0; i < P.Length; i++)
            {
                Suff[i] = 1;
            }

            //поіск R(x)

            for(int i = 0; i < 255; i++)
            {
                char Symbol = (char)i;
                ValueShift[i] = P.Length - 1;
                for(int j = P.Length; j > 0; j--)
                {
                    if(Symbol == P[j - 1])
                    {
                        ValueShift[i] = P.Length - j;
                    }
                }
            }

            //поіск суффікса/суффіксов
            for(int i = P.Length - 1; i > P.Length / 2; i--)
            {
                for(int j = i - 1; j > 0; j--)
                {
                    if(P.Substring( i, P.Length - i ) == P.Substring( j, P.Length - i ))
                    {
                        Suff[i] = j;

                        Console.WriteLine( "найден следующий суфикс в подстроке P: " +
                            P.Substring( i, P.Length - i ) + " " + P.Substring( j, P.Length - i ) );
                    }
                }
            }

            //поіск    
            int k = P.Length - 1;
            bool found = false;

            while(k < T.Length - 1)
            {
                for(int i = 0; i <= P.Length - 1; i++)
                {
                    if(k >= T.Length - 1)
                    {
                        break;
                    }

                    if(P[P.Length - i - 1] != T[k - i])
                    {

                        char temp1 = T[k - i];
                        int temp2 = (Int32)temp1;
                        int temp3 = ValueShift[temp2];
                        int si = Suff[i];

                        if(si > temp3)
                        {
                            k += Suff[i];
                        }

                        else if(si <= temp3)
                        {

                            k += temp3;

                        }
                        //continue;
                    }
                    else if(P[P.Length - i - 1] == T[k - i])
                    {
                        if(i != 0 && k > 0) { }
                        {
                        }
                        if(i == 0)
                        {
                            FirtIncludeSymbol = k;
                            Console.WriteLine( "совпадение найдено - " + FirtIncludeSymbol );
                            found = true;
                            break;
                        }
                    }
                }
                if(found == true)
                {
                    break;
                }
            }
            if(found == false)
            {
                Console.WriteLine( "совпадение не найдено" );
            }
            stopwatch.Stop();
            Console.WriteLine( stopwatch.Elapsed );

            Console.WriteLine( "Done" );
            Console.ReadLine();
        }
    }
}
