namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    // 1. Properties are now non-nullable with private setters and default values
    //    This prevents null reference exceptions
    public string GuestName { get; private set; } = string.Empty;
    public string RoomNumber { get; private set; } = string.Empty;
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    public int TotalDays { get; private set; }
    public double RatePerDay { get; private set; }
    public double Discount { get; private set; }
    public double TotalAmount { get; private set; }

    // 2. BookRoom is now async to await the logging task
    //    Renamed to BookRoomAsync to follow async naming convention
    public async Task BookRoomAsync(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        // 3. Assign values to properties instead of public fields
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        // 4. Compute total amount in one line for clarity
        TotalDays = (checkout - checkin).Days;
        TotalAmount = TotalDays * RatePerDay * (1 - Discount / 100);

        // 5. Await the logging task to ensure completion before printing
        await LogBookingDetailsAsync();

        // 6. Call a dedicated method to print booking details
        PrintBookingDetails();
    }

    // 7. Private method for logging details asynchronously
    private async Task LogBookingDetailsAsync()
    {
        await Task.Delay(1000); 
        Console.WriteLine("Booking log saved.");
    }

    // 8. Cancel method clears properties safely
    public void Cancel()
    {
        GuestName = string.Empty;
        RoomNumber = string.Empty;
        CheckInDate = default;
        CheckOutDate = default;
        RatePerDay = 0;
        Discount = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }

    // 9. Private method for printing details, to keep BookRoomAsync cleaner
    private void PrintBookingDetails()
    {
        Console.WriteLine($"Room Booked for {GuestName}");
        Console.WriteLine($"Room No: {RoomNumber}");
        Console.WriteLine($"Check-In: {CheckInDate}");
        Console.WriteLine($"Check-Out: {CheckOutDate}");
        Console.WriteLine($"Total Days: {TotalDays}");
        Console.WriteLine($"Amount: {TotalAmount}");
    }
}

// Replaced AppHost with proper Program class
class Program
{
    // 10. Main is async to support awaiting BookRoomAsync
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Booking System!");

        Booking booking = new Booking();

        // 11. Await the async booking method
        await booking.BookRoomAsync("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);

        // 12. Cancel the booking
        booking.Cancel();
    }
}
