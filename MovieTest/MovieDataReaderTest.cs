using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Movie.DataAccess;
using Movie.DataModels;
using Xunit;

namespace MovieTest
{
    public class MovieDataReaderTest
    {
        private readonly Mock<MovieDataReader> _movieDataReaderMock;

        private readonly TestData _testData;

        public MovieDataReaderTest()
        {
            _movieDataReaderMock = new Mock<MovieDataReader>
            {
                CallBase = true
            };
            _testData = new TestData();
        }

        #region Data Reader Tests

        [Fact]
        public void GetMovieData_WhenCalledWith1_ReturnsTwoInCollection()
        {
            // Arrange
            _movieDataReaderMock.Setup(dr => dr.LoadMovieData()).Returns(_testData.metadata);
            // Act
            var foundResult = _movieDataReaderMock.Object.GetMovieData(1);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<Metadata>>(foundResult);
            Assert.Equal(2, foundResult.Count());
            Assert.Equal("EN", foundResult.ElementAt(0).Language);
            Assert.Equal("AR", foundResult.ElementAt(1).Language);
        }

        [Fact]
        public void GetById_WhenCalledWith2_ReturnsThreeInCollection()
        {
            // Arrange
            _movieDataReaderMock.Setup(dr => dr.LoadMovieData()).Returns(_testData.metadata);
            // Act
            var foundResult = _movieDataReaderMock.Object.GetMovieData(2);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<Metadata>>(foundResult);
            Assert.Equal(3, foundResult.Count());
            Assert.Equal("EN", foundResult.ElementAt(0).Language);
            Assert.Equal("RU", foundResult.ElementAt(1).Language);
            Assert.Equal("AR", foundResult.ElementAt(2).Language);
        }

        [Fact]
        public void GetById_WhenCalledWith3_ReturnsTwoInCollection()
        {
            // Arrange
            _movieDataReaderMock.Setup(dr => dr.LoadMovieData()).Returns(_testData.metadata);
            // Act
            var foundResult = _movieDataReaderMock.Object.GetMovieData(3).ToList();
            // Assert
            Assert.IsAssignableFrom<IEnumerable<Metadata>>(foundResult);
            Assert.Equal(2, foundResult.Count());
            Assert.Equal("AR", foundResult.ElementAt(0).Language);
            Assert.Equal("EN", foundResult.ElementAt(1).Language);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFound()
        {
            // Arrange
            _movieDataReaderMock.Setup(dr => dr.LoadMovieData()).Returns(new List<Metadata>());
            // Act
            var notFoundResult = _movieDataReaderMock.Object.GetMovieData(4);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<Metadata>>(notFoundResult);
            Assert.Empty(notFoundResult);
        }

        #endregion
    }
}
