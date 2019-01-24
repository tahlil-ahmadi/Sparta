using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparta.Domain;

namespace BusinessParties.Domain.Model
{
    //TODO: move to framework
    public static class ValueObjectExtensions
    {
        public static IList<T> Update<T>(this IList<T> source, List<T> target) where T : ValueObject
        {
            var added = target.Except(source).ToList();
            var removed = source.Except(target).ToList();

            added.ForEach(source.Add);
            removed.ForEach(a => source.Remove(a));
            return source;
        }
    }
}
