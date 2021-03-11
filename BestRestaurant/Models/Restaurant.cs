namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    // Phone Number is a "long" because of the limits of an int
    // Originally with an int, the max phone number was 2147483647 (max size for a signed int is 2,147,483,647)
    // So someone with a Cali number might get their phone number allowed (if their area code started with a 2-something) but an Oregon number 503 would be "too big"
    // This is why phone numbers probably should be as a string

    public long PhoneNumber { get; set; }
    public int CuisineId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
  }
}