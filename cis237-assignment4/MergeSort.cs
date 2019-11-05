using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Stephanie Amo
//Project 4
//Due: 11/05/2019

namespace cis237_assignment4
{
    class MergeSort
    {
        private void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {

            //copy the whole array
            for(int k = lo; k<=hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (a[j].CompareTo(a[i]) < 0)
                    a[k] = aux[j++];
                else
                    a[k] = aux[i++];
            }
        }

        private void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo)
                return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid); //left half
            Sort(a, aux, mid + 1, hi); //right half
            Merge(a, aux, lo, mid, hi);
        }

        //Takes in IComparable array to be sorted
        public void Sort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            Sort(a, aux, 0, a.Length - 1);
        }
    }
}
