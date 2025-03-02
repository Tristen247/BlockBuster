using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlockBusterTest
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetMovieByID(11);

            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }

        [Fact]
        public void GetAllMovies()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 51); 
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetAllMoviesByGenreDescription()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByGenreDescription("Drama");
            Assert.True(result.Count >= 10);
        }

        [Fact]
        public void GetAllMoviesByDirectorLastName()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName("Coppola");
            Assert.True(result.Count == 2);
        }
    }
}
