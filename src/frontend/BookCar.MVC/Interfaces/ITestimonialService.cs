namespace BookCar.MVC.Interfaces;

public interface ITestimonialService
{
    Task<List<TestimonialDto>> GetTestimonials();
}
