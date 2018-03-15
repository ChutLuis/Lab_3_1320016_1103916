using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolAVL
{
    class Arbol<T> where T: IComparable<T>
    {
        Nodo<T> root;
        public Arbol()
        {
            root = null;

        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }        

        public void Add(Nodo<T> n)
        {
            
            if (root == null)
            {
                root = n;
            }
            else
                Insert(root, n);
        }

        public void Insert(Nodo<T> raiz, Nodo<T> n)
        {
            if (raiz == null)
            {
                raiz = n;
                raiz = balance_tree(raiz);
            }
            else
            {
                if (n.valor.CompareTo(raiz.valor) < 0)
                {
                    if (raiz.izquierdo == null)
                    {
                        raiz.izquierdo = n;
                        raiz.izquierdo = balance_tree(raiz.izquierdo);
                    }

                    else
                        Insert(raiz.izquierdo, n);
                }
                else
                {
                    if (raiz.derecho == null)
                    {
                        raiz.derecho = n;
                        raiz.derecho = balance_tree(raiz.derecho);
                    }
                    else
                    {
                        Insert(raiz.derecho, n);
                    }
                }
            }


        }
        private Nodo<T> balance_tree(Nodo<T> current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.izquierdo) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.derecho) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        private int getHeight(Nodo<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.izquierdo);
                int r = getHeight(current.derecho);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Nodo<T> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.izquierdo);
                Console.Write("({0}) ", current.valor);
                InOrderDisplayTree(current.derecho);
            }
        }
        private int balance_factor(Nodo<T> current)
        {
            int l = getHeight(current.izquierdo);
            int r = getHeight(current.derecho);
            int b_factor = l - r;
            return b_factor;
        }
        private Nodo<T> RotateRR(Nodo<T> padre)
        {
            Nodo<T> pivote = padre.derecho;
            padre.derecho = pivote.izquierdo;
            pivote.izquierdo = padre;
            return pivote;
        }
        private Nodo<T> RotateLL(Nodo<T> Padre)
        {
            Nodo<T> pivote = Padre.izquierdo;
            Padre.izquierdo = pivote.derecho;
            pivote.derecho =Padre;
            return pivote;
        }
        private Nodo<T> RotateLR(Nodo<T> Padre)
        {
            Nodo<T> pivote = Padre.izquierdo;
            Padre.izquierdo = RotateRR(pivote);
            return RotateLL(Padre);
        }
        private Nodo<T> RotateRL(Nodo<T> Padre)
        {
            Nodo<T> pivot = Padre.derecho;
            Padre.derecho = RotateLL(pivot);
            return RotateRR(Padre);
        }
        
    }
}
