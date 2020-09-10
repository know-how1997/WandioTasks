using System;
using System.Collections.Generic;


namespace NoSenseLibrary.Services.NoSenseService
{
    public static class EnumerableService
    {
        public static T ThisDoesntMakeAnySense<T>(this IEnumerable<T> records, Func<T, bool> predicate, Func<T> create)
        {
            if (records == null)
                throw new ArgumentNullException("Null records exception");

            foreach (var record in records)
            {
                if (record == null)
                    throw new ArgumentNullException();

                if (predicate == null)
                    throw new ArgumentException("Predicate function is null");

                if (predicate(record))
                    return default;
            }

            if (create == null)
                throw new ArgumentException("Create function is null");

            return create();

        }
    }
}
