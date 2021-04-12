using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.Controllers;
using Movie.Models;
using Movie.MovieBL;
using Xunit;

namespace MovieTest
{
    public class MetadataControllerTest
    {

        private readonly MetadataController _controller;

        private readonly TestData _testData;

        private readonly Mock<IMovieDataBL> _movieDataBL;


        public MetadataControllerTest()
        {
            _movieDataBL = new Mock<IMovieDataBL>();
            _controller = new MetadataController(_movieDataBL.Object);
            _testData = new TestData();
        }

        #region Controller Tests

        [Fact]
        public void GetMovieData_WhenCalled_ReturnsOk()
        {
            // Arrange
            var data = _testData.movieMetadata.Where(m => m.MovieId == 1).OrderBy(m => m.Language);
            _movieDataBL.Setup(bl => bl.GetMovieData(It.IsAny<int?>())).Returns(data);
            // Act
            var okResult = _controller.GetById(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(200, ((OkObjectResult)okResult).StatusCode);
            Assert.IsAssignableFrom<IOrderedEnumerable<MovieMetadata>>(((OkObjectResult)okResult).Value);
        }

        [Fact]
        public void GetMovieData_WhenCalled_ReturnsNotFound()
        {
            // Arrange
            _movieDataBL.Setup(bl => bl.GetMovieData(4)).Returns(new List<MovieMetadata>().OrderBy(m => m.Language));
            // Act
            var notFoundResult = _controller.GetById(4);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.Equal(404, ((NotFoundResult)notFoundResult).StatusCode);
        }

        [Fact]
        public void GetMovieStats_WhenCalled_ReturnsCollection()
        {
            // Arrange
            var data = _testData.movieStats.OrderBy(m => m.Watches).ThenByDescending(m => m.ReleaseYear);
            _movieDataBL.Setup(bl => bl.GetMovieStats()).Returns(data);
            // Act
            var okResult = _controller.GetStats();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(200, ((OkObjectResult)okResult).StatusCode);
            Assert.IsAssignableFrom<IEnumerable<MovieMetadataStats>>(((OkObjectResult)okResult).Value);
        }

        [Fact]
        public void PostMovieData_WhenCalled_ReturnsOk()
        {
            // Arrange
            var postData = _testData.movieUpdateMetadata.ElementAt(0);
            _movieDataBL.Setup(bl => bl.SaveMovieData(It.IsAny<MovieUpdateData>())).Returns(true);
            // Act
            var okResult = _controller.Post(postData);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(200, ((OkObjectResult)okResult).StatusCode);
            Assert.IsType<bool>(((OkObjectResult)okResult).Value);
            Assert.Equal(true, ((OkObjectResult)okResult).Value);
        }

        #endregion
    }
}
