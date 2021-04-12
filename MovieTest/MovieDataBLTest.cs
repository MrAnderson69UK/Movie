using System.Collections.Generic;
using System.Linq;
using Moq;
using Movie.DataAccess;
using Movie.DataModels;
using Movie.Models;
using Movie.MovieBL;
using Xunit;
using FluentAssertions;

namespace MovieTest
{
    public class MovieDataBLTest
    {
        private readonly Mock<IMovieDataReader> _movieDataReaderMock;
        private readonly Mock<IMovieDataWriter> _movieDataWriterMock;
        private readonly MovieDataBL _movieDataBL;
        private readonly TestData _testData;

        public MovieDataBLTest()
        {
            _movieDataReaderMock = new Mock<IMovieDataReader>();
            _movieDataWriterMock = new Mock<IMovieDataWriter>();
            _movieDataBL = new MovieDataBL(_movieDataReaderMock.Object, _movieDataWriterMock.Object);
            _testData = new TestData();
        }

        #region Movie Data dr Tests

        [Fact]
        public void GetMovieData_WhenCalledWith1_ReturnsTwoInCollection()
        {
            // Arrange
            var data = _testData.metadata.Where(m => m.MovieId == 1);
            _movieDataReaderMock.Setup(dr => dr.GetMovieData(1)).Returns(data);
            // Act
            var collectionResult = _movieDataBL.GetMovieData(1);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<MovieMetadata>>(collectionResult);
            Assert.Equal(2, collectionResult.Count());
            collectionResult.ElementAt(0).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 1, Title = "Movie 1", Language = "AR", Duration = "01:49:00", ReleaseYear = 2013 });
            collectionResult.ElementAt(1).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 1, Title = "MOVIE 1", Language = "EN", Duration = "01:49:00", ReleaseYear = 2013 });
        }

        [Fact]
        public void GetMovieData_WhenCalledWith2_ReturnsThreeInCollection()
        {
            // Arrange
            var data = _testData.metadata.Where(m => m.MovieId == 2);
            _movieDataReaderMock.Setup(dr => dr.GetMovieData(2)).Returns(data);
            // Act
            var collectionResult = _movieDataBL.GetMovieData(2);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<MovieMetadata>>(collectionResult);
            Assert.Equal(3, collectionResult.Count());
            collectionResult.ElementAt(0).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 2, Title = "Movie 2", Language = "AR", Duration = "02:45:00", ReleaseYear = 2012 });
            collectionResult.ElementAt(1).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 2, Title = "MOVIE 2", Language = "EN", Duration = "02:45:00", ReleaseYear = 2012 });
            collectionResult.ElementAt(2).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 2, Title = " Movie2", Language = "RU", Duration = "02:45:00", ReleaseYear = 2012 });
        }

        [Fact]
        public void GetMovieData_WhenCalledWith3_ReturnsTwoInCollection()
        {
            // Arrange
            var data = _testData.metadata.Where(m => m.MovieId == 3);
            _movieDataReaderMock.Setup(dr => dr.GetMovieData(3)).Returns(data);
            // Act
            var collectionResult = _movieDataBL.GetMovieData(3);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<MovieMetadata>>(collectionResult);
            Assert.Equal(2, collectionResult.Count());
            collectionResult.ElementAt(0).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 3, Title = "Movie 3", Language = "AR", Duration = "01:58:00", ReleaseYear = 2014 });
            collectionResult.ElementAt(1).Should().BeEquivalentTo(new MovieMetadata() { MovieId = 3, Title = "MOVIE 3", Language = "EN", Duration = "01:58:00", ReleaseYear = 2014 });
        }

        [Fact]
        public void GetMovieData_WhenCalled_ReturnsNotFound()
        {
            // Arrange
            var data = _testData.metadata.Where(m => m.MovieId == 4);
            _movieDataReaderMock.Setup(dr => dr.GetMovieData(4)).Returns(data);
            // Act
            var emptyCollectionResult = _movieDataBL.GetMovieData(4);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<MovieMetadata>>(emptyCollectionResult);
            Assert.Empty(emptyCollectionResult);
        }

        [Fact]
        public void GetMovieStats_WhenCalled_ReturnsOrderedStats()
        {
            // Arrange
            var movieData = _testData.metadata;
            var statsData = _testData.stats;
            _movieDataReaderMock.Setup(dr => dr.GetMovieData(It.IsAny<int?>())).Returns(movieData);
            _movieDataReaderMock.Setup(dr => dr.GetMovieStats()).Returns(statsData);
            // Act
            var statsResult = _movieDataBL.GetMovieStats();
            // Assert
            Assert.IsAssignableFrom<IEnumerable<MovieMetadataStats>>(statsResult);
            Assert.Equal(7, statsResult.Count());
            statsResult.ElementAt(0).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 2, AverageWatchDurationS = 2000000, ReleaseYear = 2012, Title = "MOVIE 2", Watches = 3 });
            statsResult.ElementAt(1).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 2, AverageWatchDurationS = 2000000, ReleaseYear = 2012, Title = " Movie2", Watches = 3 });
            statsResult.ElementAt(2).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 2, AverageWatchDurationS = 2000000, ReleaseYear = 2012, Title = "Movie 2", Watches = 3 });
            statsResult.ElementAt(3).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 3, AverageWatchDurationS = 2500000, ReleaseYear = 2014, Title = "Movie 3", Watches = 2 });
            statsResult.ElementAt(4).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 3, AverageWatchDurationS = 2500000, ReleaseYear = 2014, Title = "MOVIE 3", Watches = 2 });
            statsResult.ElementAt(5).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 1, AverageWatchDurationS = 1500000, ReleaseYear = 2013, Title = "MOVIE 1", Watches = 2 });
            statsResult.ElementAt(6).Should().BeEquivalentTo(new MovieMetadataStats() { MovieId = 1, AverageWatchDurationS = 1500000, ReleaseYear = 2013, Title = "Movie 1", Watches = 2 });
        }

        [Fact]
        public void PostMovieData_WhenCalled_ReturnsOk()
        {
            // Arrange
            var postData = _testData.movieUpdateMetadata.ElementAt(0);
            _movieDataWriterMock.Setup(bl => bl.SaveMovieData(It.IsAny<List<Metadata>>())).Returns(1);
            // Act
            var success = _movieDataBL.SaveMovieData(postData);
            // Assert
            Assert.IsType<bool>(success);
            Assert.True(success);
        }

        #endregion
    }
}
