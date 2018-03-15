using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaz;
namespace ArbolAVL
{
    public class Nodo<T> : IComparable<T>
    {
        public T valor { get; set; }
        public Nodo<T> izquierdo { get; set; }
        public Nodo<T> derecho { get; set; }
        private ComparadorNodosDelegate<T> comparar;
        public Nodo(T _value, ComparadorNodosDelegate<T> _comparador)
        {
            this.valor = _value;
            this.izquierdo= null;
            this.derecho = null;
            comparar = _comparador;
        }
        public int CompareTo(T other)
        {
            return comparar(valor, other);
        }
    }
}
