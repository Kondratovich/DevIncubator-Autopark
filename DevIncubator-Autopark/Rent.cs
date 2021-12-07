namespace DevIncubatorAutopark
{
    internal class Rent
    {
        public DateTime RentDate { get; }
        public double RentPrice { get; }

        public Rent() { }
        public Rent(DateTime rentDate, double rentPrice)
        {
            RentDate = rentDate;
            RentPrice = rentPrice;
        }
    }
}
