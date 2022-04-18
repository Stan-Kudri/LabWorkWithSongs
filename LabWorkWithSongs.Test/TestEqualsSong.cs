using Xunit;

namespace LabWorkWithSongs.Test
{
    public class TestEqualsSong
    {
        [Theory]
        [InlineData("Канкан", "ЛСП")]
        public void Equals_same_object(string name, string author)
        {
            var secondSong = new Song(name, author);
            var firstSong = new Song(name, author, secondSong);
            Assert.True(firstSong.Equals(secondSong));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП")]
        public void Full_equals(string name, string author)
        {
            var secondSong = new Song(name, author).WithFeature("Oxxxymiron").WithFeature("Jubilee");
            var firstSong = new Song(name, author, secondSong).WithFeature("Oxxxymiron").WithFeature("Jubilee");
            Assert.True(firstSong.Equals(secondSong, SongEqualityType.Full));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП")]
        public void Equals_by_name(string name, string author)
        {
            var secondSong = new Song(name, author);
            var firstSong = new Song(name, author, secondSong);
            Assert.True(firstSong.Equals(secondSong, SongEqualityType.Name));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП")]
        public void Equals_by_author(string name, string author)
        {
            var secondSong = new Song(name, author);
            var firstSong = new Song(name, author, secondSong);
            Assert.True(firstSong.Equals(secondSong, SongEqualityType.Author));
        }
    }
}