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

        private bool Equals(Song? song)
        {
            if (song != null)
            {
                if (_artist.Count == 0 && song._artist.Count == 0)
                    return song._author == _author && song._name == _name;
                else if (_artist.Count == song._artist.Count)
                {
                    return _artist.SequenceEqual<string>(song._artist) && song._author == _author && song._name == _name && song.GetType() == GetType();
                }
            }
            return false;
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return Equals(obj as Song);
        }

        public override int GetHashCode()
        {
            if (_artist.Count > 1)
            {
                var hashCodeArtist = _artist.Select(x => x.GetHashCode()).Aggregate((x, y) => x + y);
                return HashCode.Combine(_author, _name, _previous, hashCodeArtist);
            }
            else if (_artist.Count == 1)
            {
                return HashCode.Combine(_author, _name, _previous, _artist.First().GetHashCode());
            }
            return HashCode.Combine(_author, _name, _previous);
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
