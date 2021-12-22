namespace DevIncubatorAutopark
{
    internal class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is null || y is null)
                throw new ArgumentNullException("Error, argument cannot be null");

            return x.Model.CompareTo(y.Model);
        }
    }
}
