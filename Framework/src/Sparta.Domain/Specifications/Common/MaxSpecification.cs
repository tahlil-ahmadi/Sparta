using System;

namespace Sparta.Domain.Specifications.Common
{
    public class MaxSpecification<T> : CompositeSpecification<T> where T : IComparable
    {
        private readonly T _maxValue;
        public MaxSpecification(T maxValue)
        {
            _maxValue = maxValue;
        }
        public override bool IsSatisfiedBy(T entry)
        {
            var result  = _maxValue.CompareTo(entry);
            return result >= 0;
        }
    }
}
