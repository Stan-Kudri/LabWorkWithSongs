using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LabWorkWithSongs.Test
{
    public class TestEnumeratorSong
    {
        [Theory]
        [MemberData(nameof(Data.Enumeable), MemberType = typeof(Data))]
        public void Get_equal_result(Song checkSong, Song[] expectResult)
        {
            var song = checkSong;
            var arraySong = song.Reverse().ToArray();
            Assert.Equal(expectResult.Length, arraySong.Length);
            Assert.True(expectResult.SequenceEqual(arraySong));
        }

        private class Data
        {
            public static IEnumerable<object> Enumeable
            {
                get
                {
                    var firstResult = new Song[3]
                    {
                        new Song("Канкан", "ЛСП"),
                        new Song("Маг", "Murovei", new Song("Канкан","ЛСП")),
                        new Song("Дубак", "Anacondaz", new Song("Маг","Murovei")),
                    };
                    var secondResult = new Song[2]
                    {
                        new Song("Канкан", "ЛСП"),
                        new Song("Маг", "Murovei", new Song("Канкан","ЛСП")),
                    };
                    var thirdResult = new Song[1]
                    {
                        new Song("Канкан", "ЛСП")
                    };
                    yield return new object[]
                    {
                        new Song("Дубак", "Anacondaz", new Song("Маг","Murovei", new Song("Канкан","ЛСП"))),
                        firstResult
                    };
                    yield return new object[]
                    {
                        new Song("Маг","Murovei", new Song("Канкан","ЛСП")),
                        secondResult
                    };
                    yield return new object[]
                    {
                        new Song("Канкан","ЛСП"),
                        thirdResult
                    };
                }
            }
        }
    }
}
