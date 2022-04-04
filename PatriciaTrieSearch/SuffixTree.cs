using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrieceTrie
{
    public class Node
    {
        public Node Other = null;
        public Node Next = null;
        public StringBuilder Key { get; set; }
        
        public int Length { get; set; }
        public Node(StringBuilder k, int n)
        {
            Key = k;
            Length = n;
        }
        
    }
    class SuffixTree
    {
        
        public Node node;
        //Позволяет найти индекс последнего из одинаковых символов
        private int Prefix(StringBuilder x, int n, StringBuilder key, int t)
        {
            for (int i = 0; i < n; i++)
                if (i == t || x[i] != key[i])
                    return i;
            return n;
        }
        
        public Node Find(Node k, StringBuilder x)
        {
            
            
            int n = x.Length;
            if (k == null)
                return null;
            int t = Prefix(x, n, k.Key, k.Length);
            //Если схожих элементов нет то мы переходим на другой узел 
            if (t == 0)
                return Find(k.Other, x);
            //Если длинна схожих элементов равна длинне ключа узла то мы вызываем ту же функцию только с обрезанной строкой и с другим узлом
            if (t == k.Length && k.Next!=null)
            {
                return Find(k.Next, new StringBuilder(x.ToString(), t, n - t, n - t));
            }
            //Если длина схожих элементов равна длинне искомого ключа то вернуть найденный узел
            if (t == n && t == k.Length)
            {
                return k;
            }
            
            
            return null;

        }
        private void Split(ref Node t, int k)
        {
            Node p = new Node(new StringBuilder(t.Key.ToString(), k, t.Length - k, t.Length - k), t.Length - k);
            p.Next = t.Next;
            t.Next = p;
            StringBuilder a = new StringBuilder(t.Key.ToString(), 0, k, k);
            t.Key = a;
            t.Length = k;


        }
        private Node Insert(ref Node t, string a)
        {

            StringBuilder x = new StringBuilder(a);
            int n = x.Length;
            if (t == null) return t=new Node(x, n);
            int k = Prefix(x, n, t.Key, t.Length);
            if (k == 0)
            {
                t.Other = Insert(ref t.Other, x.ToString());

            }
            else if (k < n)
            {
                if (k < t.Length)
                    Split(ref t, k);
                t.Next = Insert(ref t.Next, x.Remove(0, k).ToString());
            }
            return t;
        }
        
        public List<string> words = new List<string>
        {
            "крэк ",
            "наркотики ",
            "наркотик ",
            "джоинт ",
            "трип ",
            "дуть ",
            "соли ",
            "лсд ",
            "колесо ",
            "меф ",
            "фен ",
            "гаш ",
            "хэш ",
            "план ",
            "шишки ",
            "хапать ",
            "камень ",
            "бледного ",
            "гашиш ",
            "марихуана ",
            "каннабис ",
            "крокодил ",
            "спайс ",
            "снег ",
            "порошок ",
            "кокоин ",
            "кокос ",
            "гидра ",
            "клад ",
            "кладмен ",
            "хапка ",
            "взорвать ",
            "героин ",
            "спиды ",
            "миксы ",
            "спайсы ",
            "взорвали ",
            "водник ",
            "лин ",
            "лирика ",
            "ксанекс "

        };
        public SuffixTree()
        {
            foreach(string s in words)
            {
                Insert(ref node, s);
            }
           
            
        }
        
       
    }
}
