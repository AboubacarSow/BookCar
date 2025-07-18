﻿namespace BookCar.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IAboutRepository About { get; }
    IBannerRepository Banner { get; }
    IBrandRepository Brand { get; }
    ICategoryRepository Category { get; }
    IContactRepository Contact { get; }
    ICarRepository Car { get; }
    IFeatureRepository Feature { get; }
    IFooterAddressRepository FooterAddress { get; }
    ILocationRepository Location { get; }
    IServiceRepository Service { get; }
    IPricingRepository Pricing { get; }
    ISocialMediaRepository SocialMedia { get; }
    ITestimonialRepository Testimonial{ get; }

    Task SaveChangesAsync();
}
