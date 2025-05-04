using AnketUygulamasi.Models;

namespace AnketUygulamasi.DataStructures
{
    public class OyStack
    {
        private Stack<Vote> _stack = new();

        public void Ekle(Vote oy) => _stack.Push(oy);
        public Vote? GeriAl() => _stack.Count > 0 ? _stack.Pop() : null;
    }
}
