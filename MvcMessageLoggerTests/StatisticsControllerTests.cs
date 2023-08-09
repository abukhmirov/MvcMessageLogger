//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using MvcMessageLogger.Models;
//using MvcMessageLogger.DataAccess;
//using MvcMessageLogger.FeatureTests;
//using System.Runtime.CompilerServices;

//namespace MvcMessageLoggerTests
//{
//    [Collection("Statistics Controller Tests")]
//    public class MvcMessageLoggerUsersTest : IClassFixture<WebApplicationFactory<Program>>
//    {
//        private readonly WebApplicationFactory<Program> _factory;
//        public MvcMessageLoggerUsersTest(WebApplicationFactory<Program> factory)
//        {
//            _factory = factory;
//        }

//        private MvcMessageLoggerContext GetDbContext()
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<MvcMessageLoggerContext>();
//            optionsBuilder.UseInMemoryDatabase("TestDatabase");

//            var context = new MvcMessageLoggerContext(optionsBuilder.Options);
//            context.Database.EnsureDeleted();
//            context.Database.EnsureCreated();

//            return context;
//        }
       

//    }
//}