using Xunit;

namespace LabWorkWithSongs.Test
{
    public class TestEnumeratorSong
    {
        [Theory]
        [InlineData("Канкан", "Маг", "Дубак", "ЛСП", "Murovei", "Anacondaz")]
        public void List_songs_and_get_equal_result(string firstName, string secondName, string thirdName, string firstAuthor, string secondAuthor, string thirdAuthor)
        {
            var pastSong = new Song(thirdName, thirdAuthor);
            var song = new Song(secondName, secondAuthor, pastSong);

            pastSong = song;
            song = new Song(firstName, firstAuthor, pastSong);

            var position = 0;

            var listSong = new Song[3]
            {
                new Song(firstName, firstAuthor),
                new Song(secondName, secondAuthor, new Song(firstName,firstAuthor)),
                new Song(thirdName, thirdAuthor, new Song(secondName,secondAuthor)),
            };

            foreach (var element in song)
            {
                Assert.True(element.Equals(listSong[position]));
                position++;
            }
        }
    }
}
