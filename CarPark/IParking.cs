using System;

namespace CarPark
{
    /// <summary>
    /// Defines the details of car park usage
    /// </summary>
    public interface IParking
    {
        DateTime Entry { get; }
        DateTime Exit { get; }
    }
}