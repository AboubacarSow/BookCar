﻿using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace BookCar.Infrastructure.Persistence;

public class BookCarDbContext : DbContext
{
    public BookCarDbContext(DbContextOptions<BookCarDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Reservation>()
                        .HasOne(r => r.DropOffLocation)
                        .WithMany(l => l.DropOffReservations)
                        .HasForeignKey(r => r.DropOffLocationID)
                        .OnDelete(DeleteBehavior.Restrict);
    
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FooterAddress> FooterAddresses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<RentACar> RentACars { get; set; }
    public DbSet<RentACarProcess> RentACarProcesses { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<TagCloud> TagClouds { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }


}
