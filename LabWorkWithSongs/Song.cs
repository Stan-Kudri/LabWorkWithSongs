using System.Collections;

namespace LabWorkWithSongs
{
    public class Song : IEnumerable<Song>
    {
        private readonly string _name;
        private readonly string _author;
        private readonly Song? _previous;
        private readonly List<string> _artist;

        public string Name => _name;

        public string Author => _author;

        public Song? Previous => _previous;

        public string Title => _artist.Count > 0 ?
                    string.Format($"{_author} - {_name} feat {string.Join('&', _artist)}") :
                    $"{_author} - {_name}";

        public Song(string name, string author) : this(name, author, null)
        {
        }

        public Song(string name, string author, Song? pastSong = null)
        {
            _name = name;
            _author = author;
            _previous = pastSong;
            _artist = new List<string>();
        }

        public Song WithFeature(string artists)
        {
            ArgumentNullException.ThrowIfNull(artists, nameof(artists));
            _artist.Add(artists);
            _artist.Sort();
            return this;
        }

        public void PrintSong()
        {
            Console.WriteLine(Title);
        }

        public bool Equals(Song? song, SongEqualityType type)
        {
            if (song == null)
            {
                return false;
            }
            switch (type)
            {
                case SongEqualityType.Name:
                    return song.Name == _name;

                case SongEqualityType.Author:
                    return song.Author == _author;

                case SongEqualityType.Full:
                    return Equals(song);
            }
            return false;
        }

        private bool Equals(Song song)
        {
            if (_artist.Count == 0 && song._artist.Count == 0)
                return song._author == _author && song._name == _name;
            else if (_artist.Count == song._artist.Count)
                return _artist.SequenceEqual(song._artist) && song._author == _author && song._name == _name;
            return false;
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Song song)
                return Equals(song);
            return false;
        }

        public override int GetHashCode()
        {
            var hashCodeArtist = _artist.Select(x => x.GetHashCode()).DefaultIfEmpty().Aggregate((x, y) => x + y);
            return HashCode.Combine(_author, _name, _previous, hashCodeArtist);
        }

        public IEnumerator<Song> GetEnumerator()
        {
            return new SongEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
