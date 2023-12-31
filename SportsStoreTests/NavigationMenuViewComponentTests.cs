﻿using Moq;
using SportsStore.Controllers;
using SportsStore.Models.ViewModels;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SportsStore.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Indicates_Select_Categories()
        {
            string categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID=1, Name="P1", Category="Apples"},
                new Product {ProductID=4, Name="P4", Category="Oranges"},
            }).AsQueryable<Product>);

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext { ViewContext = new ViewContext { RouteData = new Microsoft.AspNetCore.Routing.RouteData() } };
            target.RouteData.Values["category"] = categoryToSelect;

            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            Assert.Equal(categoryToSelect, result);
        }
        [Fact]
        public void Can_Select_Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID=1, Name="P1", Category="Apples"},
                new Product {ProductID=2, Name="P2", Category="Apples"},
                new Product {ProductID=3, Name="P3", Category="Plums"},
                new Product {ProductID=4, Name="P4", Category="Oranges"},
                new Product {ProductID=5, Name="P5", Category="Incognito"}
            }).AsQueryable<Product>);

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Incognito", "Oranges", "Plums" }, results));
        }
    }
}
