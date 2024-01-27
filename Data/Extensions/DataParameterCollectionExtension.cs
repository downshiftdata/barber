namespace barber.Data.Extensions
{
    public static class DataParameterCollectionExtension
    {
        public static void AddRange<T>(this System.Data.IDataParameterCollection list, System.Collections.Generic.IEnumerable<T> items)
        {
            if (list == null) throw new System.ArgumentNullException(nameof(list));
            if (items == null) throw new System.ArgumentNullException(nameof(items));
            if (list is System.Collections.Generic.List<T> asList)
            {
                asList.AddRange(items);
            }
            else
            {
                foreach (var item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}