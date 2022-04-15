using Xunit;

namespace LabWorkWithSongs.Test
{
    public class TestNotEqualsSong
    {
        [Theory]
        [InlineData("Канкан", "Маг", "ЛСП", "Murovei")]
        public void Create_two_unequal_songs(string firstName, string secondName, string firstAuthor, string secondAuthor)
        {
            //Песни не равны
            var secondSong = new Song(firstName, firstAuthor);
            var firstSong = new Song(secondName, secondAuthor, secondSong);
            Assert.False(firstSong.Equals(secondSong));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП")]
        public void Create_two_unequal_songs_in_full(string name, string author)
        {
            //Все исполнители песней не совпадают
            var secondSong = new Song(name, author).WithFeature("Oxxxymiron").WithFeature("Jubilee").WithFeature("Murovei");
            var firstSong = new Song(name, author, secondSong).WithFeature("Oxxxymiron").WithFeature("Jubilee");
            Assert.False(firstSong.Equals(secondSong, SongEqualityType.Full));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП", "Murovei")]
        public void Create_two_unequal_songs_in_name(string firstName, string secondName, string author)
        {
            //Названия песен не совпадают
            var secondSong = new Song(firstName, author);
            var firstSong = new Song(secondName, author, secondSong);
            Assert.False(firstSong.Equals(secondSong, SongEqualityType.Name));
        }

        [Theory]
        [InlineData("Канкан", "ЛСП", "Murovei")]
        public void Create_two_unequal_songs_in_author(string name, string firstAuthor, string secondAuthor)
        {
            //Авторы песен не совпадают
            var secondSong = new Song(name, firstAuthor);
            var firstSong = new Song(name, secondAuthor, secondSong);
            Assert.False(firstSong.Equals(secondSong, SongEqualityType.Author));
        }
    }
}
