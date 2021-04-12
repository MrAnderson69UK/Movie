using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Movie.DataAccess;
using Movie.DataModels;
using Xunit;

namespace MovieTest
{
    public class MovieDataWriterTest
    {
        private readonly Mock<MovieDataWriter> _movieDataWriterMock;

        private readonly TestData _testData;

        public MovieDataWriterTest()
        {
            _movieDataWriterMock = new Mock<MovieDataWriter>
            {
                CallBase = true
            };
            _testData = new TestData();
        }

        #region Data Reader Tests

        [Fact]
        public void SaveMovieData_WhenCalledWithMetadata_ReturnsSuccessCount()
        {
            // Arrange
            var expected = 1;
            _movieDataWriterMock.Setup(dw => dw.WriteMovieData(It.IsAny<List<Metadata>>())).Returns(1);
            // Act
            var success = _movieDataWriterMock.Object.SaveMovieData(_testData.updateMetadata);
            // Assert
            Assert.IsType<int>(success);
            Assert.Equal<int>(expected, success);
        }

        [Fact]
        public void SaveMovieData_WhenCalledWithNoMetadata_ReturnsFailureCount()
        {
            // Arrange
            var expected = 0;
            _movieDataWriterMock.Setup(dw => dw.WriteMovieData(It.IsAny<List<Metadata>>())).Returns(0);
            // Act
            var success = _movieDataWriterMock.Object.SaveMovieData(_testData.updateMetadata);
            // Assert
            Assert.IsType<int>(success);
            Assert.Equal<int>(expected, success);
        }

        #endregion
    }
}
