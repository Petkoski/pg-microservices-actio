using Actio.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Actio.Api.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Home_Controller_Get_Should_Return_String_Content()
        {
            var controller = new HomeController();

            var result = controller.Get();

            var contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello from Actio API!");
        }
    }
}
