namespace CarPark
{
    /// <summary>
    /// Identifies a parking type
    /// </summary>
    public interface IParkingType
    {
        /// <summary>
        /// Name to display for a parking type.
        /// </summary>
        string FriendlyName { get; set; }
    }
}