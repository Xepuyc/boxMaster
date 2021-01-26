using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BoxMaster
{
    class Count
    {
        public static double length (int s, int v, int F )
            
        {
            double s1 = s * 0.0001;
            double v1 = v * 0.001;
            double D1 = Math.Sqrt(s1 / Math.PI) * 2;
            double a = 343 / (2 * Math.PI);
            double c=Math.Pow(F/a,2);
            double l = (s1/c/v1*100)-(0.85*D1*100);       
            
            return l;   

        }
        public static double area (int l, int v, int F)
        {

            double a = 343 / (2 * Math.PI);
            double c = Math.Pow(F / a, 2);
            double s = l*v*c/10;
            return s;

        }
        public static double Volume (int l, int s, int F)
        {
            double s1 = s * 0.0001;
            double a = 343 / (2 * Math.PI);
            double c = Math.Pow(F / a, 2);
            double D1 = Math.Sqrt(s1 / Math.PI) * 2;
            double V = s1 / (l/100 - 0.85 * D1) / c;
            return V;

        }
        public static double Freq (int l, int s, int V)
        {
            double s1 = s * 0.0001;
            double l1 = l *0.01;
            double v1 = V * 0.001;
            double D1 = Math.Sqrt(s1 / Math.PI) * 2;
            double z = (343 / (2 * Math.PI));
            
            double F= z*   Math.Sqrt(s1 / ((l1 + (0.85 * D1)) * v1));
            return F;

        }
        public static int AreaP(int sk, int ck)
        {
            int A = sk * ck;
            return A;
        }

          
    }
}