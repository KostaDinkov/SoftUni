namespace _1.CustomLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    

    static class CustomLINQ
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (var element in collection)
            {
                if (!predicate(element))
                {
                    result.Add(element);
                }
            }
            return  result;
        }

        public static TSelector MaxWithSelector<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> selectFunc )
        {
            //select the elements using the selector function 
            var selectedItems = new List<TSelector>();
            foreach (var element in collection)
            {
                TSelector selectedItem = selectFunc(element);
                selectedItems.Add(selectedItem);
            }
            //find maximum and return it

            if (selectedItems == null)
                throw new NullReferenceException();
            Comparer<TSelector> @default = Comparer<TSelector>.Default;
            TSelector y = default(TSelector);
            
if ((object)y == null)
            {
                foreach (TSelector x in selectedItems)
                {
                    if ((object)x != null && ((object)y == null || @default.Compare(x, y) > 0))
                        y = x;
                }
                return y;
            }
            bool flag = false;
            foreach (TSelector x in selectedItems)
            {
                if (flag)
                {
                    if (@default.Compare(x, y) > 0)
                        y = x;
                }
                else
                {
                    y = x;
                    flag = true;
                }
            }
            if (flag)
                return y;
            throw new InvalidOperationException("No elements");

        }
    }
}
