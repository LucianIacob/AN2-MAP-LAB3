using System;
namespace Lab2_3_MAP
{
    public class SimpleList<T> where T : IComparable<T>
    {
        private class Nod
        {
            private T info = default(T);
            private Nod urm = null;

            public T getInfo()              {   return info;    }
            public void setInfo(T inf)      {   info = inf;     }
            public Nod getUrm()             {   return urm;     }
            public void setUrm(Nod urma)    {   urm = urma;     }
        }

        private Nod prim = null;
        private int length = 0;

        public bool add(T o)
        {
            if (prim == null)
            {
                length++;
                Nod n = new Nod();
                n.setInfo(o);
                prim = n;
                return true;
            }
            else
            {
                if (prim != null && o.CompareTo(prim.getInfo()) < 0)
                {
                    Nod primul = new Nod();
                    primul.setUrm(prim);
                    primul.setInfo(o);
                    prim = primul;
                    return true;
                }
                else
                {
                    Nod aux = prim;
                    Nod aux1 = aux;
                    while (aux != null)
                    {
                        if (o.CompareTo(aux.getInfo()) < 0) break;
                        aux1 = aux;
                        aux = aux.getUrm();
                    }
                    Nod aux2 = new Nod();
                    aux2.setUrm(aux1.getUrm());
                    aux1.setUrm(aux2);
                    aux2.setInfo(o);
                    return true;
                }
            }
        }

        public bool remove(T o)
        {
            Nod crt = prim;
            Nod prec = crt;
            if (o.CompareTo(prim.getInfo()) == 0)
            {
                prim = prim.getUrm();
            }
            else
            {
                while (crt != null)
                {
                    if (o.CompareTo(crt.getInfo()) == 0) break;
                    prec = crt;
                    crt = crt.getUrm();
                }
                prec.setUrm(crt.getUrm());
                length--;
            }
            return true;
        }

        public bool update(T o)
        {
            Nod crt = prim;
            while (crt != null)
            {
                if ((crt.getInfo()).CompareTo(o) == 0) break;
                crt = crt.getUrm();
            }
            crt.setInfo(o);
            return true;
        }

        public T find(T o)
        {
            if (prim == null)   return default(T);
            else
            {
                if ((prim.getInfo()).CompareTo(o) == 0)
                    return prim.getInfo();
                Nod crt = prim.getUrm();
                while (crt != null)
                {
                    if ((crt.getInfo()).CompareTo(o) == 0)
                        return crt.getInfo();
                    else
                        crt = crt.getUrm();
                }
                return o;
            }
        }

        public class Iterator
        {
            private Nod curent;
            private SimpleList<T> simpleList;
            public Iterator(SimpleList<T> simpleList)
            {
                this.simpleList = simpleList;
                curent = simpleList.prim;
            }
            public T element()
            {
                return curent.getInfo();
            }
            public void next()
            {
                curent = curent.getUrm();
            }
            public bool valid()
            {
                if (curent == null)
                    return false;
                else
                    return true;
            }
        }
        public Iterator getIterator()
        {
            return new Iterator(this);
        }
    }
}