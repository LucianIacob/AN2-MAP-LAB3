using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2_3_MAP
{
    public class Dictionar<K,V> : IDictionar<K, V> where K: IComparable<K>
    {
        public class Pereche: IComparable<Pereche>
        {
            public K cheie;
            public V valoare;

            public Pereche(K cheie, V valoare)
            {
                this.cheie = cheie;
                this.valoare = valoare;
            }
            public int CompareTo(Pereche o)     
            {   
                return this.cheie.CompareTo(o.cheie);
            }
        }

        private SimpleList<Pereche> myList = new SimpleList<Pereche>();
        SimpleList<Pereche> getList()   {  return myList;   }
        public Iterator getIterator()   {  return new Iterator(this);   }
        public class Iterator
        {
            SimpleList<Pereche>.Iterator listIterator;
            public Iterator(Dictionar<K, V> d)
            {
                listIterator = d.getList().getIterator();
            }
            public Pereche element()
            {
                return listIterator.element();
            }
            public void next()
            {
                listIterator.next();
            }
            public Boolean valid()
            {
                if (listIterator.valid() == false) return false;
                else return true;
            }
        }

        public Boolean add(K key, V valoare)    {
            return myList.add(new Pereche(key, valoare));                   }
        public Boolean update(K key, V valoare) {
            return myList.update(new Pereche(key, valoare));                }
        public bool remove(K key)               {
            return myList.remove(new Pereche(key, default(V)));             }
        public V find(K key)                    {
            return myList.find(new Pereche(key, default(V))).valoare;       }
    }
}