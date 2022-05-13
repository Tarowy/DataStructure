using System.Collections.Generic;
using System.Text;

namespace DataStructure.Graph.DFStraverse
{
    public class MyList<T> : List<T>
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('[');
            for (var i = 0; i < base.Count; i++)
            {
                sb.Append(base[i]);
                if (i != Count - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.Append(']').ToString();
        }
    }
}